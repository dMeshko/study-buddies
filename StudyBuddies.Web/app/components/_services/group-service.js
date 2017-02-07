module.exports = function (ngModule) {
    ngModule.factory("GroupService", ["$http", function ($http) {
        var factory = {};

        factory.getGroupById = function(id) {
            return $http.get("/api/group/" + id);
        };

        factory.getAllGroups = function () {
            return $http.get("/api/group");
        };

        factory.createGroup = function (data) {
            return $http.post("/api/group", data);
        };

        factory.getAllGroupsWhereNoRequestIsSent = function(userId) {
            return $http.get("/api/user/" + userId + "/group/not");
        };

        factory.getAllMemberingGroups = function (userId) {
            return $http.get("/api/user/" + userId + "/group/member");
        };

        factory.sendGroupRequest = function(data) {
            return $http.post("/api/group/" + data.group.id + "/member/" + data.user.id, data);
        }

        factory.getAllPosts = function(groupId) {
            return $http.get("/api/group/" + groupId + "/post");
        }

        return factory;
    }]);
};