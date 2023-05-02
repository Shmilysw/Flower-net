<template>
    <div class="common-layout">
        <el-container>
            <el-header>
                <el-breadcrumb separator="/">
                    <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
                    <el-breadcrumb-item>列表页</el-breadcrumb-item>
                </el-breadcrumb>
            </el-header>
            <el-container>
                <el-aside width="200px">
                    <div class="navigation">
                        <div class="item">
                            <div class="title">
                                <span class="ico ico-effect"></span>
                                <h4>用途</h4>
                            </div>
                            <ul class="item-list list-inline">
                                <li>
                                    <a href="/aiqingxianhua/">爱情鲜花</a>
                                </li>
                                <li>
                                    <a href="/youqingxianhua/">友情鲜花</a>
                                </li>
                                <li>
                                    <a href="/shengriliwu/" target="_blank">生日鲜花</a>
                                </li>
                                <li>
                                    <a href="/songzhangbeixianhua/">问候长辈</a>
                                </li>
                                <li>
                                    <a href="/songlaoshixianhua/">回报老师</a>
                                </li>
                                <li>
                                    <a href="/tanbingweiwenxianhua/">探病慰问</a>
                                </li>
                                <li>
                                    <a href="/daoqianxianhua/">道歉鲜花</a>
                                </li>
                                <li>
                                    <a href="/hunqingxianhua/">婚庆鲜花</a>
                                </li>
                                <li>
                                    <a href="/zhufuqinghexianhua/">祝贺鲜花</a>
                                </li>
                                <li>
                                    <a href="/aisixianhua/">哀思鲜花</a>
                                </li>
                                <li>
                                    <a href="/businessFlower/">商务鲜花</a>
                                </li>
                                <li>
                                    <a href="/businessFlower/kaiyehualan/">开业花篮</a>
                                </li>
                                <li>
                                    <a href="/florist/">自选鲜花</a>
                                </li>
                                <li>
                                    <a href="/worldflora/">港澳台送花</a>
                                </li>
                            </ul>
                        </div>
                        <div class="item">
                            <div class="title">
                                <span class="ico ico-texture"></span>
                                <h4>花材</h4>
                            </div>
                            <ul class="item-list list-inline">
                                <li><a href="/meigui/">玫瑰</a></li>
                                <li><a href="/hongmeigui/">红玫瑰</a></li>
                                <li><a href="/fenmeigui/">粉玫瑰</a></li>
                                <li><a href="/baimeigui/">白玫瑰</a></li>
                                <li><a href="/zimeigui/">紫玫瑰</a></li>

                                <li><a href="/xiangbinmeigui/">香槟玫瑰</a></li>
                                <li><a href="/huangmeigui/">黄玫瑰</a></li>
                                <li><a href="/kangnaixin/">康乃馨</a></li>
                                <li><a href="/baihe/">百合</a></li>
                                <li><a href="/fulang/">扶郎</a></li>
                                <li><a href="/xiangrikui/">向日葵</a></li>
                                <li><a href="/yujinxiang/">郁金香</a></li>
                                <li><a href="/matilian/">马蹄莲</a></li>
                            </ul>
                        </div>
                        <div class="item">
                            <div class="title">
                                <span class="ico ico-color"></span>
                                <h4>颜色</h4>
                            </div>
                            <ul class="item-list list-inline">
                                <li><a href="/hongsexianhua/"><span class="c-red"></span>红色</a></li>
                                <li><a href="/fensexianhua/"><span class="c-pink"></span>粉色</a></li>
                                <li><a href="/xiangbinsexianhua/"><span class="c-champagne"></span>香槟</a></li>
                                <li><a href="/huangsexianhua/"><span class="c-yellow"></span>黄色</a></li>
                                <li><a href="/baisexianhua/"><span class="c-white"></span>白色</a></li>
                                <li><a href="/zisexianhua/"><span class="c-purple"></span>紫色</a></li>
                                <li><a href="/lansexianhua/"><span class="c-blue"></span>蓝色</a></li>
                                <li><a href="/hongsexianhua/"><span class="c-red"></span>红色</a></li>
                                <li><a href="/fensexianhua/"><span class="c-pink"></span>粉色</a></li>
                                <li><a href="/xiangbinsexianhua/"><span class="c-champagne"></span>香槟</a></li>
                                <li><a href="/huangsexianhua/"><span class="c-yellow"></span>黄色</a></li>
                                <li><a href="/baisexianhua/"><span class="c-white"></span>白色</a></li>
                                <li><a href="/zisexianhua/"><span class="c-purple"></span>紫色</a></li>
                                <li><a href="/lansexianhua/"><span class="c-blue"></span>蓝色</a></li>
                            </ul>
                        </div>
                        <div class="item">
                            <div class="title">
                                <span class="ico ico-sort"></span>
                                <h4>类别</h4>
                            </div>
                            <ul class="item-list list-inline">
                                <li><a href="/huashu/">花束</a></li>
                                <li><a href="/hezhuanghua/">花盒</a></li>
                                <li><a href="/pingchahua/">瓶花</a></li>
                                <li><a href="/flower/JingPinXianHua/">精品鲜花</a></li>
                                <li><a href="/giftsBasket/">果篮</a></li>
                                <li><a href="/hualan/">桌面花篮</a></li>
                                <li><a href="/businessFlower/kaiyehualan/">开业花蓝</a></li>
                                <li><a href="/zuhexianhua/">组合鲜花</a></li>
                                <li><a href="/huashu/">花束</a></li>
                                <li><a href="/hezhuanghua/">花盒</a></li>
                                <li><a href="/pingchahua/">瓶花</a></li>
                                <li><a href="/flower/JingPinXianHua/">精品鲜花</a></li>
                                <li><a href="/giftsBasket/">果篮</a></li>
                                <li><a href="/hualan/">桌面花篮</a></li>
                            </ul>
                        </div>
                        <div class="item">
                            <div class="title">
                                <span class="ico ico-price"></span>
                                <h4>价格</h4>
                            </div>
                            <ul class="item-list list-inline">
                                <li><a href="/tejiaxianhua/">特价鲜花</a></li>
                                <li><a href="/xianhuajiage/0-150/">1元以下</a></li>
                                <li><a href="/xianhuajiage/150-250/">10-20元</a></li>
                                <li><a href="/xianhuajiage/250-350/">20-30元</a></li>
                                <li><a href="/xianhuajiage/350-550/">40-50元</a></li>
                                <li><a href="/xianhuajiage/550-800/">60-70元</a></li>
                                <li><a href="/xianhuajiage/800-99999/">80元以上</a></li>
                                <li><a href="/tejiaxianhua/">特价鲜花</a></li>
                                <li><a href="/xianhuajiage/0-150/">150元以下</a></li>
                                <li><a href="/xianhuajiage/150-250/">150-250元</a></li>
                                <li><a href="/xianhuajiage/250-350/">250-350元</a></li>
                                <li><a href="/xianhuajiage/350-550/">350-550元</a></li>
                                <li><a href="/xianhuajiage/550-800/">550-800元</a></li>
                                <li><a href="/xianhuajiage/800-99999/">800元以上</a></li>
                            </ul>
                        </div>
                        <div class="item">
                            <div class="title">
                                <span class="ico ico-num"></span>
                                <h4>枝数</h4>
                            </div>
                            <ul class="item-list list-special list-inline">
                                <li><a href="/jiuduomeigui/">6枝</a></li>
                                <li><a href="/shiduomeigui/">9枝</a></li>
                                <li><a href="/shiyiduomeigui/">11枝</a></li>
                                <li><a href="/shierduomeigui/">12枝</a></li>
                                <li><a href="/shiliuduomeigui/">16枝</a></li>
                                <li><a href="/shibaduomeigui/">18枝</a></li>
                                <li><a href="/shijiuduomeigui/">19枝</a></li>
                                <li><a href="/ershiduomeigui/">20枝</a></li>
                                <li><a href="/sanshisanduomeigui/">33枝</a></li>
                                <li><a href="/sanshiliuduomeigui/">36枝</a></li>
                                <li><a href="/wushiduomeigui/">50枝</a></li>
                                <li><a href="/liushiliuduomeigui/">66枝</a></li>
                                <li><a href="/jiushijiuduomeigui/">99枝</a></li>
                                <li><a href="/jiushijiuduomeigui/">99枝以上</a></li>
                            </ul>
                        </div>
                    </div>
                </el-aside>
                <el-main>
                    <el-image style="display:inherit;width: 1048px;margin-top: -20px;" :src="image"></el-image>
                    <div class="grid-wrapper">
                        <!-- 读取数据库里的数据循环显示到页面上 -->
                        <div class="grid-item" v-for="item in list" :key="item">
                            <el-link @click="GoToDetail(item.id, item.type)">
                                <div class="grid-panel">
                                    <div class="img-box">
                                        <el-image class="list-image" :src="item.image"></el-image>
                                    </div>
                                    <div class="info-cont">
                                        <div class="price">
                                            <span class="price-sign">¥ </span>
                                            <span class="price-num">{{ item.price }}</span>
                                        </div>
                                        <div class="title">
                                            <span class="product-title">{{ item.title }}</span>
                                        </div>
                                    </div>
                                </div>
                            </el-link>
                        </div>
                    </div>
                </el-main>
            </el-container>
        </el-container>
    </div>
</template>
<script lang="ts" setup>
import { getFlowers } from '../http/index'
import { ref, onMounted } from 'vue'
import { defineProps } from 'vue' // 接收参数
import { useRouter } from 'vue-router'
const router = useRouter();
const props = defineProps({ // 接收参数
    image: String, // 页面的大图（放前端了）
    type: Number, // tyed 表明是那种花，数据库里也有
})
const list = ref();
onMounted(async () => {
    let parms = {
        Id: 0,
        Type: props.type
    }
    list.value = (await getFlowers(parms)).data.result
})
const GoToDetail = (currId: number, _type: number) => {
    const sss = ref()
    const sst = ref()
    sss.value = currId
    sst.value = _type
    // console.log(sss.value)
    // console.log(sst.value)
    router.push({ path: '/detail', query: { id: sss.value, type: sst.value } });
}
</script>
<style lang="scss" scoped>
.common-layout {
    padding-left: 8%;
    // padding: auto;
    background-color: #f7f9fa;
}

.el-breadcrumb {
    margin-top: 20px;
}

.ico-flower,
.ico-ysh,
.ico-Plant,
.ico-effect,
.ico-texture,
.ico-sort,
.ico-sort-gift,
.ico-price,
.ico-color,
.ico-num,
.ico-city,
.ico-brand {
    width: 30px;
    height: 40px;
    background-image: url(//localhost:8080/images/common_z.png);
    display: block;
    background-repeat: no-repeat;
}

.navigation {
    margin-bottom: 20px;
    padding: 0 9px;
    border: 1px solid #ccc;

    .item {
        position: relative;
        padding: 12px 0;
        height: 175px;
        border-bottom: 1px solid #d9d9d9;

        .title {
            position: absolute;
            width: 32px;
            margin-top: 50px;
            text-align: center;

            .ico-effect {
                background-position: -160px -234px;
            }

            .ico-texture {
                background-position: -120px -234px;
            }

            .ico-color {
                background-position: 0px -234px;
            }

            .ico-sort {
                background-position: -80px -234px;
            }

            .ico-price {
                background-position: -40px -234px;
            }

            .ico-num {
                background-position: -200px -234px;
            }

            h4 {
                font-family: tahoma, arial, "Hiragino Sans GB", "\5FAE\8F6F\96C5\9ED1",
                    sans-serif;
                font-size: 14px;
                font-weight: bold;
                margin: 0;
                color: #ff6a00;
            }
        }

        .item-list {
            margin-bottom: 0;
            margin-left: 50px;
            padding-left: 0;
            list-style: none;

            li {
                font-size: 12px;
                line-height: 22px;
                width: 50%;
                margin: 0;
                margin-right: -3px;
                padding: 0;

                a {
                    color: #737373;
                    text-decoration: none;
                }
            }
        }
    }
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
            width: 240px;
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

ul {
    list-style: none;
    padding-left: 80%;

    li {
        float: left;
        margin-left: 20px;
    }
}
</style>