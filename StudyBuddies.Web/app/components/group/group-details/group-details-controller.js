module.exports = function (ngModule) {
    ngModule.controller("ViewGroupDetailsController", [
        "$scope", "$stateParams", "GroupService", "PostService", "FileUploader",
        function ($scope, $stateParams, GroupService, PostService, FileUploader) {
            var groupId = $stateParams.id;
            $scope.group = {};
            GroupService.getGroupById(groupId)
                .then(function(response) {
                    $scope.group = response.data;
                }, function(response) {
                    $scope.parseErrorMessage(response.data);
                });

            $scope.posts = [];
            GroupService.getAllPosts(groupId)
                .then(function(response) {
                    $scope.posts = response.data;
                }, function(response) {
                    $scope.parseErrorMessage(response.data);
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
                    .then(function(response) {
                            $scope.uploader.queue.map(function(item) {
                                item.formData.push({
                                    postId: response.data.id
                                });
                            });
                            $scope.uploader.uploadAll();

                            //$scope.uploader.onCompleteAll = function () {
                            if ($scope.uploader.queue.length === 0)
                                $scope.posts.unshift(response.data);
                            else // we gotta fetch the post, to get the attachments
                                PostService.getPostById(response.data.id)
                                    .then(function(response) {
                                        $scope.posts.unshift(response.data);
                                    }, function(response) {
                                        $scope.parseErrorMessage(response.data);
                                    });

                            $scope.post.content = "";
                        },
                        function(response) {
                            $scope.parseErrorMessage(response.data);
                        });
            };
        }
    ]);
};