module.exports = function (ngModule) {
    ngModule.controller("LoginController", ["$scope", "$rootScope", "UserService", "$state", function ($scope, $rootScope, UserService, $state) {
        $rootScope.currentUser = {};

        $scope.model = {};
        $scope.login = function () {
            UserService.login($scope.model)
            .success(function (data) {
                $rootScope.currentUser = data;
                $state.go("app.home");
            })
            .error(function (response) {
                $scope.parseErrorMessage(response);
            });
        }
    }]);
}