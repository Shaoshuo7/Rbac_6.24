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
                <el-input v-model="Confirm" show-password></el-input>
            </el-form-item>
            <el-form-item label="邮箱">
                <el-input v-model="form.AdmEmail"></el-input>
            </el-form-item>
            <el-form-item label="角色">
                <el-select v-model="form.RoleId" multiple placeholder="请选择">
                    <el-option
                        v-for="item in options"
                        :key="item.RoleId"
                        :label="item.RoleName"
                        :value="item.RoleId">
                        </el-option>
                    </el-select>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">添加</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
  export default {
    data() {
      return {
        options:[],
        form: {
            AdmName:'',
            AdmPassWord:'',
            AdmEmail:'',
            RoleId:[]
        },
        Confirm:'',
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
        if(this.Confirm == "")
        {
            this.$message({
                message: '请确认密码',
                type: 'warning'
            });

            return;
        }
        if(this.Confirm != this.form.AdmPassWord)
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

        this.$http.post("https://localhost:44356/api/AdminInfo/Permis",this.form).then(res=>{
            if(res.data.Code == 1){
                this.$message.error('该用户已存在');
            }
            if(res.data.Code == 0){
                this.$message({
                    message: '添加成功',
                    type: 'success'
                });

                //this.$router.push('/AdminShow')

                this.$emit("AddAdmin",true)
            }
        })
      }
    },
    created(){
        this.$http.get("https://localhost:44356/api/RoleInfo/GetList").then(res=>{
            this.options = res.data
        })
    }
  }
</script>