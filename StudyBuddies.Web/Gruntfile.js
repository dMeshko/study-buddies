module.exports = function (grunt) {
    grunt.file.readJSON("package.json");

    // load Grunt plugins from NPM
    grunt.loadNpmTasks("grunt-ts");
    grunt.loadNpmTasks("grunt-angular-templates");
    grunt.loadNpmTasks("grunt-contrib-sass");
    grunt.loadNpmTasks("grunt-concat-css");
    grunt.loadNpmTasks("grunt-contrib-cssmin");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-watch");

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

        sass: {
            dev: {
                files: [{
                    expand: true,
                    src: ["app/**/*.scss"],
                    dest: "Content/src",
                    ext: ".css"
                }]
            }
        },

        concat_css: {
            options: {
                // Task-specific options go here. 
            },
            vendor: {
                src: [
                    "node_modules/bootswatch/readable/bootstrap.css",
                    "node_modules/angular-ui-bootstrap/dist/ui-bootstrap-csp.css"
                ],
                dest: "Content/dist/vendor.css"
            },
            app: {
                src: [
                    "Content/src/**/*.css"
                ],
                dest: "Content/dist/app.css"
            }
        },

        cssmin: {
            dist: {
                files: [{
                    expand: false,
                    src: [
                        "Content/dist/*.css",
                        "Content/dist/!*.min.css"
                    ],
                    dest: "Content/dist/app.min.css"
                }]
            }
        },

        ts: {
            dev: {
                src: ["app/**/*.ts", "!node_modules/**", "!obj/**", "!bin/**"],
                tsconfig: true,
                watch: "app/**/*.ts",
                options: {
                    fast: "always"
                }
            }
        },

        concat: {
            dev: {
                files: {
                    "Scripts/dist/app.js": [
                        // dist
                        "node_modules/angular/angular.js",
                        "node_modules/angular-sanitize/angular-sanitize.min.js",
                        "node_modules/angular-ui-router/release/angular-ui-router.min.js",
                        "node_modules/angular-ui-bootstrap/dist/ui-bootstrap.js",
                        "node_modules/angular-ui-bootstrap/dist/ui-bootstrap-tpls.js",

                        // testing
                        "node_modules/angular-mocks/angular-mocks.js",

                        // app
                        "Scripts/src/**/*.js"
                    ]
                }
            }
        },

        uglify: { // task
            dist: { // sub-task
                options: {
                    sourceMap: true
                },
                files: {
                    "Scripts/dist//app.min.js": [
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
                    "concat:dev"
                ]
            },
            views: {
                files: [
                    "app/**/*.html"
                ],
                tasks: [
                    "ngtemplates:app"
                ]
            },
            styles: {
                files: [
                    "app/**/*.css"
                ],
                tasks: [
                    "concat_css:app"
                ]
            }
        },

        karma: {
            unit: {
                configFile: "karma-unit-config.js"
            }
        }
    });
    grunt.loadNpmTasks("grunt-karma");
    // configure plugins

    // define tasks
    grunt.registerTask("dev", ["ngtemplates", "concat_css", "concat", "watch"]);
    grunt.registerTask("concat-and-uglify", ["concat", "uglify"]);
    grunt.registerTask("default", ["ngtemplates", "ts", "concat", "watch"]);
};