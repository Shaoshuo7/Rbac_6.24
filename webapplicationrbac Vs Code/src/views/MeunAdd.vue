<template>
    <div>
        <el-form ref="from" :model="from" label-width="80px">
            <el-form-item label="菜单名称">
                <el-input v-model="from.MeunName"></el-input>
            </el-form-item>
            <el-form-item label="菜单链接">
                <el-input v-model="from.MeunLink"></el-input>
            </el-form-item>
            <el-form-item label="父级ID">
                <el-cascader
                v-model="value"
                :options="options"
                :props="{ checkStrictly: true }"
                clearable></el-cascader>

                <!-- <el-cascader
                  v-model="value"
                  :options="options"
                  @change="handleChange"></el-cascader> -->
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
        value:[],
        options:[],
        from:{
            MeunName:'',
            MeId:null,
            MeunLink:''
        }
      };
    },
    methods: {
      handleChange() {
       this.$http.get("https://localhost:44356/api/MeunInfo/Cascading").then(res=>{
            var reg = new RegExp('\\,"children":\\[]', 'g')
            
            this.options = JSON.parse(JSON.stringify(res.data).replace(reg, ''))
        })
      },
      onSubmit(){
        // debugger
          this.from.MeId = this.value.slice(-1)[0];
          console.log(this.from);
            
        this.$http.post("https://localhost:44356/api/MeunInfo/Add",this.from).then(res=>{
          if(res.data>0){
            this.$message({
                message: '添加成功',
                type: 'success'
            });
            this.$emit("AddTable",true);
          }
        })
      }
    },
    created(){
        this.handleChange();
        
    }
  };
</script>