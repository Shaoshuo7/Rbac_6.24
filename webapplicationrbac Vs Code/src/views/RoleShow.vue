<template>
    <div>
        <el-button type="text" @click="dialogVisible = true">添加角色</el-button>

        <el-dialog
            title="提示"
            :visible.sync="dialogVisible"
            width="30%">
            <RoleAdd @RoleTable="RoleTable"/>
        </el-dialog>

        <el-table
            :data="tableData"
            style="width: 100%">
            <el-table-column
                prop="RoleId"
                label="编号"
                width="180">
            </el-table-column>
            <el-table-column
                prop="RoleName"
                label="姓名"
                width="180">
            </el-table-column>
            <el-table-column
                label="操作"
                width="380">
                <template slot-scope="scope">
                    <el-button type="primary" round @click="OnUpd(scope.row.RoleId)">编辑</el-button>
                    <el-button type="primary" round @click="OnFen(scope.row.RoleId)">权限分配</el-button>
                    <el-button type="danger" round @click="OnDel(scope.row.RoleId)">删除</el-button>
                </template>
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
import RoleAdd from '@/views/RoleAdd.vue'

    export default {
        components: {
            RoleAdd
        },
      data() {
        return {
          tableData: [],
          dialogVisible:false
        }
      },
      methods:{
        Load(){
            this.$http.get("https://localhost:44356/api/RoleInfo/GetShow").then(res=>{
                this.tableData = res.data
            })
        },
        OnDel(id){
            this.$confirm('此操作将永久删除该文件, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
                }).then(() => {
                    this.$http.get("https://localhost:44356/api/RoleInfo/Del?id="+id).then(res=>{
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
        RoleTable(val){
            this.dialogVisible = !val

            this.Load()
        },
        OnUpd(id){
            this.$router.push('/RoleUpd?id='+id)
        },
        OnFen(id){
            alert("没写");
        }
      },
      created(){
        this.Load()
      }
    }
  </script>