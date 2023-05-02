<template>
    <div class="common-layout">
        <el-container>
            <el-header>
                <h1>
                    <p>我的购物车</p>
                </h1>
            </el-header>
            <el-main>
                <div class="main">
                    <el-table :data="tableData" style="width: 100%">
                        <el-table-column prop="All" label="全选" width="55px" />
                        <el-table-column type="selection" width="80px" />
                        <el-table-column prop="Product" label="商品图片" width="150px">
                            <div class="img-box">
                                <el-image class="list-image" style="width: 100px; height: 100px"
                                    src="https://img02.hua.com/pc/2021_image/big-logo.png" fit="contain">
                                </el-image>
                            </div>
                        </el-table-column>
                        <el-table-column prop="name" label="商品名称" style="width: 150px" />
                        <el-table-column prop="price" label="单价" style="width: 180px" />
                        <el-table-column prop="count" label="数量" style="width: 180px">
                            <!-- 使用计数器来添加数量，绑定表格数据行对应的count -->
                            <!-- <div>
                                <el-button @click="--"> - </el-button>
                                {{ }}
                                <el-button @click="++"> + </el-button>
                            </div> -->
                        </el-table-column>
                        <el-table-column prop="total" label="小计" style="width: 180px" />
                        <el-table-column prop="operation" label="操作" style="width: 180px">
                            <el-button type="danger" :icon="Delete" circle />
                            <el-button type="success" :icon="Check" circle />
                        </el-table-column>
                    </el-table>
                </div>
            </el-main>
        </el-container>
    </div>
</template>

<script lang="ts" setup>
import { Delete } from '@element-plus/icons-vue';
import { Check } from '@element-plus/icons-vue';
// import { ref } from 'vue'


let tableData = [
    {
        id: 1,
        checkbox: true,
        name: '花',
        title: '2016-05-03',
        price: 1,
        count: 1,
        total: 1000,
        operation: '删除',
    },
    {
        id: 2,
        checkbox: true,
        name: '花',
        title: '2016-05-02',
        price: 2,
        count: 1,
        total: 1000,
        operation: '删除',
    },
    {
        id: 3,
        checkbox: true,
        name: '花',
        title: '2016 -05-04',
        price: 3,
        count: 1,
        total: 1000,
        operation: '删除',
    },
    {
        id: 4,
        checkbox: true,
        name: '花',
        title: '2016-05-01',
        price: 4,
        count: 1,
        total: 1000,
        operation: '删除',
    },
    {
        id: 5,
        checkbox: true,
        name: '花',
        title: '2016-05-01',
        price: 5,
        count: 1,
        total: 1000,
        operation: '删除',
    },
]
</script>

<style lang="scss" scoped>
.common-layout {
    margin: 0px auto;
}

.main {
    width: 100%;
    height: 800px;
    margin: 0px auto;
}

p {
    margin: 0;
    padding: 0;
}

.shopCart {
    padding-top: 30px;
    width: 1200px;
    margin: 0 auto;
    height: calc(100% - 30px);

    .shopHead {
        height: 40px;
        background: #F8F8F8;
        line-height: 40px;
        padding: 0 20px;

        .colSpan {
            text-align: center;
        }
    }

    .cloudt-layout-row {
        row-gap: 0px;
        margin: 10px 0;
    }

    .shopMessage {
        padding: 0 20px;
    }

    .checkboxStyle {
        display: flex;
        align-items: center;
    }

    .company {
        line-height: 60px;
    }

    .shopMsg {
        display: flex;
        width: 80px;
        height: 80px;
    }

    .imgStyle {
        // width: 50px;
        // height: 50px;
        width: 80px;
        height: 80px;
        object-fit: contain;
    }

    .ShopDiv {
        width: calc(100% - 100px);
        margin-left: 20px;

        .pSpan {
            font-size: 12px;
            color: #999999;
            line-height: 20px;
            font-weight: 400;
            padding: 5px;
        }
    }

    .itemCol {
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: 12px;
        line-height: 20px;
        font-weight: 600;
    }

    .shopFooter {
        height: 40px;
        background: #F8F8F8;
        line-height: 40px;
        padding: 0px 20px;
        margin-top: 10px;

        .colSpan {
            text-align: center;
        }
    }
}
</style>
