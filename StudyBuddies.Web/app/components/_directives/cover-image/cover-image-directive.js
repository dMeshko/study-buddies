module.exports = function (ngModule) {
    ngModule.directive("cover", function () {
        return {
            restrict: "C",
            scope:
            {
                "img": "="
            },
            link: function($scope, $element, $attributes) {
                console.log($scope.img);
            }
        }
    });
};