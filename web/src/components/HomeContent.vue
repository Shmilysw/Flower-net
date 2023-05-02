<template>
    <div class="common-layout">
        <el-container>
            <el-header>
                <div class="hd">
                    <a class="more" href="/loveflower">
                        <span>查看更多鲜花</span>
                        <span class="icon icon-arrow-right"></span>
                    </a>
                    <h3>
                        <a href="/loveflower">鲜花展示</a>
                        <span>送 · 让你怦然心动的人</span>
                    </h3>
                </div>
            </el-header>
            <el-container>
                <el-aside width="300px">
                    <el-image style="margin-top: 20px" src="/images/content/home_floor_lover.png"></el-image>
                </el-aside>
                <el-main>
                    <div class="grid-wrapper">
                        <!-- 读取数据库里的数据循环显示到页面上 -->
                        <div class="grid-item" v-for="item in list" :key="item">
                            <el-link>
                                <div class="grid-panel">
                                    <el-tooltip placement="top">
                                        <template #content> {{ item.description }} </template>
                                        <div class="img-box">
                                            <el-image class="list-image" :src="item.image"></el-image>
                                        </div>
                                    </el-tooltip>
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
</script>

<style lang="scss" scoped>
.common-layout {
    padding-left: 8%;
    // padding: auto;
    background-color: #f7f9fa;
}

.more {
    text-decoration: none; // 取消下划线
    font-size: 14px;
    line-height: 30px;
    color: #71797f;
    float: right;
    margin-right: 26%;
}


.hd {
    text-align: initial;

    h3 {
        font-size: 26px;
        line-height: 30px;
        color: #232628;
        font-weight: bold;

        a {
            color: inherit;
            text-decoration: none; // 取消下划线
        }

        span {
            padding-left: 15px;
            margin-left: 16px;
            font-size: 20px;
            line-height: 24px;
            font-weight: normal;
            border-left: 1px solid #71797f;
        }
    }
}

.fl-products {
    width: 912px;
    vertical-align: top;

    .fl-products-item {
        display: inline-block;
        width: 212px;
        margin-left: 16px;
        margin-bottom: 16px;
        background-color: #fff;
        vertical-align: top;

        .product-content {
            padding: 10px 8px 14px;
            text-align: center;
            color: #232628;

            .product-title {
                max-width: 100%;
                overflow: hidden;
                -o-text-overflow: ellipsis;
                text-overflow: ellipsis;
                white-space: nowrap;
                font-size: 16px;
                line-height: 20px;
            }

            .product-price {
                margin-top: 5px;
                font-size: 16px;
                font-weight: bold;
                line-height: 20px;
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
</style>