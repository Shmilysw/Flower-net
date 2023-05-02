// vuex 就是 vue 提供的状态管理
/*
    上面是状态 state ，下面是方法 mutations里 ，使用方法来操作管理状态
*/
import { createStore } from 'vuex'

const store = createStore({
    state() {
        return {
            IsShowLogin: false,
            IsShowRegister: false,
            NickName: localStorage["NickName"], //昵称，登录成功后赋值
            UserName: localStorage["UserName"],
        }
    },
    mutations: {
        // ts 对变量的类型要求比较严格，所以这里直接把传来的state指定为any类型
        OpenLogin(state: any) {
            state.IsShowLogin = true;
        },
        CloseLogin(state: any) {
            state.IsShowLogin = false;
        },
        OpenRegister(state: any) {
            state.IsShowRegister = true;
        },
        CloseRegister(state: any) {
            state.IsShowRegister = false;
        },
        SettingNickName(state: any, NickName) {
            state.NickName = NickName;
        },
        SettingUserName(state: any, UserName) {
            state.UserName = UserName;
        }
    }
})
export default store;