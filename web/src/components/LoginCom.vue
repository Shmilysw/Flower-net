<template>
    <el-dialog v-model="IsShowLogin" title="登录" width="30%" :before-close="handleClose">
        <el-form :model="form" label-width="100px">
            <el-form-item label="用户名">
                <el-input v-model="form.UserName" />
            </el-form-item>
            <el-form-item label="密码">
                <el-input v-model="form.Password" type="password" show-password />
            </el-form-item>
            <el-form-item label="验证码">
                <el-input v-model="form.ValidateCode" />
                <el-image style="width: 200px; height: 100px" :src="vaildImages" @click="ChangeImage" />
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="Submit">确定</el-button>
                <el-button @click="CloseLogin">取消</el-button>
            </el-form-item>
        </el-form>
    </el-dialog>
</template>
<script lang="ts" setup>
import { computed, ref } from "vue";
import { onMounted } from "vue";
import { useStore } from 'vuex'
import { getToken } from '../http/index'
import { ElMessage } from 'element-plus'
import { oriVaildImages, guid, FormatToken } from '../global/index'
const vaildImages = ref(oriVaildImages.value);
let ValidateKey = "";
//组件加载事件
onMounted(() => {
    const t = guid(); // 拿到 guid
    ValidateKey = t; // 给 t 给参数
    vaildImages.value = oriVaildImages.value + t;
});
//点击切换验证码事件
const ChangeImage = () => {
    const t = guid();
    ValidateKey = t;
    vaildImages.value = oriVaildImages.value + t;
}
//vuex
const store = useStore()
const IsShowLogin = computed(() => store.state.IsShowLogin)
const handleClose = (done: () => void) => { // 关闭对话框
    store.commit('CloseLogin')
    done();
};
const CloseLogin = () => {   // 取消对话框
    store.commit('CloseLogin')
}
const form = ref();
form.value = { // 默认输入框里面的内容
    // UserName: "shiwei",
    // Password: "071227shiwei",
    UserName: "yxc",
    Password: "123456",
}
const Submit = async () => {
    var data = {
        UserName: form.value.UserName,
        Password: form.value.Password,
        ValidateKey: ValidateKey,
        ValidateCode: form.value.ValidateCode,
    }
    console.log(data)
    var res = (await getToken(data)).data;
    if (res.isSuccess) {
        ElMessage({
            message: '登录成功！',
            type: 'success',
        })
        let user = JSON.parse(FormatToken(res.result)) // 解析taken，下面就可以读取里面的数据了
        console.log(user)
        localStorage["token"] = res.result;
        //设置全局变量的值
        store.commit('SettingNickName', user.NickName)
        //设置localStorage，保证页面刷新后vuex的值可以从里面读，避免刷新后状态丢失
        localStorage["NickName"] = user.NickName

        store.commit('SettingUserName', user.UserName)

        localStorage["UserName"] = user.UserName
        //登录成功后隐藏登录框
        store.commit('CloseLogin')
    } else {
        ElMessage.error(res.msg)
    }
}

</script>
<style lang="scss" ></style>