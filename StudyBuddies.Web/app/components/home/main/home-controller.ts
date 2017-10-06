/// <reference path="../../../common/services/user-service.ts" />

namespace StudyBuddies {
    class HomeController implements angular.IController {
        static $inject: Array<string> = ["UserService"];
        constructor(public userService: IUserService) {
            userService.getAllUsers();
        }

    }

    angular.module("study.buddies")
        .controller("HomeController", HomeController);
}