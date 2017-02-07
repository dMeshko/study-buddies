function requireAll(requireContext, ngModule) {
    requireContext.keys().forEach(function (modulePath) {
        requireContext(modulePath)(ngModule);
    });
}

var app = angular.module("StudyBuddies", [
    "ui.router",
    "ui.bootstrap",
    "angular-loading-bar",
    "uiRouterStyles",
    "ui-notification",
    "angularFileUpload"
    //"oc.lazyLoad"
]);

require("./constants")(app);
require("./config")(app);

require("./common")(app);

//webpack context module API
var requireContext = require.context("./components", true, /^\.\/.*\.js$/);
requireAll(requireContext, app);

requireContext = require.context("./admin", true, /^\.\/.*\.js$/);
requireAll(requireContext, app);