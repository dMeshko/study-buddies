module.exports = function (ngModule) {
    ngModule.directive("post", [
        "PostService", "$rootScope", "FileSaver", "Blob",
    function (PostService, $rootScope, FileSaver, Blob) {
            var postDirective = {
                scope: {
                    post: "=",
                    onRemove: "&"
                },
                template: require("./post.html"),
                link: function($scope, $element, $attributes) {
                    $scope.hideComments = true;

                    $scope.currentUser = $rootScope.currentUser;

                    $scope.initCommentsSection = function() {
                        $scope.comments = [];
                        PostService.getAllComments($scope.post.id)
                            .then(function(response) {
                                    $scope.comments = response.data;
                                },
                                function(response) {
                                    $rootScope.parseErrorMessage(response.data);
                                });

                        $scope.comment = {
                            user: {
                                id: $scope.currentUser.id
                            },
                            post: {
                                id: $scope.post.id
                            },
                            content: ""
                        };
                        $scope.postComment = function() {
                            PostService.addComment($scope.comment)
                                .then(function(response) {
                                    $scope.comments.push(response.data);
                                    $scope.comment.content = "";
                                }, function(response) {
                                    $rootScope.parseErrorMessage(response.data);
                                });

                        };
                    };

                    $scope.deleteComment = function(commentId) {
                        PostService.deleteComment({ id: $scope.post.id, commentId: commentId })
                            .then(function(response) {
                                $scope.comments = $scope.comments.filter(function (item) {
                                    if (item.id === response.data)
                                        return false;
                                    return true;
                                });
                            }, function(response) {
                                $rootScope.parseErrorMessage(response.data);
                            });
                    };

                    $scope.deletePost = function () {
                        PostService.deletePost($scope.post.id)
                            .then(function(response) {
                                $scope.onRemove();
                            }, function(response) {
                                $rootScope.parseErrorMessage(response.data);
                            });
                    };

                    function base64toBlob(base64Data, contentType) {
                        contentType = contentType || '';
                        var sliceSize = 1024;
                        var byteCharacters = atob(base64Data);
                        var bytesLength = byteCharacters.length;
                        var slicesCount = Math.ceil(bytesLength / sliceSize);
                        var byteArrays = new Array(slicesCount);

                        for (var sliceIndex = 0; sliceIndex < slicesCount; ++sliceIndex) {
                            var begin = sliceIndex * sliceSize;
                            var end = Math.min(begin + sliceSize, bytesLength);

                            var bytes = new Array(end - begin);
                            for (var offset = begin, i = 0 ; offset < end; ++i, ++offset) {
                                bytes[i] = byteCharacters[offset].charCodeAt(0);
                            }
                            byteArrays[sliceIndex] = new Uint8Array(bytes);
                        }
                        return new Blob(byteArrays, { type: contentType + ";charset=utf-8" });
                    }

                    $scope.downloadFile = function (attachment) {
                        FileSaver.saveAs(base64toBlob(attachment.file, attachment.contentType), attachment.name.substring(0, attachment.name.lastIndexOf(".")));
                    };
                }
            };

            return postDirective;
        }
    ]);
};