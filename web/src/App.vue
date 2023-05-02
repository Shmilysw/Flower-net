<template>
    <HeaderCom />
    <router-view></router-view>
    <FooterCom />
</template>

<script lang="ts" setup>
import HeaderCom from "./components/HeaderCom.vue";
import FooterCom from "./components/FooterCom.vue";
</script>

<style lang="scss">
// 添加scss是为了写css方便一点
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
}
</style>
