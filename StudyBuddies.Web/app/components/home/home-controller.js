module.exports = function (ngModule) {
    ngModule.controller("HomeController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.posts = [];

        UserService.getLatestGroupsPosts($scope.currentUser.id)
            .then(function (response) {
                $scope.posts = response.data;
            }, function (response) {
                $scope.parseErrorMessage(response.data);
            });
    }
    ]);
};