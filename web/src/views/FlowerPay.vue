<template>
    <div class="common-layout">
        <el-container>
            <el-header>
                <p>请扫码支付</p>
            </el-header>
            <el-main>
                <el-image style="display: block;width: 300px;margin:0px auto" src="/images/pay/测试二维码.png" />
                <el-row style="text-align: center">
                    <el-col>
                        <el-form :label-position="labelPosition" label-width="100px" :model="formLabelAlign"
                            style="display: inline-block">
                            <el-form-item label="收货人">
                                <el-input v-model="formLabelAlign.name" style="width: 400px" placeholder="请输入收货人姓名" />
                            </el-form-item>
                            <el-form-item label="手机号码">
                                <el-input v-model="formLabelAlign.number" style="width: 400px" placeholder="请输入收货人手机号码" />
                            </el-form-item>
                            <el-form-item label="收货地址">
                                <el-input v-model="formLabelAlign.place" style="width: 400px" placeholder="请输入详细的收货地点" />
                            </el-form-item>
                        </el-form>
                    </el-col>
                </el-row>
                <div style="margin: 20px" />
                <span>
                    <el-button type="warning" round @click="goToPay">模拟支付</el-button>
                </span>
            </el-main>
        </el-container>
    </div>
</template> 
<script lang="ts" setup>
import { CreateOrder } from '../http/index'
import { ElMessage } from 'element-plus'
import { useRouter } from 'vue-router'
import { useStore } from 'vuex'
import { ref } from 'vue'
import { reactive } from 'vue'

const labelPosition = ref('top')

const formLabelAlign = reactive({
    name: '',
    number: '',
    place: '',
})
// const textarea = ref('')
// const textname = ref('')
// const textnumber = ref('')
const store = useStore();
const router = useRouter();
let urls = window.location.href.match(/id=(\S*)&type=/);
//let urlt = window.location.href.match(/type=(\S*)&Place=/);
let parms = {
    Id: 0,
    Type: window.location.href.split('type=')[1],
    Name: "",
    Number: "",
    Place: "",
}
if (urls != null) {
    parms.Id = parseInt(urls[1])
}
const goToPay = async () => {
    //console.log(parms.Place)
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
</script>
<!-- <style>标签添加scope属性后，不同组件间的css不会相互影响。 -->
<style lang="scss" scoped>
.common-layout {
    padding-left: 0;
}
</style>