<template>
    <div>
        <el-container>
            <el-header>权限管理系统</el-header>
            <el-container>
                <el-aside width="200px">
                    <el-menu
                        :unique-opened="true"
                        default-active="2"
                        class="el-menu-vertical-demo"
                        @open="handleOpen"
                        @close="handleClose"
                        background-color="#545c64"
                        text-color="#fff"
                        active-text-color="#ffd04b" :router="true">
                        <el-submenu index="1" v-for="item in SelectMeun" :key="item.MeunId">
                            <template slot="title">
                            <i class="el-icon-location"></i>
                            <span>
                              {{item.MeunName}}
                            </span>
                            </template>
                            <el-menu-item-group>
                              <el-menu-item v-for="items in MeunList.filter(t=>t.MeId==item.MeunId)" :key="items.MeunId">
                               <el-menu-item :index="iteme.MeunLink" v-for="iteme in MeunList.filter(t=>t.MeId==items.MeunId && t.IsDefault)" :key="iteme.MeunId">
                                  {{iteme.MeunName}}
                                </el-menu-item> 
                              </el-menu-item>
                            </el-menu-item-group>
                        </el-submenu>
                        <!-- <el-submenu index="2">
                            <template slot="title">
                            <i class="el-icon-location"></i>
                            <span>角色导航</span>
                            </template>
                            <el-menu-item-group>
                            <template slot="title">分组二</template>
                            <el-menu-item index="/RoleShow">角色</el-menu-item>
                            <el-menu-item index="/RoleAdd">角色添加</el-menu-item>
                            <el-menu-item index="/RoleUpd">角色编辑</el-menu-item>
                            </el-menu-item-group>
                        </el-submenu> -->
                        <!-- <el-menu-item index="2">
                            <i class="el-icon-menu"></i>
                            <span slot="title">导航二</span>
                        </el-menu-item> -->
                    </el-menu>
                </el-aside>
                <el-main>
                    <router-view/>
                </el-main>
            </el-container>
        </el-container>
    </div>
</template>

<script>
  export default {
    data(){
      return{
        MeunList:[]
      }
    },
    methods: {
      handleOpen(key, keyPath) {
        console.log(key, keyPath);
      },
      handleClose(key, keyPath) {
        console.log(key, keyPath);
      }
    },
    computed:{
      SelectMeun(){
        return this.MeunList.filter(t=>t.MeId==0);
      }
    },
    created(){
      this.$http.get("https://localhost:44356/api/MeunInfo/MeunListAll").then(res=>{
        this.MeunList = res.data;
      })
    },
    
  }
</script>

<style>
  .el-meun-vertical-demo{
    text-align: left;
    border-right: 0;
  }
  .el-header, .el-footer {
    background-color: #B3C0D1;
    color: #333;
    text-align: left;
    line-height: 60px;
    font-weight: bold;
  }
  
  .el-aside {
    background-color: #545c64;
    color: #333;
    text-align: center;
    line-height: 200px;
  }
  
  .el-main {
    background-color: #E9EEF3;
    color: #333;
    text-align: center;
    line-height: 60px;
    height: calc(100vh - 100px);
  }
  
  body > .el-container {
    margin-bottom: 40px;
  }
  
  .el-container:nth-child(5) .el-aside,
  .el-container:nth-child(6) .el-aside {
    line-height: 260px;
  }
  
  .el-container:nth-child(7) .el-aside {
    line-height: 320px;
  }
</style>