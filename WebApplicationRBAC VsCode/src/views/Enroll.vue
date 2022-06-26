<template>
    <div>
        <el-form ref="form" :model="form" label-width="80px">
            <el-form-item label="用户名">
                <el-input v-model="form.AdmName"></el-input>
            </el-form-item>
            <el-form-item label="密码">
                <el-input v-model="form.AdmPassWord" show-password></el-input>
            </el-form-item>
            <el-form-item label="确认密码">
                <el-input v-model="form.Confirm" show-password></el-input>
            </el-form-item>
            <el-form-item label="邮箱">
                <el-input v-model="form.AdmEmail"></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">注册</el-button>
                <el-button @click="Cancel">取消</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
  export default {
    data() {
      return {
        form: {
            AdmName:'',
            AdmPassWord:'',
            AdmEmail:'',
            Confirm:''
        }
      }
    },
    methods: {
      onSubmit() {
        if(this.form.AdmName == "")
        {
            this.$message({
                message: '账号不能为空',
                type: 'warning'
            });

            return;
        }
        if(this.form.AdmPassWord == "")
        {
            this.$message({
                message: '密码不能为空',
                type: 'warning'
            });

            return;
        }
        if(this.form.Confirm == "")
        {
            this.$message({
                message: '请确认密码',
                type: 'warning'
            });

            return;
        }
        if(this.form.Confirm != this.form.AdmPassWord)
        {
            this.$message({
                message: '两次密码不一致',
                type: 'warning'
            });

            return;
        }
        if(this.form.AdmEmail == "")
        {
            this.$message({
                message: '邮箱不能为空',
                type: 'warning'
            });

            return;
        }

        this.$http.post("https://localhost:44356/api/AdminInfo/AdminAdd",this.form).then(res=>{
            if(res.data.Code == 1){
                this.$message.error('该用户已存在');
            }
            if(res.data.Code == 0){
                this.$message({
                    message: '注册成功',
                    type: 'success'
                });

                //this.$router.push('/Login')

                this.$emit("OnEnroll",true)
            }
        })
      },
      Cancel(){
        this.$message('已经取消注册');
        this.$router.push("/Login")
      }
    }
  }
</script>