<template>
    <div class="common-layout">
        <el-container>
            <el-header>
                <p>购物车</p>
            </el-header>
            <el-main>
                <div class="main">
                    <el-image style="display:inherit;width: 1048px;margin-top: -20px;" :src="image"></el-image>
                    <div class="grid-wrapper">
                        <!-- 读取数据库里的数据循环显示到页面上 -->
                        <div class="grid-item" v-for="item in list" :key="item">
                            <div class="grid-panel">
                                <el-link>
                                    <div class="img-box">
                                        <el-image class="list-image" :src="item.image" @click="GoToDetail(item.id)">
                                        </el-image>
                                    </div>
                                </el-link>
                                <div class="info-cont">
                                    <div class="price">
                                        <span class="price-sign">¥ </span>
                                        <span class="price-num">{{ item.price }}</span>
                                    </div>
                                    <div class="title">
                                        <span class="product-title">{{ item.title }}</span>
                                    </div>
                                    <!-- <div class="title">
                                        <span class="product-title">{{ item.id }}</span>
                                    </div> -->
                                    <el-button @click="Delete(item.id)" type="info" round>删除商品</el-button>
                                    <!-- <el-button type="danger" round @click="goToPay(item.id, item.type)">立即购买</el-button> -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </el-main>
        </el-container>
    </div>
</template>

<script lang="ts" setup>
import { getShop } from '../http/index'
import { ref, onMounted } from 'vue'
import { defineProps } from 'vue' // 接收参数
import { useRouter } from 'vue-router'
import { ElMessage } from 'element-plus';
import { DeleteShop } from '../http/index'
import store from '@/vuex/store'
const router = useRouter();
const props = defineProps({ // 接收参数
    id: Number,
    image: String, // 页面的大图（放前端了）
    type: Number, // type 表明是那种类型花，数据库里也有
})
const list = ref();
onMounted(async () => {
    let parms = {
        Id: 0,
        Type: props.type
    }
    list.value = (await getShop(parms)).data.result
})
const GoToDetail = (currId: Number) => {
    const sss = ref()
    sss.value = currId;
    //console.log(sss.value)
    router.push({ path: '/detail', query: { id: sss.value, type: props.type } });
}

const Delete = async (_id: Number) => {
    try {
        var data = {
            Id: _id
        }
        //console.log(data.Id)
        let res = (await DeleteShop(data)).data
        console.log(res)
        if (res.isSuccess) {
            ElMessage({
                message: '删除商品成功！',
                type: 'success',
            })
            //重新获取一遍数据
            let parms = {
                Id: 0,
                Type: props.type
            }
            list.value = (await getShop(parms)).data.result
            //location.reload()
        } else {
            ElMessage.error("创建订单失败，请联系系统管理员！")
        }
    } catch (error) {
        localStorage.removeItem('NickName');
        localStorage.removeItem('UserName');
        localStorage.removeItem('token');
        store.commit('SettingNickName', undefined)
        store.commit('SettingUserName', undefined)
        ElMessage.warning("请登录后刷新列表")
    }
}
// let parms = {
//     Id: 0,
//     Type: 0,
//     //Place: "",
// }

// const goToPay = async (_id: number, _type: number) => {
//     //console.log(textarea.value)
//     parms.Id = _id
//     parms.Type = _type
//     router.push({ path: '/pay', query: { id: parms.Id, type: parms.Type } });
// }

</script>

<style lang="scss" scoped>
.common-layout {
    padding-left: 0;
}

.main {
    width: 900px;
    height: 500px;
    margin: 0px auto;
}

.grid-wrapper {
    width: 1048px;

    .grid-item {
        float: left;
        margin-bottom: 20px;
        padding: 10px;
        border: 1px solid transparent;
        background-color: #fff;

        .list-image {
            width: 200px;
            height: 255px;
        }

        .info-cont {
            .price {
                text-align: initial;
                margin-top: 10px;
                margin-bottom: 8px;
                color: #ff6a00;

                .price-sign {
                    font-family: arial;
                }

                .price-num {
                    font-weight: 700;
                    line-height: 18px;
                    margin-right: 10px;
                }
            }

            .title {
                font-size: 12px;
                line-height: 18px;
                overflow: hidden;
                height: 36px;
                margin-bottom: 8px;
                text-align: justify;

                a {
                    color: #737373;
                    text-decoration: none;
                }
            }
        }
    }
}
</style>