namespace StudyBuddies {
    export interface IUserService {
        getUserById(userId: string): angular.IHttpPromise<any>;
        getAllUsers(): angular.IHttpPromise<any>;
        saveUser(user: any): angular.IHttpPromise<any>;
        deleteUser(userId: string): angular.IHttpPromise<any>;

        getLatestGroupPosts(userId: string): angular.IHttpPromise<any>;
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

        saveUser(user: any): angular.IHttpPromise<any> {
            const data = {
                Name: user.name,
                Surname: user.surname,
                Email: user.email,
                Password: user.password
            };

            return this.$http.post("/api/user", data);
        }

        deleteUser(userId: string): angular.IHttpPromise<any> {
            const params = {
                id: userId
            };

            return this.$http.delete("/api/user", { params: params });
        }

        getLatestGroupPosts(userId: string): angular.IHttpPromise<any> {
            return this.$http.get(`/api/user/${userId}/post`);
        }
    }

    angular.module("study.buddies")
        .service("UserService", UserService);
}