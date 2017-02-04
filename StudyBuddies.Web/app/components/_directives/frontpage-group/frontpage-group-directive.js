module.exports = function (ngModule) {
    ngModule.directive("frontpageGroup", function () {
        var frontpageGroupDirective = {
            restrict: "E",
            scope: {
                group: "="
            },
            template: require("./frontpage-group.html"),
            link: function ($scope, $element, $attributes) {

            }
        };

        return frontpageGroupDirective;
    });
}