<template>
    <div>
        <el-button type="primary" round @click="OnAdd">添加</el-button>

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
                <template slot-scope="scope">
                    {{scope.row.CreateTime.substr(0,10)}}
                </template>
            </el-table-column>
            <el-table-column
                label="操作">
                <template slot-scope="scope">
                  <el-button type="danger" round @click="OnDel(scope.row.AdminId)">删除</el-button>
                </template>
            </el-table-column>
        </el-table>

        <el-pagination
            @size-change="handleSizeChange"
            @current-change="handleCurrentChange"
            :current-page="from.Page"
            :page-sizes="[1, 2, 3, 4]"
            :page-size="from.Size"
            layout="total, sizes, prev, pager, next, jumper"
            :total="from.TotalCount"
            background>
        </el-pagination>

        <el-dialog
          title="添加管理员"
          :visible.sync="dialogVisible"
          width="30%">
            <admin-and-role @AddAdmin="AddAdmin" :key="new Date().getTime()"/>
        </el-dialog>
    </div>
</template>

  <script>
import AdminAndRole from '@/views/AdminAndRole.vue'

    export default {
      components: {
        AdminAndRole
      },
      data() {
        return {
          dialogVisible:false,
          tableData: [],
          from:{
            Page:1,
            Size:3,
            TotalCount:0
          }
        }
      },
      methods:{
        Load(){
            this.$http.get("https://localhost:44356/api/AdminInfo/GetShow",{params:this.from}).then(res=>{
                this.tableData = res.data.Data
                this.from.TotalCount = res.data.TotalCount
            })
        },
        handleSizeChange(val){
            this.from.Page = 1

            this.from.Size = val

            this.Load()
        },
        handleCurrentChange(val)
        {
            this.from.Page = val

            this.Load()
        },
        OnDel(id){
          this.$confirm('此操作将永久删除该文件, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
                }).then(() => {
                    this.$http.get("https://localhost:44356/api/AdminInfo/Del?id="+id).then(res=>{
                        this.$message({
                            message: '删除成功',
                            type: 'success'
                        });

                        this.Load()
                    })
                }).catch(() => {
                this.$message({
                    type: 'info',
                    message: '已取消删除'
                });          
            });
        },
        OnAdd(){
          this.dialogVisible = true
        },
        AddAdmin(val){
          this.dialogVisible = !val;

          this.Load()
        }
      },
      created(){
        this.Load()
      }
    }
  </script>