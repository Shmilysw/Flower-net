import { createRouter, createWebHistory } from 'vue-router'
import HomePage from "./views/HomePage.vue"
import LoveFlower from "./views/LoveFlower.vue"
import BirthdayFlower from "./views/BirthdayFlower.vue"
import FriendFlower from "./views/FriendFlower.vue"
import WeddingFlower from "./views/WeddingFlower.vue"
import FlowerDetail from "./views/FlowerDetail.vue"
import FlowerPay from "./views/FlowerPay.vue"
import OrderCenter from "./views/OrderCenter.vue"
import ShopCollect from "./views/ShopCollect.vue"
import PersonHome from "./views/PersonHome.vue"
import ShopCar from "./views/ShopCar_.vue"

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', component: HomePage },
        { path: '/loveflower', component: LoveFlower },
        { path: '/birthdayflower', component: BirthdayFlower },
        { path: '/friendflower', component: FriendFlower },
        { path: '/weddingflower', component: WeddingFlower },
        { path: '/detail', component: FlowerDetail },
        { path: '/pay', component: FlowerPay },
        { path: '/ordercenter', component: OrderCenter },
        { path: '/shopcollect', component: ShopCollect },
        { path: '/personhome', component: PersonHome },
        { path: '/shopcar', component: ShopCar },
    ],
})
export default router