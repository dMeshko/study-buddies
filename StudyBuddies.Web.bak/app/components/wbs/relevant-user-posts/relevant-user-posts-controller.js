module.exports = function (ngModule) {
    ngModule.controller("RelevantUserPostsController", ["$scope", "$http", "PostService", function ($scope, $http, PostService) {
        $scope.user = {};

        $scope.posts = [];
        $http.post("http://localhost:9090/relevantUserPosts?userID=" + $scope.currentUser.id)
        .then(function (response) {
            response.data.forEach(function (item) {
                PostService.getPostById(item).then(function (response) {
                    $scope.posts.push(response.data);
                }, function (response) {
                    $scope.parseErrorMessage(response.data);
                });
            });
        }, function (response) {
            $scope.parseErrorMessage(response.data);
        });


    }]);
};