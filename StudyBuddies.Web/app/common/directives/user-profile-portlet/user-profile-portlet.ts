namespace StudyBuddies {
    interface IUserProfilePortletDirectiveScope extends angular.IScope{
        name: string;
    }

    class UserProfilePortletDirective implements angular.IDirective {
        private static userService: IUserService;
        private static baseApiUrl: string;

        static $inject: Array<string> = ["IUserService", "baseApiUrl"];
        constructor(userService: IUserService, baseApiUrl: string) {
            UserProfilePortletDirective.userService = userService;
            UserProfilePortletDirective.baseApiUrl = baseApiUrl;
        }

        static instance(): angular.IDirective {
            return new UserProfilePortletDirective(UserProfilePortletDirective.userService, UserProfilePortletDirective.baseApiUrl);
        }

        scope: boolean | { [index: string]: string; } = {
            
        };
        restrict: string = "E";
        templateUrl: string | ((tElement: JQLite, tAttrs: Object) => string) = "app/common/directives/user-profile-portlet/user-profile-portlet.html";
        link: angular.IDirectiveLinkFn = (scope: IUserProfilePortletDirectiveScope, element: JQLite, attributes: angular.IAttributes): void => {

        };
    }

    angular.module("study.buddies")
        .directive("userProfilePortlet", UserProfilePortletDirective.instance);
}