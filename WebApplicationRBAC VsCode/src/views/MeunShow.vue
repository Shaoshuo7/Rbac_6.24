<template>
    <div>
        <!-- <el-button type="text" @click="dialogVisible = true">新增</el-button> -->

        <el-button @click="Add">添加</el-button>

        <el-dialog
            title="菜单新增"
            :visible.sync="dialogVisible"
            width="30%">
                <!-- <MeunAdd @AddTable="AddTable"/> -->

                <meun-add @AddTable="AddTable"/>>
        </el-dialog>

        <el-table
            :data="tableData"
            style="width: 100%;margin-bottom: 20px;"
            row-key="MeunId"
            border
            default-expand-all
            :tree-props="{children: 'children', hasChildren: 'hasChildren'}">
            <el-table-column
            prop="MeunName"
            label="名称"
            sortable
            width="180">
            </el-table-column>
            <el-table-column
            prop="MeunLink"
            label="链接">
            </el-table-column>
            <el-table-column
            label="操作">
                <template slot-scope="scope">
                    <el-button type="primary" round @click="OnUpd(scope.row.MeunId)">修改</el-button>
                    <el-button type="danger" round @click="OnDel(scope.row.MeunId)">删除</el-button>
                </template>
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
import MeunAdd from '@/views/MeunAdd.vue'

  export default {
    components: {
        MeunAdd
    },
    data() {
      return {
        dialogVisible:false,
        tableData: []
      }
    },
    methods: {
        Load(){
            this.$http.get("https://localhost:44356/api/MeunInfo/MeunAll").then(res=>{
                this.tableData = res.data
            })
        },
        OnDel(id){
            this.$confirm('此操作将永久删除该文件, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
                }).then(() => {
                    this.$http.get("https://localhost:44356/api/MeunInfo/Del?id="+id).then(res=>{
                        if(res.data == 500){
                            this.$message({
                                message: '该条数据有子节点不能删除',
                                type: 'warning'
                            });
                        }
                        else if(res.data > 0){
                            this.$message({
                            message: '删除成功',
                            type: 'success'
                        });

                        this.Load()
                        }
                    })
                }).catch(() => {
                this.$message({
                    type: 'info',
                    message: '已取消删除'
                });          
            });
        },
        AddTable(val){
            this.dialogVisible = !val
            this.Load()
        },
        Add(){
            this.dialogVisible = true
        },
        OnUpd(id){
            this.$router.push('/MeunUpd?id='+id)
        }
    },
    created(){
        this.Load()
    }
  }
</script>