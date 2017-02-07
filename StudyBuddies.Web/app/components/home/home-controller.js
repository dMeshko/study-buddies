module.exports = function (ngModule) {
    ngModule.controller("HomeController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.posts = [];

        UserService.getLatestGroupsPosts($scope.currentUser.id)
            .success(function (data) {
                $scope.posts = data;
            })
            .error(function (response) {
                $scope.parseErrorMessage(response);
            });
    }
    ]);
};