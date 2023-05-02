<template>
    <div>
        <el-row>
            <el-col :span="24">
                <ul class="head">
                    <li v-if="store.state.NickName == undefined" @click="OpenRegister">
                        <el-link :underline="false">注册</el-link>
                    </li>
                    <li v-if="store.state.NickName == undefined" @click="OpenLogin">
                        <el-link :underline="false">您好，请登录</el-link>
                    </li>
                    <li v-if="store.state.NickName != undefined" @click="LogOut">
                        <el-link :underline="false">注销</el-link>
                    </li>
                    <li v-if="store.state.NickName != undefined">
                        <el-link :underline="false" href="/shopcollect">
                            <el-icon :size="20" style="width: 1em; height: 1em; margin-right: 8px">
                                <Star />
                            </el-icon>
                            收藏
                        </el-link>
                    </li>
                    <li v-if="store.state.NickName != undefined">
                        <el-link :underline="false" href="/shopcar">
                            <el-icon :size="20" style="width: 1em; height: 1em; margin-right: 8px">
                                <ShoppingCart />
                            </el-icon>
                            购物车
                        </el-link>
                    </li>
                    <li v-if="store.state.NickName != undefined">
                        <el-link :underline="false" href="/ordercenter">
                            <el-icon :size="20" style="width: 1em; height: 1em; margin-right: 8px">
                                <List />
                            </el-icon>
                            个人订单
                        </el-link>
                    </li>
                    <li v-if="store.state.NickName != undefined">
                        <el-link :underline="false" href="/">
                            <el-icon :size="20" style="width: 1em; height: 1em; margin-right: 8px">
                                <Avatar />
                            </el-icon>
                            昵称: {{ store.state.NickName }}
                        </el-link>
                    </li>
                    <li v-if="store.state.NickName != undefined">
                        <el-link :underline="false" href="/">
                            <el-icon :size="20" style="width: 1em; height: 1em; margin-right: 8px">
                                <UserFilled />
                            </el-icon>
                            用户名: {{ store.state.UserName }}
                        </el-link>
                    </li>
                    <li>
                        <el-link :underline="false" href="/">
                            <el-icon :size="20" style="width: 1em; height: 1em; margin-right: 8px">
                                <HomeFilled />
                            </el-icon>
                            首页
                        </el-link>
                    </li>
                </ul>
            </el-col>
        </el-row>
        <el-row>
            <el-col :span="8">
                <el-link :underline="false" href="/">
                    <el-image style="width: 200px; height: 100px" src="https://img02.hua.com/pc/2021_image/big-logo.png"
                        fit="contain" />
                </el-link>
            </el-col>
            <el-col :span="8">
                <el-input class="w-50 m-2" style="margin-top: 30px" size="large" placeholder="商品搜索">
                    <template #append>
                        <el-button type="primary" :icon="Search"></el-button>
                    </template>
                </el-input>
            </el-col>
            <el-col :span="8">

                <div class="service serviceVip">
                    <div class="service-item phone-400" style="">
                        <a id="header-chat" href="">
                            <span class="icon icon-phone"></span>
                            <span class="service-item-info">400-889-8188</span>
                        </a>
                    </div>
                    <div class="service-item">
                        <a id="header-chat" href="">
                            <span class="icon icon-headset"></span>
                            <span class="service-item-info">在线客服</span>
                        </a>
                    </div>
                </div>
            </el-col>
        </el-row>
        <el-row>
            <el-col :span="24">
                <!--导航栏, 使用router, index就是路径 -->
                <el-menu :default-active="activeIndex" class="el-menu-header" mode="horizontal" router>
                    <el-menu-item index="/">首页</el-menu-item>
                    <el-menu-item index="/loveflower">爱情鲜花</el-menu-item>
                    <el-menu-item index="/birthdayflower">生日鲜花</el-menu-item>
                    <el-menu-item index="/friendflower">友情鲜花</el-menu-item>
                    <el-menu-item index="/weddingflower">婚庆鲜花</el-menu-item>
                </el-menu>
            </el-col>
        </el-row>
    </div>
    <LoginCom />
    <RegisterCom />
</template>
<script setup>
import LoginCom from "./LoginCom.vue";
import RegisterCom from "./RegisterCom.vue";
import { useStore } from 'vuex'
import { Search } from '@element-plus/icons-vue'

const store = useStore()
const OpenLogin = () => {
    store.commit('OpenLogin')
}
const OpenRegister = () => {
    store.commit('OpenRegister')
}
const LogOut = () => {
    //点击注销，清空状态
    //清理vuex状态 //清理localStorage
    localStorage.removeItem('NickName');
    localStorage.removeItem('UserName');
    localStorage.removeItem('token');
    store.commit('SettingNickName', undefined)
    store.commit('SettingUserName', undefined)
}
</script>
<style lang="scss" scoped>
ul {
    .head {
        list-style: none;
        padding-left: 65%;
    }

    list-style: none;

    li {
        float: right;
        margin-right: 50px;
    }
}

.service-item {
    display: inline-block;
    font-size: 14px;
    color: #71797f;
    vertical-align: top;
    line-height: 47px;
    margin-top: 12px;
    margin-right: 80px;

    a {
        text-decoration: none;
        color: inherit;
    }

    .icon-headset {
        background-position: -34px -102px;
        width: 24px;
        height: 24px;
        margin-top: 25px;
        margin-right: 8px;
        display: inline-block;
        background-image: url(//localhost:8080/images/common_sprite.png);
        background-repeat: no-repeat;
        vertical-align: top;
    }

    .icon-phone {
        background-position: 0px -102px;
        width: 24px;
        height: 24px;
        margin-top: 25px;
        margin-right: 8px;
        display: inline-block;
        background-image: url(//localhost:8080/images/common_sprite.png);
        background-repeat: no-repeat;
        vertical-align: top;
    }

    .service-item-info {
        margin-top: 15px;
        display: inline-block;
        background-repeat: no-repeat;
        vertical-align: top;
    }
}

.el-menu-header {

    margin-left: 20% !important;
    border-bottom: 0px !important;

    .el-menu-item {
        width: 170px !important;
    }
}

.el-row {
    margin-bottom: 20px;
}

.el-row:last-child {
    margin-bottom: 0;
}

.el-col {
    border-radius: 4px;
}

.grid-content {
    border-radius: 4px;
    min-height: 36px;
}
</style>