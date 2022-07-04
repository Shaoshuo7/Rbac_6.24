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

        <el-dialog
        title="分配权限"
        :visible.sync="FendialogVisible"
        width="30%">
            <role-and-meun ref="RoleAndMeun" :RoleId="RoleId"/>

        <span slot="footer" class="dialog-footer">
            <el-button @click="FendialogVisible = false">取 消</el-button>
            <el-button type="primary" @click="EpitRoleAndMeun">确 定</el-button>
        </span>
        </el-dialog>
    </div>
</template>

<script>
import RoleAdd from '@/views/RoleAdd.vue'
import RoleAndMeun from '@/views/RoleAndMeun.vue'
    export default {
        components: {
            RoleAdd,
            RoleAndMeun
        },
      data() {
        return {
          tableData: [],
          dialogVisible:false,
          FendialogVisible:false,
            RoleId:0
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
            this.RoleId = id;

            this.FendialogVisible = true
        },
        EpitRoleAndMeun(){
            var checkedId = this.$refs.RoleAndMeun.$refs.RoleAndMeun.getCheckedNodes(true,true).map(t=>t.value);
            var RoleId = this.RoleId;
            this.DelRoleMeun();
            this.$http.post("https://localhost:44356/api/RoleInfo/Saverp",{MeunId:checkedId,RoleId:RoleId}).then(res=>{
                this.$message({
                    message: '权限分配成功',
                    type: 'success'
                });

                this.Load()
            });

            this.FendialogVisible = false
        },
        DelRoleMeun(){
            this.$http.get("https://localhost:44356/api/RoleInfo/DelRoleMeun?id="+this.RoleId).then(res=>{

            })
        }
      },
      created(){
        this.Load()
      }
    }
  </script>