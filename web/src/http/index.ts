import axios from "axios";
import { ref } from 'vue'
import instance from './filter'
// 获取首页Banner轮播图
const json = ref("/json")
const http = ref("http://localhost:5228/api")
// 前端代理的方式处理跨域问题
// const http = ref("/api")

// 这些都是后端传过来的一些请求，写成方法，方便调用！
// 获取首页Banner轮播图（这里是前端测试的时候使用）
export const getBanners = () => {
    return axios.get(json.value + "/banner.json")
}
// 获取首页Banner轮播图
export const getBanners2 = () => {
    return axios.get(http.value + "/Image/GetImages")
}
// 鲜花数据
export const getFlowers = (parms: {}) => {
    return axios.post(http.value + "/Flower/GetFlowers", parms);
}
// 购物车数据
export const getShop = (parms: {}) => {
    return axios.post(http.value + "/Shop/GetShop", parms);
}
// 添加一条信息到购物车
export const CreateShop = (parms: {}) => {
    //在header里携带token访问后端接口
    axios.defaults.headers.common['Authorization'] = "Bearer " + localStorage["token"]; // "Bearer"就是头部标示，后面的token就是携带的内容
    return axios.post(http.value + "/Shop/CreateShop", parms); // 这个路径就是后台方法的路径
}
// 删除购物车信息
export const DeleteShop = (parms: {}) => {
    return axios.post(http.value + "/Shop/DeleteShop", parms);
}
// 注册
export const Register = (parms: {}) => {
    return axios.post(http.value + "/Login/Register", parms);
}
// 登录获取Token
export const getToken = (parms: {}) => {
    return axios.post(http.value + "/Login/Check", parms);
}
// 生成一笔订单
export const CreateOrder = (parms: {}) => {
    //在header里携带token访问后端接口
    axios.defaults.headers.common['Authorization'] = "Bearer " + localStorage["token"]; // "Bearer"就是头部标示，后面的token就是携带的内容
    return axios.post(http.value + "/Order/CreateOrder", parms); // 这个路径就是后台方法的路径
}
// 获取订单列表
export const GetOrder = () => {
    //在header里携带token访问后端接口
    instance.defaults.headers.common['Authorization'] = "Bearer " + localStorage["token"];
    return instance.post(http.value + "/Order/GetOrder");
}