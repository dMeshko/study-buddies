/// <reference path="index.js" />
// list all the componenets u want included
// i.e. list all the dependencies
module.exports = function (ngModule) {
    require("./header-controller")(ngModule);
    require("./footer-controller")(ngModule);

    require("./auth/login-controller")(ngModule);
    require("./auth/logout-controller")(ngModule);

    require("./style.css");
};