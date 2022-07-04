<template>
    <div>
        <el-tree
            ref="RoleAndMeun"
            :data="data"
            show-checkbox
            node-key="value"
            :default-checked-keys="CheckIds"
            :default-expand-all="true"
            :props="defaultProps">
        </el-tree>

        <button @click="GetDate">666</button>
    </div>
</template>

<script>

  export default {
    data() {
      return {
        data: [],
        defaultProps: {
          //id:'value',
          children: 'children',
          label: 'label'
        },
        CheckIds:[]
      };
    },
    props:{
        RoleId:{
            type:Number
        }
    },
    created(){
        this.$http.get("https://localhost:44356/api/MeunInfo/Cascading").then(res=>{
            var reg = new RegExp('\\,"children":\\[]', 'g')
            
            this.data = JSON.parse(JSON.stringify(res.data).replace(reg, ''))
        }),
        this.$http.get(`https://localhost:44356/api/RoleInfo/GetPermiss?RoleId=${this.RoleId}`).then(res=>{
          console.log(res.data);

          this.CheckIds = res.data.map(t=>t.MeunId);
        })
    },
    methods:{
        GetDate(){
            var list = this.$refs.RoleAndMeun.getCheckedNodes(true,true).map(t=>t.value);
            console.log(list);
        }
    }
  };
</script>