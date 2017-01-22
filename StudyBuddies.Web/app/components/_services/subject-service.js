module.exports = function (ngModule) {
    ngModule.factory("SubjectService", ["$http", function ($http) {
        var factory = {};

        factory.getAllSubjects = function () {
            return $http.get("/api/subject");
        };

        return factory;
    }]);
};