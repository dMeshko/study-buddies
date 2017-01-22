module.exports = function (ngModule) {
    ngModule.factory("GroupService", ["$http", function ($http) {
        var factory = {};

        factory.getAllGroups = function () {
            return $http.get("/api/group");
        };

        factory.createGroup = function (data) {
            return $http.post("/api/group", data);
        };

        return factory;
    }]);
};