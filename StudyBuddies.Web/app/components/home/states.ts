namespace StudyBuddies {
    class HomeStates {
        static $inject: Array<string> = ["refs"];

        private $stateProvider: angular.ui.IStateProvider;

        constructor(refs: IReferenceProvider) {
            this.$stateProvider = refs.get("$stateProvider");

            this.$stateProvider
                .state("app.home",
                {
                    url: "", // empty string for "app" state to override the / abstract state
                    views: {
                        //"left@app": {
                        //    templateUrl: require("app/components/home/left-sidebar.html"),
                        //    controller: "LeftSidebarController"
                        //},
                        "main@app": {
                            templateUrl: "app/components/home/home.html",
                            controller: "HomeController"
                        },
                        //"right@app": {
                        //    templateUrl: require("app/components/home/right-sidebar.html"),
                        //    controller: "RightSidebarController"
                        //}
                    }
                });
        }
    }

    angular.module("study.buddies")
        .run(HomeStates);
}