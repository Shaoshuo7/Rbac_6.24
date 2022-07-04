<template>
        <div class="LoginInfo">
            <el-card class="box-card">
                <div slot="header" class="clearfix">
                    <span>用户登录</span>
                    <el-button style="float: right; padding: 3px 0" type="text" @click="dialogVisible = true">注册新用户</el-button>
                </div>
                <br>
                <el-form ref="form" :model="form" label-width="80px">
                    <el-form-item label="用户名">
                        <el-input v-model="form.AdmName"></el-input>
                    </el-form-item>
                    <el-form-item label="密码">
                        <el-input v-model="form.AdmPassWord" show-password></el-input>
                    </el-form-item>
                    <el-form-item label="验证码">
                        <el-input disabled v-model="form.Varif1"></el-input>
                        <el-input v-model="form.Varif2"></el-input>
                        <el-link type="primary" @click="GetValfi">刷新验证码</el-link>
                    </el-form-item>
                    <el-form-item>
                        <el-button type="primary" @click="onSubmit">登录</el-button>
                    </el-form-item>
                </el-form>
            </el-card>

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
            AdmPassWord:'',
            Varif1:'',
            Varif2:''
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

        if(this.form.Varif2 == "")
        {
            this.$message({
                message: '验证码不能为空',
                type: 'warning'
            });

            return;
        }

        if(this.form.Varif2 != this.form.Varif1)
        {
            this.$message('验证码错误');
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

                localStorage.setItem("token",res.data.Token)

                this.$router.push('/')
            }
        })
      },
      OnEnroll(val){
        this.dialogVisible = !val
      },
      GetValfi(){
        this.$http.get("https://localhost:44356/api/AdminInfo/VerificationInfo").then(res=>{
          this.form.Varif1 = res.data;
        })
      }
    },
    created(){
      this.GetValfi()
    }
  }
</script>

<style>
    .LoginInfo{
        background:rgb(72, 196, 185);
        width: 100%;
        height: 100%;
        padding-top: 7em;
    }
   .el-card{
    margin: 0 auto;
    }
  .text {
    font-size: 14px;
  }

  .item {
    margin-bottom: 18px;
  }

  .clearfix:before,
  .clearfix:after {
    display: table;
    content: "";
  }
  .clearfix:after {
    clear: both
  }

  .box-card {
    width: 480px;
  }
</style>