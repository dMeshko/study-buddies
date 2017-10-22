namespace StudyBuddies {
    export interface IGroupService {
        getGroupById(groupId: string): angular.IHttpPromise<any>;
        getAllGroups(): angular.IHttpPromise<any>;
        createGroup(group: any): angular.IHttpPromise<any>;
        deleteGroup(groupId: string): angular.IHttpPromise<any>;
    }

    class GroupService implements IGroupService {
        static $inject: Array<string> = ["$http"];
        constructor(public $http: angular.IHttpService) { }

        getGroupById(groupId: string): angular.IHttpPromise<any> {
            return this.$http.get(`/api/group/${groupId}`);
        }

        getAllGroups(): angular.IHttpPromise<any> {
            return this.$http.get("/api/group");
        }

        createGroup(group: any): angular.IHttpPromise<any> {
            return this.$http.post("/api/group", group);
        }

        deleteGroup(groupId: string): angular.IHttpPromise<any> {
            return this.$http.delete(`/api/group/${groupId}`);
        }
    }

    angular.module("study.buddies")
        .service("GroupService", GroupService);
}