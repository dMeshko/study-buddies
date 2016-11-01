var path = require('path');
require('es6-promise').polyfill(); //we need to polyfill because es5 doesnt do this automatically or some crap i read on github
var webpack = require("webpack");

var config = {
    context: path.join(__dirname, "app"),
    entry: {
        app: "./app.js",
        vendor: "./vendor.js"
    },
    output: {
        path: path.join(__dirname, "Scripts/dist"),
        filename: "bundle.js"
    },
    module: {
        loaders: [
            { test: /\.js$/, loader: "ng-annotate!babel", exclude: /node_modules/ }, // enable usage od ES6
            { test: /\.html$/, loader: "raw", exclude: /node_modules/ },
// enable require-ing views as template param INSTEAD of templateUrl and giving the path
            { test: /\.css$/, loader: "style!css", exclude: /node_modules/ },
// enable processing css and generating style/link tags
            { test: /\.jpe?g$|\.gif$|\.png$|\.svg$|\.woff$|\.woff2$|\.ttf$|\.eot$/, loader: "url" }
        ]
    },
    plugins: [
        new webpack.optimize.CommonsChunkPlugin(/*chunkName*/"vendor", /*fileName*/"vendor.bundle.js")
    ],
    resolve: {
        root: path.resolve(__dirname),
        alias: {
            app: path.join(__dirname, "app"),
            scripts: path.join(__dirname, "Scripts"),
            content: path.join(__dirname, "Content")
        },
        extensions: ["", ".js"]
    }
};

if (process.env.NODE_ENV === "production") {
    config.plugins.push(new webpack.optimize.UglifyJsPlugin());
    config.devtool = "source-map";
    //config.bail = true; //use hard errors instead of tollerating them?
}

module.exports = config;