module.exports = function(ngModule) {
    ngModule.factory("UserService", ["$http", "$location", function($http, $location) {
        var factory = {};

        factory.getUserById = function (id) {
            return $http.get("/api/user/" + id);
        };

        factory.getAllUsers = function() {
            return $http.get("/api/user");
        };

        factory.getCurrentUser = function() {
            var currentUserId = "50C308F7-E2E5-4529-8BA8-A700017C712D";

            return factory.getUserById(currentUserId);
        };

        factory.saveUser = function (user) {
            //var fd = new FormData();

            //fd.append("name", user.name);
            //fd.append("surname", user.surname);
            //fd.append("email", user.email);
            //fd.append("username", user.username);
            //fd.append("password", user.password);

            //if (user.image)
            //    fd.append("file[]", user.image);

            //var data = fd;
            //var config = {
            //    headers: { 'Content-Type': undefined },
            //    transformRequest: angular.identity
            //};
            var data = {
                Name: user.name,
                Surname: user.surname,
                Email: user.email,
                Password: user.password
            };

            //return $http.post("/api/user", data, config);
            return $http.post("/api/user", data);
        };

        factory.deleteUser = function (id) {
            var params = {
                id: id
            };

            return $http.delete("/api/user", { params: params });
        };

        factory.getLatestGroupsPosts = function(id) {
            return $http.get("/api/user/" + id + "/post");
        }

        return factory;
    }]);
};