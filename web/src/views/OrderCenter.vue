<template>
    <div class="common-layout">
        <el-container>
            <el-header>
                <h1>
                    <p>订单列表</p>
                </h1>
            </el-header>
            <el-main>
                <div class="main">
                    <el-table :data="list" height="500" stripe style="width: 100%">
                        <el-table-column prop="orderDate" label="订单日期" width="200" />
                        <el-table-column prop="orderNumber" label="订单号" width="200" />
                        <el-table-column prop="flowerTitle" label="商品标题" width="250" />
                        <el-table-column prop="price" label="价格" width="100" />
                        <el-table-column prop="orderUserName" label="收货人" width="100" />
                        <el-table-column prop="orderUserNumber" label="联系电话" width="200" />
                        <el-table-column prop="orderPlace" label="收获地址" width="300" />
                    </el-table>
                </div>
            </el-main>
        </el-container>
    </div>
</template>
<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { GetOrder } from '../http/index'
const list = ref();
onMounted(async () => {
    list.value = (await GetOrder())
    //console.log(list.value)
})
</script>
<style lang="scss" scoped>
.common-layout {
    // padding-left: 0;
    margin: 0px auto;
}

.main {
    width: 100%;
    height: 500px;
    margin: 0px auto;
}
</style>