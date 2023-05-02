//导入axios
import axios from 'axios'  //引入axios
import { ElMessage } from 'element-plus'
//创建一个axios实例
const instance = axios.create({
    headers: {
        'content-type': 'application/x-www-form-urlencoded'
    },
    //withCredentials: true, // md 这个地方会导致跨域问题!
})

// http response 拦截器
instance.interceptors.response.use(
    response => {
        //拦截响应，做统一处理 
        // console.log("请求成功")
        if (response.data.isSuccess) {
            return response.data.result
        } else {
            ElMessage.error(response.data.msg)
            return response.data.result
        }
    },
    //接口错误状态处理，也就是说无响应时的处理
    error => {
        if (error.response) {
            switch (error.response.status) {
                case 401:
                    localStorage.removeItem('NickName');
                    localStorage.removeItem('token');
                    ElMessage.warning("登录已失效，请登录后刷新列表！")
                    break
                case 500:
                    ElMessage.warning("内部服务器错误，请联系系统管理员！")
                    break
                default:
                    return Promise.reject(error.response.data)   // 返回接口返回的错误信息 
            }
        }
    })
export default instance