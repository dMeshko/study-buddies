module.exports = function (ngModule) {
    ngModule.directive("twoStateButton", [
        "$compile",
        function ($compile) {
            return {
                restrict: "E",
                replace: true,
                template: require("./two-state-button.html"),
                scope: {
                    status: "=",
                    callback: "="
                },
                link: function ($scope, $element, $attributes) {
                    var currentButtonState = $scope.status;
                    var markup = angular.element("<button/>").addClass("btn btn-block");
                    var icon, text;

                    if (currentButtonState === true) {
                        markup.addClass("btn-success");
                        icon = angular.element("<i/>").addClass("glyphicon glyphicon-education");
                        text = angular.element("<span/>").text(" Buddy Up");
                    } else {
                        markup.addClass("btn-danger");
                        icon = angular.element("<i/>").addClass("glyphicon glyphicon-remove");
                        text = angular.element("<span/>").text(" Remove Buddy");
                    }
                    markup.append(icon).append(text);

                    markup.on("click", function() {
                        currentButtonState = !currentButtonState;
                        $scope.callback(currentButtonState);
                    });

                    var compiled = $compile(markup)($scope);
                    $element.replaceWith(compiled);
                }
            }
        }]);
};