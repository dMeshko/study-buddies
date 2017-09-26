module.exports = function (grunt) {
    grunt.file.readJSON("package.json");

    // load Grunt plugins from NPM
    grunt.loadNpmTasks("grunt-ts");
    grunt.loadNpmTasks("grunt-angular-templates");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-karma");

    // configure plugins
    grunt.initConfig({
        ngtemplates: {
            app: {
                options: {
                    module: "study.buddies",
                    htmlmin: {
                        collapseWhitespace: true,
                        collapseBooleanAttributes: true
                    }
                },
                src: "app/**/*.html",
                dest: "Scripts/dist/templates.js"
            }
        },

        ts: {
            default: {
                src: ["app/**/*.ts", "!node_modules/**", "!obj/**", "!bin/**"],
                tsconfig: true,
                watch: "app/**/*.ts",
                options: {
                    fast: "always"
                }
            }
        },

        concat: {
            dist: {
                files: {
                    "Scripts/dist/app.js": [
                        // dist
                        "node_modules/angular/angular.js",
                        "node_modules/angular-ui-router/release/angular-ui-router.min.js",
                        "node_modules/angular-mocks/angular-mocks.js",

                        // app
                        "Scripts/src/**/*.js"
                    ]
                }
            }
        },

        uglify: { // task
            my_target: { // sub-task
                options: {
                    sourceMap: true
                },
                files: {
                    "dist/app.min.js": [
                        "dist/app.js"
                    ]
                }
            }
        },

        watch: {
            scripts: {
                files: [
                    "Scripts/src/**/*.js"
                ],
                tasks: [
                    "concat:dist"
                ]
            },
            views: {
                files: [
                    "app/**/*.html"
                ],
                tasks: [
                    "ngtemplates:app"
                ]
            }
        },

        karma: {
            unit: {
                configFile: "karma-unit-config.js"
            }
        }
    });

    // define tasks
    grunt.registerTask("concat-and-uglify", ["concat", "uglify"]);
    grunt.registerTask("default", ["ngtemplates", "ts", "concat", "watch"]);
};