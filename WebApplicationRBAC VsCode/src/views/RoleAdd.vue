<template>
    <div>
        <el-form ref="form" :model="form" label-width="80px">
            <el-form-item label="名称">
                <el-input v-model="form.RoleName"></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">添加</el-button>
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
            RoleName:''
        }
      }
    },
    methods: {
      onSubmit() {
        this.$http.post("https://localhost:44356/api/RoleInfo/Add",this.form).then(res=>{
            if(res.data > 0){
                this.$message({
                    message: '添加成功',
                    type: 'success'
                });

                this.$emit("RoleTable",true);
            }
        })
      },
      FanHui(){
        this.$router.push('/RoleShow')
      }
    }
  }
</script>