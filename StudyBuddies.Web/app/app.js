function requireAll(requireContext, ngModule) {
    requireContext.keys().forEach(function (modulePath) {
        requireContext(modulePath)(ngModule);
    });
}

var app = angular.module("StudyBuddies", [
    "ui.router"/*,
    "oc.lazyLoad"*/
]);

require("./constants")(app);
require("./states")(app);

require("./common")(app);

//webpack context module API
var requireContext = require.context("./components", true, /^\.\/.*\.js$/);
requireAll(requireContext, app);