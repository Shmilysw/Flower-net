import { createApp } from 'vue'
import App from './App.vue'
// 引入 element-plus 
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
// 导入路由(访问的页面位置)
import router from './routes'
// 导入(状态)
import store from './vuex/store'

import * as ElementPlusIconsVue from '@element-plus/icons-vue'

const app = createApp(App)
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
}


//挂载vuex
app.use(store)
app.use(ElementPlus)
app.use(router)
app.mount('#app')
