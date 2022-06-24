<template>
    <div>
        <el-form ref="from" :model="from" label-width="80px">
            <el-form-item label="菜单名称">
                <el-input v-model="from.MeunName"></el-input>
            </el-form-item>
            <el-form-item label="菜单链接">
                <el-input v-model="from.MeunLink"></el-input>
            </el-form-item>
            <el-form-item label="菜单链接">
                <el-cascader
                v-model="from.MeId"
                :options="options"
                :props="{ checkStrictly: true }"
                ref="GetMeId"
                clearable></el-cascader>

                <!-- <el-cascader
                  v-model="value"
                  :options="options"
                  @change="handleChange"></el-cascader> -->
            <el-form-item>
            </el-form-item>
                
                <el-button type="primary" @click="onSubmit">修改</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
  export default {
    data() {
      return {
        value:[],
        options:[],
        from:{
            MeunId:0,
            MeunName:'',
            MeId:null,
            MeunLink:''
        }
      };
    },
    methods: {
        FanT(){
            this.from.MeunId = location.href.split('=')[1]
            this.$http.get("https://localhost:44356/api/MeunInfo/FanT?id="+this.from.MeunId).then(res=>{
                this.from = res.data

                console.log(this.from.MeId)
                
                console.log(this.options)
                console.log(this.value)
            })
        },
      handleChange() {
       this.$http.get("https://localhost:44356/api/MeunInfo/Cascading").then(res=>{
            var reg = new RegExp('\\,"children":\\[]', 'g')
            
            this.options = JSON.parse(JSON.stringify(res.data).replace(reg, ''))
        })
      },
      onSubmit(){
        // debugger
          //this.from.MeId = this.value.slice(-1)[0];
          this.from.MeId=this.$refs["GetMeId"].checkedValue[this.$refs["GetMeId"].checkedValue.length-1];
          console.log(this.from);
            
        this.$http.post("https://localhost:44356/api/MeunInfo/Upd",this.from).then(res=>{
          if(res.data>0){
            this.$message({
                message: '修改成功',
                type: 'success'
            });
            this.$router.push('/MeunShow')
          }
        })
      }
    },
    created(){
        this.handleChange();

        this.FanT();
        
    }
  };
</script>