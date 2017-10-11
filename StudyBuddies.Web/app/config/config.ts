namespace StudyBuddies {
    class ProductionConfig {
        static $inject: Array<string> = ["$compileProvider"];

        constructor(public $compileProvider: angular.ICompileProvider) {
            // disables debug data, NOTE: use this only in production, protractor needs this?
            this.$compileProvider.debugInfoEnabled(false);

            this.$compileProvider.commentDirectivesEnabled(false);
            this.$compileProvider.cssClassDirectivesEnabled(false);
        }
    }

    angular.module("study.buddies")
        .config(ProductionConfig);
}