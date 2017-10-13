namespace StudyBuddies {
    class StudyGroupPortletDirective implements angular.IDirective {
        static instance(): angular.IDirective {
            return new StudyGroupPortletDirective();
        }

        restrict: string = "E";
        templateUrl: string | ((tElement: JQLite, tAttrs: Object) => string) = "app/common/directives/study-group-portlet/study-group-portlet.html";
        link: angular.IDirectiveLinkFn = (scope: angular.IScope, element: JQLite, attributes: angular.IAttributes): void => {

        };
    }

    angular.module("study.buddies")
        .directive("studyGroupPortlet", StudyGroupPortletDirective.instance);
}