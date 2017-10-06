namespace StudyBuddies {
    export interface IUserService {
        getUserById(userId: string): angular.IHttpPromise<any>;
        getAllUsers(): angular.IHttpPromise<any>;
    }

    class UserService implements IUserService {
        static $inject: Array<string> = ["$http"];
        constructor(public $http: angular.IHttpService) { }

        getUserById(userId: string): angular.IHttpPromise<any> {
            return this.$http.get(`/api/user/${userId}`);
        }

        getAllUsers(): angular.IHttpPromise<any> {
            return this.$http.get("/api/user");
        }
    }

    angular.module("study.buddies")
        .service("UserService", UserService);
}