<template>
    <div>
        <el-form ref="form" :model="form" label-width="80px">
            <el-form-item label="名称">
                <el-input v-model="form.RoleName"></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">修改</el-button>
                <el-button @click="FanHui">取消</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
  export default {
    data() {
      return {
        form: {
            RoleId:0,
            RoleName:''
        }
      }
    },
    methods: {
        FanT(){
            this.form.RoleId = location.href.split('=')[1]
            this.$http.get("https://localhost:44356/api/RoleInfo/FanT?id="+this.form.RoleId).then(res=>{
                this.form = res.data
            })
        },
      onSubmit() {
        this.$http.post("https://localhost:44356/api/RoleInfo/Upd",this.form).then(res=>{
            if(res.data > 0){
                this.$message({
                    message: '添加成功',
                    type: 'success'
                });

                this.$router.push('/RoleShow')
            }
        })
      },
      FanHui(){
        this.$router.push('/RoleShow')
      }
    },
    created(){
        this.FanT()
    }
  }
</script>