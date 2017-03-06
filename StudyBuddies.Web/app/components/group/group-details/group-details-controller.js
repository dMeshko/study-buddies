module.exports = function (ngModule) {
    ngModule.controller("ViewGroupDetailsController", [
        "$scope", "$stateParams", "GroupService", "PostService", "FileUploader",
        function ($scope, $stateParams, GroupService, PostService, FileUploader) {
            var groupId = $stateParams.id;
            $scope.group = {};
            GroupService.getGroupById(groupId)
                .success(function (data) {
                    $scope.group = data;
                })
                .error(function (response) {
                    $scope.parseErrorMessage(response);
                });

            $scope.posts = [];
            GroupService.getAllPosts(groupId)
                 .success(function (data) {
                     $scope.posts = data;
                 })
                .error(function (response) {
                    $scope.parseErrorMessage(response);
                });

            // add new post
            $scope.uploader = new FileUploader({
                url: "/api/post/attachment",
                removeAfterUpload: true
            });

            $scope.uploader.filters.push({
                name: 'syncFilter',
                fn: function (item /*{File|FileLikeObject}*/, options) {
                    return this.queue.length < 10;
                }
            });

            $scope.post = {
                user: {
                    id: $scope.currentUser.id
                },
                group: {
                    id: groupId
                },
                content: ""
            };

            $scope.addPost = function () {
                PostService.addPost($scope.post)
                    .success(function (data) {
                        $scope.uploader.queue.map(function(item) {
                            item.formData.push({
                                postId: data.id
                            });
                        });
                        $scope.uploader.uploadAll();

                        //$scope.uploader.onCompleteAll = function () {
                            if ($scope.uploader.queue.length === 0)
                                $scope.posts.unshift(data);
                            else // we gotta fetch the post, to get the attachments
                                PostService.getPostById(data.id)
                                    .success(function(data) {
                                        $scope.posts.unshift(data);
                                    })
                                    .error(function(response) {
                                        $scope.parseErrorMessage(response);
                                    });

                        $scope.post.content = "";
                        //}
                    })
                    .error(function (response) {
                        $scope.parseErrorMessage(response);
                    });
            };
        }
    ]);
};