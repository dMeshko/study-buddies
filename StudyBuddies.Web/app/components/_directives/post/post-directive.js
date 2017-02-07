module.exports = function (ngModule) {
    ngModule.directive("post", [
        "PostService", "$rootScope",
        function (PostService, $rootScope) {
            var postDirective = {
                scope: {
                    post: "=",
                    onRemove: "&"
                },
                template: require("./post.html"),
                link: function($scope, $element, $attributes) {
                    $scope.hideComments = true;

                    $scope.initCommentsSection = function() {
                        $scope.comments = [];
                        PostService.getAllComments($scope.post.id)
                            .success(function(data) {
                                $scope.comments = data;
                            })
                            .error(function(response) {
                                $rootScope.parseErrorMessage(response);
                            });

                        $scope.comment = {
                            user: {
                                id: $rootScope.currentUser.id
                            },
                            post: {
                                id: $scope.post.id
                            },
                            content: ""
                        };
                        $scope.postComment = function() {
                            PostService.addComment($scope.comment)
                                .success(function (data) {
                                    $scope.comments.push(data);
                                    $scope.comment.content = "";
                                })
                                .error(function(response) {
                                    $rootScope.parseErrorMessage(response);
                                });

                        };
                    };

                    $scope.deleteComment = function(commentId) {
                        PostService.deleteComment({ id: $scope.post.id, commentId: commentId })
                            .success(function(data) {
                                $scope.comments = $scope.comments.filter(function(item) {
                                    if (item.id === data)
                                        return false;
                                    return true;
                                });
                            })
                            .error(function(response) {
                                $rootScope.parseErrorMessage(response);
                            });
                    };

                    $scope.deletePost = function () {
                        PostService.deletePost($scope.post.id)
                            .success(function(data) {
                                $scope.onRemove();
                            })
                            .error(function(response) {
                                $rootScope.parseErrorMessage(response);
                            });
                    };
                }
            };

            return postDirective;
        }
    ]);
};