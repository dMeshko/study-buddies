module.exports = function (ngModule) {
    ngModule.controller("LoginController", ["$scope", "$rootScope", "UserService", "$state", function ($scope, $rootScope, UserService, $state) {
        $rootScope.currentUser = {};

        $scope.model = {};
        $scope.login = function () {
            UserService.login($scope.model)
            .then(function (response) {
                $rootScope.currentUser = response.data;
                $state.go("app.home");
            }, function (response) {
                $scope.parseErrorMessage(response.data);
            });
        }
    }]);
}