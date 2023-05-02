<template>
    <div class="common-layout" v-if="isShow">
        <el-container>
            <!-- 面包屑的使用 -->
            <el-header>
                <el-breadcrumb separator="/">
                    <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
                    <el-breadcrumb-item :to="{ path: path }">列表页</el-breadcrumb-item>
                    <el-breadcrumb-item>详情页</el-breadcrumb-item>
                </el-breadcrumb>
            </el-header>
            <el-container>
                <el-aside width="500px">
                    <el-image class="bigImage" :src="info.bigImage"></el-image>
                </el-aside>
                <el-main>
                    <ul class="product-info">
                        <li>
                            <h3>{{ info.title }}</h3>
                        </li>
                        <li>
                            <span>{{ info.description }}</span>
                        </li>
                        <li>
                            <span class="left">售价</span>
                            <span class="right" style="color:red;font-size:25px;">￥{{ info.price }}</span>
                        </li>
                        <li>
                            <span class="left">花语</span>
                            <span class="right">{{ info.language }}</span>
                        </li>
                        <li>
                            <span class="left">材料</span>
                            <span class="right">{{ info.material }}</span>
                        </li>
                        <li style="border-bottom:1px solid #e7ebef;">
                            <span class="left">包装</span>
                            <span class="right">{{ info.packing }}</span>
                        </li>
                        <li>
                            <span class="left">配送说明</span>
                            <span class="right">{{ info.deliveryRemarks }}</span>
                        </li>
                    </ul>
                    <el-button type="warning" round @click="goToShopCollect">
                        添加到收藏
                    </el-button>
                    <el-button type="danger" round @click="goToPay">立即购买</el-button>
                    <el-button type="danger" round @click="dialogFormVisible = true">
                        弹窗购买
                    </el-button>
                    <el-dialog v-model="dialogFormVisible" title="收获地址">
                        <el-form :model="formLabelAlign">
                            <el-form-item label="收货人姓名：" :label-width="formLabelWidth">
                                <el-input v-model="formLabelAlign.name" />
                            </el-form-item>
                            <el-form-item label="收货人电话：" :label-width="formLabelWidth">
                                <el-input v-model="formLabelAlign.number" />
                            </el-form-item>
                            <el-form-item label="收货人地址：" :label-width="formLabelWidth">
                                <el-input v-model="formLabelAlign.place" />
                            </el-form-item>
                        </el-form>
                        <template #footer>
                            <span class="dialog-footer">
                                <el-button @click="dialogFormVisible = false">取消</el-button>
                                <el-button type="danger" @click="GoToPay">
                                    购买
                                </el-button>
                            </span>
                        </template>
                    </el-dialog>
                </el-main>
            </el-container>
        </el-container>
        <el-container>
            <el-aside width="240px">
                <h5 style="margin-top: 83px;">热销推荐</h5>
                <ul class="product-recommend">
                    <li>
                        <el-image src="/images/content/a1.jpg"></el-image>
                        <p>韩式系列/公主的假日</p>
                        <p>￥239</p>
                    </li>
                    <li>
                        <el-image src="/images/content/a2.jpg"></el-image>
                        <p>百事合意/粉玫瑰香水百合大号</p>
                        <p>￥99</p>
                    </li>
                    <li>
                        <el-image src="/images/content/a3.jpg"></el-image>
                        <p>忘情巴黎</p>
                        <p>￥338</p>
                    </li>
                    <li>
                        <el-image src="/images/content/a4.jpg"></el-image>
                        <p>深情挚爱/52枝</p>
                        <p>￥399</p>
                    </li>
                    <li>
                        <el-image src="/images/content/a5.jpg"></el-image>
                        <p>恋恋情深</p>
                        <p>￥218</p>
                    </li>
                    <li>
                        <el-image src="/images/content/a6.jpg"></el-image>
                        <p>一往情深</p>
                        <p>￥256</p>
                    </li>
                    <li>
                        <el-image src="/images/content/a7.jpg"></el-image>
                        <p>韩式系列/亲爱的你</p>
                        <p>￥398</p>
                    </li>
                    <li>
                        <el-image src="/images/content/a8.jpg"></el-image>
                        <p>韩式系列/你笑起来真好看</p>
                        <p>￥298</p>
                    </li>
                </ul>
            </el-aside>
            <el-main>
                <div class="product-content">
                    <h3>商品详情</h3>
                    <el-image src="/images/detail/content/by_1.jpg"></el-image>
                    <el-image src="/images/detail/content/by_2.jpg"></el-image>
                    <el-image src="/images/detail/content/by_3.jpg"></el-image>
                    <el-image src="/images/detail/content/by_4.jpg"></el-image>
                    <el-image src="/images/detail/content/by_6.jpg"></el-image>
                    <el-image src="/images/detail/content/by_7.jpg"></el-image>
                </div>
            </el-main>
        </el-container>
    </div>
</template>
<script lang="ts" setup>
import { reactive, ref } from 'vue'
import { onMounted } from 'vue'
import { CreateOrder, getFlowers } from '../http/index'
import { useRouter } from 'vue-router'
import { useStore } from 'vuex'
import { CreateShop } from '../http/index'
// import { getToken } from '../http/index'
import { ElMessage } from 'element-plus'
import { FormatToken } from '@/global'

// 购买弹窗
const dialogFormVisible = ref(false)
const formLabelWidth = '140px'
const formLabelAlign = reactive({
    name: '',
    number: '',
    place: '',
})

const store = useStore();
let urls = window.location.href.match(/id=(\S*)&type=/);
//let urlt = window.location.href.match(/type=(\S*)&Place=/);
let Parms = {
    Id: 0,
    Type: window.location.href.split('type=')[1],
    Name: "",
    Number: "",
    Place: "",
}
if (urls != null) {
    Parms.Id = parseInt(urls[1])
}
const GoToPay = async () => {
    //console.log(Parms.Place)
    //验证登录信息
    if (localStorage["NickName"] == undefined) {
        ElMessage.warning("请登录后再点击购买！")
        return;
    }
    if (formLabelAlign.name === '') {
        ElMessage.warning("创建订单失败，请填写签收人！")
        return;
    }
    if (formLabelAlign.number === '') {
        ElMessage.warning("创建订单失败，请填写联系电话！")
    }
    if (formLabelAlign.number != '') {
        let length_ = formLabelAlign.number.length
        console.log(length_)
        if (length_ !== 11) {
            ElMessage.warning("创建订单失败，请填写正确的联系电话！")
            return;
        }
        for (let i = 0; i < length_; i++) {
            if (formLabelAlign.number[i] >= '0' && formLabelAlign.number[i] <= '9') {
                continue;
            } else {
                ElMessage.warning("创建订单失败，请填写正确的联系电话！")
                return;
            }
        }
    }
    if (formLabelAlign.place.trim() == '') { // trim 是去掉字符串头和尾的空格
        ElMessage.warning("创建订单失败，请填写收货地址！")
        return;
    }
    //根据当前的用户信息，产品信息生成一笔订单
    try {
        var data = {
            FlowerId: parms.Id,
            OrderUserName: formLabelAlign.name,
            OrderUserNumber: formLabelAlign.number,
            OrderPlace: formLabelAlign.place,
        }
        let res = (await CreateOrder(data)).data
        //console.log(res)
        if (res.isSuccess) {
            ElMessage({
                message: '创建订单成功！',
                type: 'success',
            })
            router.push({ path: '/ordercenter' });
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

const path = ref('/loveflower');
// 解析URL参数，在地址栏拿取参数 // 字符串切割
let type = window.location.href.split('type=')[1];
// 这里就是面包屑的一些返回路径
switch (type) {
    case "1":
        path.value = '/loveflower'
        break;
    case "2":
        path.value = '/birthdayflower'
        break;
    case "3":
        path.value = '/friendflower'
        break;
    case "4":
        path.value = '/weddingflower'
        break;
}
// 这里 isShow 是后端请求数据还没有到页面，但是页面已经加载完了，
// 如果不判断限制一下，就会报属性未找到错，重要的呀！
const isShow = ref(false)
const info = ref()

let parms = {
    Id: 0,
    UserId: 0,
    ProductId: 0,
    Type: type,
    //Place: "",
}
onMounted(async () => {
    // 正则表达式取 Id 
    let urls = window.location.href.match(/id=(\S*)&type=/);
    if (urls != null) {
        parms.ProductId = parseInt(urls[1])
        parms.Id = parseInt(urls[1])
    }
    info.value = (await getFlowers(parms)).data.result[0]
    isShow.value = true
})
// 获取登录信息
var res = localStorage["token"] // 获取当前登录的token，然后解析出来，获取当前用户
// console.log(res)
let userid = JSON.parse(FormatToken(res)).Id
// console.log(userid)
parms.UserId = userid

const router = useRouter();
// 面包屑的使用
const goToPay = async () => {
    //console.log(textarea.value)
    router.push({ path: '/pay', query: { id: parms.Id, type: parms.Type } });
}


const goToShopCollect = async () => {
    //console.log(textarea.value)
    //router.push({ path: '/shopcar', query: { id: parms.Id, type: parms.Type } });

    if (localStorage["NickName"] == undefined) {
        ElMessage.warning("请登录后再点击添加购物车！")
        return;
    }
    // 添加到收藏!
    try {
        var data = {
            Id: parms.Id,
            UserId: parms.UserId,
            ProductId: parms.ProductId,
            Type: parms.Type,
        }
        console.log(data)
        let res = (await CreateShop(data)).data
        console.log(res)
        if (res.isSuccess) {
            ElMessage({
                message: '添加到收藏成功！',
                type: 'success',
            })
            //router.push({ path: '/personcenter' });
        } else {
            ElMessage.warning("您已经收藏，无需再次添加！")
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

</script>

<style lang="scss" scope>
.el-button--text {
    margin: 0px auto;
}

.el-select {
    width: 300px;
    margin: 0px auto;
}

.el-input {
    width: 300px;
}

.el-from {
    margin: 0px auto !important;
}

.dialog-footer button:first-child {
    margin: 0px auto;
}

.common-layout {
    padding-left: 8%;
    // padding: auto;
    background-color: #f7f9fa;
}

.bigImage {
    width: 458px;
    height: 500px;
}

.product-info {
    padding-left: 0;
    margin-top: -20px;
    text-align: initial;

    li {
        list-style: none;
        width: 100%;
        height: 30px;
        margin-bottom: 20px;

        .left {
            display: inline-block;
            width: 80px;
            padding-left: 12px;
            font-size: 13px;
            line-height: 18px;
            color: #71797f;
            vertical-align: top;
        }

        .right {
            display: inline-block;
            width: 580px;
            font-size: 13px;
            line-height: 18px;
            color: #232628;
            vertical-align: top;
            text-align: justify;
            padding-right: 36px;
        }
    }
}

.product-recommend {
    padding-left: initial;
}

.product-content {
    padding: 40px 115px 95px;
    text-align: center;
}

.place {
    width: 500px;
    height: 24px;
}
</style>