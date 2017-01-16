module.exports = function(ngModule) {
    ngModule.directive("featuredUser", function() {
        return {
            restrict: "E",
            replace: true,
            template: require("./featured-user.html"),
            scope:
            {
                "user": "=",
                "callback": "="
            }
        }
    });
};