<template>
    <div>
        <h1>用户登录</h1><br>
        <el-button type="primary" @click="dialogVisible = true">注册新用户</el-button>
        <br>
        <el-form ref="form" :model="form" label-width="80px">
            <el-form-item label="用户名">
                <el-input v-model="form.AdmName"></el-input>
            </el-form-item>
            <el-form-item label="密码">
                <el-input v-model="form.AdmPassWord" show-password></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">登录</el-button>
            </el-form-item>
        </el-form>

        

        <el-dialog
        title="注册"
        :visible.sync="dialogVisible"
        width="30%">
            <Enroll @OnEnroll="OnEnroll"/>
        </el-dialog>
    </div>
</template>

<script>
import Enroll from '@/views/Enroll.vue'

  export default {
    components: {
        Enroll
    },
    data() {
      return {
        form: {
            AdmName:'',
            AdmPassWord:''
        },
        dialogVisible:false
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

        this.$http.post("https://localhost:44356/api/AdminInfo/AdmLogin",this.form).then(res=>{
            if(res.data.Code == 1){
                this.$message('该用户未注册');
            }
            if(res.data.Code == 2){
                this.$message('密码输入错误');
            }
            if(res.data.Code == 0){
                this.$message({
                    message: '登陆成功',
                    type: 'success'
                });
                window.sessionStorage.setItem("LogName","oooo")
                this.$router.push('/MeunShow')
            }
        })
      },
      OnEnroll(val){
        this.dialogVisible = !val
      }
    }
  }
</script>