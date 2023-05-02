const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
    transpileDependencies: true,
    // 前端代理的方式处理跨域问题
    devServer: {
        proxy: {
            '/api': {
                target: 'http://localhost:5228/api',
                // 允许跨域
                changeOrigin: true,
                ws: true,
                pathRewrite: {
                    '^/api': ''
                }
            }
        }
    }
})
