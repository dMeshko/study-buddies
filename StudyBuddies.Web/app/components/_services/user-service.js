module.exports = function(ngModule) {
    ngModule.factory("UserService", ["$http", "$location", function($http, $location) {
        var factory = {};

        factory.getUserById = function (id) {
            var params = {
                id: id
            };

            return $http.get("/api/user/", {params: params});
        };

        factory.getAllUsers = function() {
            return $http.get("/api/user");
        };

        factory.getCurrentUser = function() {
            var currentUserId = "C07806DE-3C03-4140-8E75-A6B400BDF2B9";

            var params = {
                id: currentUserId
            };

            return $http.get("/api/user/", { params: params });
        };

        factory.saveUser = function (user) {
            var fd = new FormData();

            fd.append("name", user.name);
            fd.append("surname", user.surname);
            fd.append("email", user.email);
            fd.append("username", user.username);
            fd.append("password", user.password);

            if (user.image)
                fd.append("file[]", user.image);

            var data = fd;
            var config = {
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            };

            return $http.post("/api/user", data, config);
        };

        return factory;
    }]);
};