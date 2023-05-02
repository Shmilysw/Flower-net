<template>
    <div id="footer" class="ft">
        <div class="ft-container">
            <!-- 尾部导航 -->
            <div class="ft-nav">
                <a href="/">首页</a>
                <a href="" target="_blank">关于我们</a>
                <a href="" target="_blank">媒体报道</a>
                <a href="" target="_blank">企业团购</a>
                <a href="" target="_blank">花店入驻</a>
                <a href="" target="_blank">友情链接</a>
                <a href="" target="_blank">在线补款</a>
                <a href="" target="_blank">为什么选择花礼网</a>
            </div>
            <!-- 尾部导航 End -->
            <!-- 友情链接 -->
            <!-- 中华取名网 深圳房产网 卷皮网 腕表 苗木 佐卡伊珠宝网 钻石婚戒定制 青少年艺术教育网 淘狗网 礼无忧网 宠物狗 机友网 礼物网 新三板 商标注册 眼镜店 -->
            <div class="ft-link">
                <span>友链</span>
                <a href="" target="_blank">朝夕教育</a>
                <a href="" target="_blank">中华取名网</a>
                <a href="" target="_blank">深圳房产网</a>
                <a href="" target="_blank">卷皮网</a>
                <a href="" target="_blank">腕表</a>
                <a href="" target="_blank">苗木</a>
                <a href="" target="_blank">佐卡伊珠宝网</a>
                <a href="" target="_blank">钻石婚戒定制</a>
                <a href="" target="_blank">青少年艺术教育网</a>
                <a href="" target="_blank">淘狗网</a>
                <a href="" target="_blank">礼无忧网</a>
                <a href="" target="_blank">宠物狗</a>
                <a href="" target="_blank">机友网</a>
                <a href="" target="_blank">礼物网</a>
                <a href="" target="_blank">新三板</a>
                <a href="" target="_blank">商标注册</a>
                <a href="" target="_blank">眼镜店</a>
            </div>
            <!-- 友情链接 End -->
        </div>
    </div>
</template>

<script lang="ts" setup>
</script>

<style lang="scss">
#footer {
    font-size: 0;
    background-color: #232628;

    .ft-container {
        width: 1200px;
        margin: 0 auto;
        padding: 40px 0 46px;

        .ft-nav {
            a {
                display: inline-block;
                font-size: 16px;
                line-height: 16px;
                color: #fff;
                text-decoration: none;
            }

            a+a {
                padding-left: 28px;
                margin-left: 33px;
                border-left: 1px solid #fff;
            }
        }

        .ft-link {
            margin-top: 20px;

            span {
                font-size: 12px;
                line-height: 16px;
                margin-right: 4px;
                font-weight: bold;
                color: #71797f;
            }

            a {
                font-size: 12px;
                line-height: 16px;
                color: #71797f;
                margin: 0 2px;
                text-decoration: none;
            }
        }
    }
}
</style>