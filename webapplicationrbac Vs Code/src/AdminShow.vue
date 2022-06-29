<template>
    <div>
        <el-table
            :data="tableData"
            style="width: 100%">
            <el-table-column
                prop="AdmName"
                label="用户名"
                width="180">
            </el-table-column>
            <el-table-column
                prop="AdmEmail"
                label="用户邮箱"
                width="180">
            </el-table-column>
            <el-table-column
                prop="CreateTime"
                label="创建时间">
            </el-table-column>
        </el-table>

        <!-- <el-pagination
            @size-change="handleSizeChange"
            @current-change="handleCurrentChange"
            :current-page="from.Page"
            :page-sizes="[1, 2, 3, 4]"
            :page-size="from.Size"
            layout="total, sizes, prev, pager, next, jumper"
            :total="from.TotalCount"
            background>
        </el-pagination> -->
    </div>
</template>

  <script>
    export default {
      data() {
        return {
          tableData: [],
        //   from:{
        //     Page:1,
        //     Size:3,
        //     TotalCount:0
        //   }
        }
      },
      methods:{
        Load(){
            this.$http.get("https://localhost:44356/api/AdminInfo/GetShow").then(res=>{
                this.tableData = res.data
                // this.from.TotalCount = res.data.TotalCount
            })
        },
        // handleSizeChange(val){
        //     this.from.Page = 1

        //     this.from.Size = val

        //     this.Load()
        // },
        // handleCurrentChange(val)
        // {
        //     this.from.Page = val

        //     this.Load()
        // }
      },
      created(){
        this.Load()
      }
    }
  </script>