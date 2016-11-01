module.exports = function(ngModule) {
    ngModule.factory("UserService", ["$http", "$location", function($http, $location) {
        var factory = {};

        factory.getAllUsers = function() {
            return $http.get("/api/user");
        };

        return factory;
    }]);
};