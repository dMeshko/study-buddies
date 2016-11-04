module.exports = function(ngModule) {
    ngModule.controller("RegisterUserController", ["$scope", "UserService", function($scope, UserService) {
        $scope.user = {};

        $scope.registerUser = function(form) {
            if (form.$valid) {
                UserService.saveUser($scope.user).success(function(data) {
                    console.log(data);
                }).error(function (data) {
                    console.log(data);
                });
            };
        };

        $scope.resetForm = function() {
            $scope.user = {};
        };
        $scope.resetForm();
    }]);
};