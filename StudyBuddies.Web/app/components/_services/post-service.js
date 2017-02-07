module.exports = function (ngModule) {
    ngModule.factory("PostService", ["$http", function ($http) {
        var factory = {};

        factory.getPostById = function (id) {
            return $http.get("/api/post/" + id);
        };

        factory.addPost = function (data) {
            return $http.post("/api/post", data);
        };

        factory.deletePost = function (id) {
            return $http.delete("/api/post/" + id);
        };

        factory.getAllComments = function(id) {
            return $http.get("/api/post/" + id + "/comment");
        };

        factory.addComment = function (data) {
            return $http.post("/api/post/" + data.post.id + "/comment", data);
        };

        factory.deleteComment = function (data) {
            return $http.delete("/api/post/" + data.id + "/comment/" + data.commentId);
        };

        return factory;
    }]);
};