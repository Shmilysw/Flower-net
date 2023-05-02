<template>
    <!-- 通过组件的封装，实现页面效果的展示 -->
    <!-- 这里的tyed的参是在FlowerList.vue里面的参数，表明花的类型 -->
    <!-- 页面里的大图是放前端的，没有从后端数据库里面拿 -->
    <FlowerList :type=1 image="/images/theme/flower_bannerLove_190906.jpg" />
</template>
<script setup>
import FlowerList from '../components/FlowerList.vue'
</script>
<style lang="scss">

</style>