<template>
    <!-- 从后端变量里读取轮播图的实现 -->
    <div>
        <!-- 轮播图效果会比图片渲染快，所以添加v-if来控制 -->
        <el-carousel height="180px" v-if="isShow">
            <el-carousel-item v-for="item in images" :key="item">
                <el-link :href="item.courseUrl" target="_blank">
                    <el-image :src="item.imageUrl"></el-image>
                </el-link>
            </el-carousel-item>
        </el-carousel>
    </div>
    <HomeContent />
</template>

<script lang="ts" setup>// 每次忘写 setup 
import { ref } from 'vue'
import { onMounted } from 'vue'
import { getBanners2 } from '../http/index'
import HomeContent from '../components/HomeContent.vue' // 导入组件不用括号
const images = ref(); // 定义响应式变量
const isShow = ref(false);

onMounted(async () => {
    // console.log(await getBanners2())
    images.value = (await getBanners2()).data
    isShow.value = true
})
// images.value = [ // 对象数组
//     {
//         "imageUrl": "/images/banners/21_birthday_banner_pc.jpg",
//         "courseUrl": "http://localhost:8080/" // 跳转地址
//     },
//     {
//         "imageUrl": "/images/banners/21_brand_banner_pc.jpg",
//         "courseUrl": "http://localhost:8080/"
//     },
//     {
//         "imageUrl": "/images/banners/21_syz_banner_pc.jpg",
//         "courseUrl": "http://localhost:8080/"
//     }
// ]

</script>

<style lang="scss">
.el-carousel__container {
    // CSS 中的 !important 规则用于增加样式的权重，一般不使用，但这里为了适应element组件。
    height: 410px !important;
    margin-top: 10px;
}

// 页面html灰色
// html {
//     filter: grayscale(1);
// }
</style>