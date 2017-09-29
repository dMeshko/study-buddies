namespace StudyBuddies {
    class HeaderController implements angular.IController {
        static $inject: Array<string> = ["SITE_NAME"];

        constructor(public siteName: string) { }
    }

    angular.module("study.buddies")
        .controller("HeaderController", HeaderController);
}