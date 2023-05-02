// 封装了验证码的一些方法
import { ref } from 'vue'
const RequestUrl = ref("/api");
const RequestJson = ref("/json");
const guid = () => {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}
const oriVaildImages = ref(RequestUrl.value + "/Login/GetValidateCodeImages?t="); // 这里的t要参数的，使用的时候加
// 使用这个方法就可以解析taken字符串，拿到里面的nickname
const FormatToken = (res: string) => {
    return decodeURIComponent(escape(window.atob(res.replace("-", "+").replace("_", "/").split('.')[1])));
}
export {
    RequestUrl, RequestJson, oriVaildImages, guid, FormatToken
}