module.exports = function(ngModule) {
    ngModule.controller("RegisterUserController", ["$scope", "UserService", "$state", "$rootScope", function ($scope, UserService, $state, $rootScope) {
        $scope.user = {};

        $scope.registerUser = function(form) {
            if (form.$valid) {
                UserService.saveUser($scope.user).success(function (data) {
                    $rootScope.currentUser.id = data;
                    $state.go("app.home");
                }).error(function (response) {
                    $scope.parseErrorMessage(response);
                });
            };
        };

        $scope.resetForm = function() {
            $scope.user = {};
        };
        $scope.resetForm();
    }]);
};