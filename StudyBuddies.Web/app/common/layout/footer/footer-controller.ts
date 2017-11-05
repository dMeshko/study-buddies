namespace StudyBuddies {
    class FooterController implements angular.IController {
        currentYear: number;
        static $inject: Array<string> = ["SITE_NAME"];

        constructor(public siteName: string) {
            this.currentYear = new Date().getFullYear();
        }
    }

    angular.module("study.buddies")
        .controller("FooterController", FooterController);
}