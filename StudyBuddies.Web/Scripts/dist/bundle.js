webpackJsonp([0],[
/* 0 */
/*!****************!*\
  !*** ./app.js ***!
  \****************/
/***/ function(module, exports, __webpack_require__) {

	function requireAll(requireContext, ngModule) {
	    requireContext.keys().forEach(function (modulePath) {
	        requireContext(modulePath)(ngModule);
	    });
	}
	
	var app = angular.module("StudyBuddies", ["ui.router", "ui.bootstrap", "angular-loading-bar", "uiRouterStyles", "ui-notification", "angularFileUpload", "ngFileSaver"
	//"oc.lazyLoad"
	]);
	
	__webpack_require__(/*! ./constants */ 1)(app);
	__webpack_require__(/*! ./config */ 2)(app);
	
	__webpack_require__(/*! ./common */ 15)(app);
	
	//webpack context module API
	var requireContext = __webpack_require__(/*! ./components */ 24);
	requireAll(requireContext, app);
	
	requireContext = __webpack_require__(/*! ./admin */ 61);
	requireAll(requireContext, app);

/***/ },
/* 1 */
/*!**********************!*\
  !*** ./constants.js ***!
  \**********************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.constant("SITE_NAME", "Study Buddies");
	};

/***/ },
/* 2 */
/*!*************************!*\
  !*** ./config/index.js ***!
  \*************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    __webpack_require__(/*! ./providers */ 3)(ngModule);
	    __webpack_require__(/*! ./config */ 4)(ngModule);
	    __webpack_require__(/*! ./states */ 5)(ngModule);
	    __webpack_require__(/*! ./run */ 14)(ngModule);
	};

/***/ },
/* 3 */
/*!*****************************!*\
  !*** ./config/providers.js ***!
  \*****************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    var refs = {};
	
	    ngModule.provider("refs", function () {
	        this.$get = function () {
	            return {
	                get: function (name) {
	                    return refs[name];
	                }
	            };
	        };
	
	        this.injectRef = function (name, ref) {
	            refs[name] = ref;
	        };
	    });
	};

/***/ },
/* 4 */
/*!**************************!*\
  !*** ./config/config.js ***!
  \**************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
	        cfpLoadingBarProvider.includeSpinner = false;
	    }]);
	};

/***/ },
/* 5 */
/*!**************************!*\
  !*** ./config/states.js ***!
  \**************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.config(["$stateProvider", "$urlRouterProvider", "refsProvider", function ($stateProvider, $urlRouterProvider, refsProvider) {
	        $urlRouterProvider.otherwise("/"); //for undefined state go to the default/home
	
	        refsProvider.injectRef('$urlRouterProvider', $urlRouterProvider);
	        refsProvider.injectRef('$stateProvider', $stateProvider);
	
	        $stateProvider.state("app", {
	            url: "/",
	            abstract: true,
	            views: {
	                "header": {
	                    controller: "HeaderController",
	                    template: __webpack_require__(/*! app/common/header.html */ 6)
	                },
	                "content": {
	                    template: __webpack_require__(/*! app/components/home/content.html */ 7)
	                },
	                "footer": {
	                    controller: "FooterController",
	                    template: __webpack_require__(/*! app/common/footer.html */ 8)
	                },
	                "left@app": {
	                    template: __webpack_require__(/*! app/components/home/left-sidebar.html */ 9),
	                    controller: "LeftSidebarController"
	                },
	                "main@app": {
	                    template: __webpack_require__(/*! app/components/home/home.html */ 10),
	                    controller: "HomeController"
	                },
	                "right@app": {
	                    template: __webpack_require__(/*! app/components/home/right-sidebar.html */ 11),
	                    controller: "RightSidebarController"
	                }
	            }
	        }).state("app.home", {
	            url: "" //<-- Empty string for "app" state to override the / abstract state
	        }).state("app.login", {
	            url: "login",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! app/common/auth/login.html */ 12),
	                    controller: "LoginController"
	                }
	            }
	        }).state("app.logout", {
	            url: "logout",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! app/common/auth/logout.html */ 13),
	                    controller: "LogoutController"
	                }
	            }
	        });
	    }]);
	};

/***/ },
/* 6 */
/*!****************************!*\
  !*** ./common/header.html ***!
  \****************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"navbar navbar-inverse navbar-fixed-top\">\r\n    <div class=\"container\">\r\n        <div class=\"navbar-header\">\r\n            <button type=\"button\" class=\"navbar-toggle\" ng-click=\"isNavCollapsed = !isNavCollapsed\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n            </button>\r\n            <a ui-sref=\"app.home\" class=\"navbar-brand\">{{ siteName }}</a>\r\n        </div>\r\n        <div class=\"navbar-collapse collapse\" uib-collapse=\"isNavCollapsed\">\r\n            <ul class=\"nav navbar-nav\">\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.home\">Home</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.users.profile\">Profile</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.groups.create\">Create Group</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.groups.list\">View Groups</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.groups.member\">My Groups</a></li>\r\n            </ul>\r\n            \r\n            <ul class=\"nav navbar-nav pull-right\">\r\n                <li ng-if=\"!currentUser.id\" ui-sref-active=\"active\"><a ui-sref=\"app.login\">Login</a></li>\r\n                <li ng-if=\"currentUser.id\" ui-sref-active=\"active\"><a ui-sref=\"app.logout\">Logout</a></li>\r\n                <li ng-if=\"!currentUser.id\" ui-sref-active=\"active\"><a ui-sref=\"app.users.register\">Register</a></li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ },
/* 7 */
/*!**************************************!*\
  !*** ./components/home/content.html ***!
  \**************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div ui-view=\"left\" class=\"col-md-3\"></div>\r\n    <div ui-view=\"main\" class=\"col-md-6\"></div>\r\n    <div ui-view=\"right\" class=\"col-md-3\"></div>\r\n</div>"

/***/ },
/* 8 */
/*!****************************!*\
  !*** ./common/footer.html ***!
  \****************************/
/***/ function(module, exports) {

	module.exports = "<hr />\r\n<footer>\r\n    <p>&copy; {{ currentYear }} - {{ siteName }}</p>\r\n</footer>"

/***/ },
/* 9 */
/*!*******************************************!*\
  !*** ./components/home/left-sidebar.html ***!
  \*******************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"well\">\r\n    <div class=\"row\">\r\n        <span style=\"background: url(group.jpg) 50% 50% no-repeat; border-radius: 60%\"></span>\r\n    </div>\r\n    <div class=\"row\" style=\"margin: 5px;\">\r\n        <strong style=\"font-size: x-large\">Name: </strong> <span style=\"font-size: x-large\">{{ ::user.fullName }}</span>\r\n        <br />\r\n        <strong style=\"font-size: large\">Institutions: </strong> <span style=\"font-size: large\">{{ ::user.institutions }}</span>\r\n        <br />\r\n        <i class=\"fa fa-user-circle\"></i> Admin: <a href=\"\">{{ ::user.username || 'x' }}</a>\r\n        <hr />\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-6 text-center\">\r\n            <a ui-sref=\"app.users.profile.buddies({ id: currentUser.id })\" title=\"Buddies\"><i class=\"fa fa-users fa-2x\"></i></a>\r\n        </div>\r\n        <div class=\"col-md-6 text-center\">\r\n            <a ui-sref=\"app.users.profile.groups({ id: currentUser.id })\" title=\"Groups\"><i class=\"fa fa-object-group fa-2x\"></i></a>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ },
/* 10 */
/*!***********************************!*\
  !*** ./components/home/home.html ***!
  \***********************************/
/***/ function(module, exports) {

	module.exports = "<div ng-if=\"posts.length === 0\">\r\n    <h4>There aren't' any posts from the groups you are enrolled in.</h4>\r\n    <h3>Go ahead and post something fun! :)</h3>\r\n</div>\r\n<div ng-if=\"posts.length > 0\" ng-repeat=\"post in posts\" post=\"post\" on-remove=\"posts.splice($index, 1)\"></div>"

/***/ },
/* 11 */
/*!********************************************!*\
  !*** ./components/home/right-sidebar.html ***!
  \********************************************/
/***/ function(module, exports) {

	module.exports = "<sidebar-group ng-repeat=\"group in groups\" group=\"group\" />"

/***/ },
/* 12 */
/*!********************************!*\
  !*** ./common/auth/login.html ***!
  \********************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row well\">\r\n    <input type=\"email\" ng-model=\"model.email\" class=\"form-control\" placeholder=\"Email Address\" />\r\n    <input type=\"password\" ng-model=\"model.password\" class=\"form-control\" placeholder=\"Email Address\" />\r\n    <button ng-click=\"login()\" type=\"button\" class=\"btn btn-block btn-success\"><i class=\"fa fa-login\"></i> Login</button>\r\n</div>"

/***/ },
/* 13 */
/*!*********************************!*\
  !*** ./common/auth/logout.html ***!
  \*********************************/
/***/ function(module, exports) {

	module.exports = "out.."

/***/ },
/* 14 */
/*!***********************!*\
  !*** ./config/run.js ***!
  \***********************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.run(["$rootScope", "Helpers", function ($rootScope, Helpers) {
	        $rootScope.parseErrorMessage = function (data) {
	            Helpers.parseErrorMessage(data);
	        };
	
	        $rootScope.currentUser = {
	            //id: "2F27D7B7-B62E-4E00-B5DD-A71500019A2C",
	            id: "DB69A5E9-2537-47CC-8151-A714018A667E",
	            //id: "70FE7E5A-42BD-4BBB-B6F4-A714018ABD53",
	            name: "Darko Meshkovski"
	        };
	    }]);
	};

/***/ },
/* 15 */
/*!*************************!*\
  !*** ./common/index.js ***!
  \*************************/
/***/ function(module, exports, __webpack_require__) {

	/// <reference path="index.js" />
	// list all the componenets u want included
	// i.e. list all the dependencies
	module.exports = function (ngModule) {
	    __webpack_require__(/*! ./header-controller */ 16)(ngModule);
	    __webpack_require__(/*! ./footer-controller */ 17)(ngModule);
	
	    __webpack_require__(/*! ./auth/login-controller */ 18)(ngModule);
	    __webpack_require__(/*! ./auth/logout-controller */ 19)(ngModule);
	
	    __webpack_require__(/*! ./style.css */ 20);
	};

/***/ },
/* 16 */
/*!*************************************!*\
  !*** ./common/header-controller.js ***!
  \*************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("HeaderController", ["$scope", "SITE_NAME", function ($scope, SITE_NAME) {
	        $scope.siteName = SITE_NAME;
	    }]);
	};

/***/ },
/* 17 */
/*!*************************************!*\
  !*** ./common/footer-controller.js ***!
  \*************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("FooterController", ["$scope", "SITE_NAME", function ($scope, SITE_NAME) {
	        $scope.currentYear = new Date().getFullYear();
	        $scope.siteName = SITE_NAME;
	    }]);
	};

/***/ },
/* 18 */
/*!*****************************************!*\
  !*** ./common/auth/login-controller.js ***!
  \*****************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("LoginController", ["$scope", "$rootScope", "UserService", "$state", function ($scope, $rootScope, UserService, $state) {
	        $rootScope.currentUser = {};
	
	        $scope.model = {};
	        $scope.login = function () {
	            UserService.login($scope.model).success(function (data) {
	                $rootScope.currentUser = data;
	                $state.go("app.home");
	            }).error(function (response) {
	                $scope.parseErrorMessage(response);
	            });
	        };
	    }]);
	};

/***/ },
/* 19 */
/*!******************************************!*\
  !*** ./common/auth/logout-controller.js ***!
  \******************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("LogoutController", ["$state", "$rootScope", function ($state, $rootScope) {
	        $rootScope.currentUser = {};
	        $state.go("app.login");
	    }]);
	};

/***/ },
/* 20 */
/*!**************************!*\
  !*** ./common/style.css ***!
  \**************************/
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(/*! !./../../~/css-loader!./style.css */ 21);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(/*! ./../../~/style-loader/addStyles.js */ 23)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../../node_modules/css-loader/index.js!./style.css", function() {
				var newContent = require("!!./../../node_modules/css-loader/index.js!./style.css");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 21 */
/*!******************************************!*\
  !*** ../~/css-loader!./common/style.css ***!
  \******************************************/
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(/*! ./../../~/css-loader/lib/css-base.js */ 22)();
	// imports
	
	
	// module
	exports.push([module.id, "[ui-view=\"content\"] {\r\n    margin-top: 65px;\r\n}\r\n\r\n#loading-bar .bar {\r\n  background: white;\r\n}\r\n\r\n.separator:after {\r\n    content: \"|\";\r\n}\r\n\r\n.featured_user {\r\n    min-height: 20px;\r\n    padding: 19px;\r\n    margin-bottom: 20px;\r\n    background-color: white;\r\n    border: 2px solid #18bc9c;\r\n    border-radius: 4px;\r\n}\r\n\r\n.cover {\r\n    background-size: cover;\r\n}", ""]);
	
	// exports


/***/ },
/* 22 */,
/* 23 */,
/* 24 */
/*!*********************************!*\
  !*** ./components ^\.\/.*\.js$ ***!
  \*********************************/
/***/ function(module, exports, __webpack_require__) {

	var map = {
		"./_directives/cover-image/cover-image-directive.js": 25,
		"./_directives/featured-user/featured-user-directive.js": 26,
		"./_directives/file-model-directive.js": 28,
		"./_directives/frontpage-group/frontpage-group-directive.js": 29,
		"./_directives/post/post-directive.js": 31,
		"./_directives/sidebar-group/sidebar-group-directive.js": 33,
		"./_directives/two-state-button/two-state-button-directive.js": 35,
		"./_services/group-service.js": 37,
		"./_services/helpers.js": 38,
		"./_services/post-service.js": 39,
		"./_services/subject-service.js": 40,
		"./_services/user-service.js": 41,
		"./group/create-group/create-group-controller.js": 42,
		"./group/group-details/group-details-controller.js": 43,
		"./group/list-groups/list-groups-controller.js": 44,
		"./group/states.js": 45,
		"./home/home-controller.js": 49,
		"./home/left-sidebar-controller.js": 50,
		"./home/right-sidebar-controller.js": 51,
		"./user/list-user-groups/list-user-groups-controller.js": 52,
		"./user/list-users/list-users-controller.js": 53,
		"./user/register-user/register-user-controller.js": 54,
		"./user/states.js": 55,
		"./user/view-profile/view-profile.js": 60
	};
	function webpackContext(req) {
		return __webpack_require__(webpackContextResolve(req));
	};
	function webpackContextResolve(req) {
		return map[req] || (function() { throw new Error("Cannot find module '" + req + "'.") }());
	};
	webpackContext.keys = function webpackContextKeys() {
		return Object.keys(map);
	};
	webpackContext.resolve = webpackContextResolve;
	module.exports = webpackContext;
	webpackContext.id = 24;


/***/ },
/* 25 */
/*!*********************************************************************!*\
  !*** ./components/_directives/cover-image/cover-image-directive.js ***!
  \*********************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.directive("cover", function () {
	        return {
	            restrict: "C",
	            scope: {
	                "img": "="
	            },
	            link: function ($scope, $element, $attributes) {
	                console.log($scope.img);
	            }
	        };
	    });
	};

/***/ },
/* 26 */
/*!*************************************************************************!*\
  !*** ./components/_directives/featured-user/featured-user-directive.js ***!
  \*************************************************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.directive("featuredUser", function () {
	        return {
	            restrict: "E",
	            replace: true,
	            template: __webpack_require__(/*! ./featured-user.html */ 27),
	            scope: {
	                "user": "=",
	                "callback": "="
	            }
	        };
	    });
	};

/***/ },
/* 27 */
/*!*****************************************************************!*\
  !*** ./components/_directives/featured-user/featured-user.html ***!
  \*****************************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div class=\"col-md-2\">\r\n        <img class=\"img img-responsive\" ng-src=\"data:image/png;base64,{{ user.image }}\" />\r\n    </div>\r\n    <div class=\"col-md-7\">\r\n        <h4>{{ user.fullName }}<small>&nbsp;&nbsp;[{{ user.username }}]</small></h4>\r\n        <p>\r\n            <span uib-rating ng-model=\"user.rating\" read-only=\"true\" ng-class=\"{ 'text-danger': user.rating <= 2, 'text-info': user.rating > 2 && user.rating <= 4, 'text-success': user.rating > 4 }\"></span>\r\n            <span class=\"separator\"></span>\r\n            <span>some important info</span>\r\n            <span class=\"separator\"></span>\r\n            <span>something</span>\r\n        </p>\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n        <!--<two-state-button status=\"true\" callback=\"callback\" />-->\r\n        <button class=\"btn btn-success btn-block\">\r\n            <i class=\"glyphicon glyphicon-education\"></i> Buddy up\r\n        </button>\r\n        <button ui-sref=\"app.profile({id: user.id})\" class=\"btn btn-warning btn-block\">\r\n            <i class=\"glyphicon glyphicon-eye-open\"></i> Preview\r\n        </button>\r\n    </div>\r\n</div>"

/***/ },
/* 28 */
/*!********************************************************!*\
  !*** ./components/_directives/file-model-directive.js ***!
  \********************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.directive('fileModel', ['$parse', function ($parse) {
	        return {
	            restrict: 'A',
	            link: function (scope, element, attrs) {
	                var model = $parse(attrs.fileModel);
	                var modelSetter = model.assign;
	
	                element.bind('change', function () {
	                    scope.$apply(function () {
	                        if (attrs.multiple) {
	                            modelSetter(scope, element[0].files);
	                        } else {
	                            modelSetter(scope, element[0].files[0]);
	                        }
	                    });
	                });
	            }
	        };
	    }]);
	};

/***/ },
/* 29 */
/*!*****************************************************************************!*\
  !*** ./components/_directives/frontpage-group/frontpage-group-directive.js ***!
  \*****************************************************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.directive("frontpageGroup", function () {
	        var frontpageGroupDirective = {
	            restrict: "E",
	            scope: {
	                group: "="
	            },
	            template: __webpack_require__(/*! ./frontpage-group.html */ 30),
	            link: function ($scope, $element, $attributes) {}
	        };
	
	        return frontpageGroupDirective;
	    });
	};

/***/ },
/* 30 */
/*!*********************************************************************!*\
  !*** ./components/_directives/frontpage-group/frontpage-group.html ***!
  \*********************************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div class=\"col-md-2\">\r\n        <img src=\"\" class=\"img img-responsive\" />\r\n    </div>\r\n    <div class=\"col-md-10\">\r\n        <h4>title</h4>\r\n        <small>author | subject</small>\r\n        <p>Description</p>\r\n        <p><span>Members x/y</span> | <span>Group Status: Assembly</span></p>\r\n    </div>\r\n</div>"

/***/ },
/* 31 */
/*!*******************************************************!*\
  !*** ./components/_directives/post/post-directive.js ***!
  \*******************************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.directive("post", ["PostService", "$rootScope", "FileSaver", "Blob", function (PostService, $rootScope, FileSaver, Blob) {
	        var postDirective = {
	            scope: {
	                post: "=",
	                onRemove: "&"
	            },
	            template: __webpack_require__(/*! ./post.html */ 32),
	            link: function ($scope, $element, $attributes) {
	                $scope.hideComments = true;
	
	                $scope.currentUser = $rootScope.currentUser;
	
	                $scope.initCommentsSection = function () {
	                    $scope.comments = [];
	                    PostService.getAllComments($scope.post.id).success(function (data) {
	                        $scope.comments = data;
	                    }).error(function (response) {
	                        $rootScope.parseErrorMessage(response);
	                    });
	
	                    $scope.comment = {
	                        user: {
	                            id: $scope.currentUser.id
	                        },
	                        post: {
	                            id: $scope.post.id
	                        },
	                        content: ""
	                    };
	                    $scope.postComment = function () {
	                        PostService.addComment($scope.comment).success(function (data) {
	                            $scope.comments.push(data);
	                            $scope.comment.content = "";
	                        }).error(function (response) {
	                            $rootScope.parseErrorMessage(response);
	                        });
	                    };
	                };
	
	                $scope.deleteComment = function (commentId) {
	                    PostService.deleteComment({ id: $scope.post.id, commentId: commentId }).success(function (data) {
	                        $scope.comments = $scope.comments.filter(function (item) {
	                            if (item.id === data) return false;
	                            return true;
	                        });
	                    }).error(function (response) {
	                        $rootScope.parseErrorMessage(response);
	                    });
	                };
	
	                $scope.deletePost = function () {
	                    PostService.deletePost($scope.post.id).success(function (data) {
	                        $scope.onRemove();
	                    }).error(function (response) {
	                        $rootScope.parseErrorMessage(response);
	                    });
	                };
	
	                function base64toBlob(base64Data, contentType) {
	                    contentType = contentType || '';
	                    var sliceSize = 1024;
	                    var byteCharacters = atob(base64Data);
	                    var bytesLength = byteCharacters.length;
	                    var slicesCount = Math.ceil(bytesLength / sliceSize);
	                    var byteArrays = new Array(slicesCount);
	
	                    for (var sliceIndex = 0; sliceIndex < slicesCount; ++sliceIndex) {
	                        var begin = sliceIndex * sliceSize;
	                        var end = Math.min(begin + sliceSize, bytesLength);
	
	                        var bytes = new Array(end - begin);
	                        for (var offset = begin, i = 0; offset < end; ++i, ++offset) {
	                            bytes[i] = byteCharacters[offset].charCodeAt(0);
	                        }
	                        byteArrays[sliceIndex] = new Uint8Array(bytes);
	                    }
	                    return new Blob(byteArrays, { type: contentType + ";charset=utf-8" });
	                }
	
	                $scope.downloadFile = function (attachment) {
	                    FileSaver.saveAs(base64toBlob(attachment.file, attachment.contentType), attachment.name.substring(0, attachment.name.lastIndexOf(".")));
	                };
	            }
	        };
	
	        return postDirective;
	    }]);
	};

/***/ },
/* 32 */
/*!***********************************************!*\
  !*** ./components/_directives/post/post.html ***!
  \***********************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"well\">\r\n    <h2>\r\n        {{ ::post.user.name }} \r\n        <small>&lt;{{ ::post.group.name }}&gt;</small>&nbsp;\r\n        <button class=\"btn btn-danger btn-sm\" ng-click=\"deletePost()\"><i class=\"fa fa-trash-o\"></i></button>\r\n    </h2>\r\n    <p ng-bind=\"::post.date | date: 'short'\"></p>\r\n    <div style=\"background-color: white; padding: 5px;\">\r\n        <p ng-bind=\"::post.content\"></p>\r\n        <hr style=\"border-style: dashed\" />\r\n        <div class=\"row\">\r\n            <div ng-repeat=\"attachment in post.attachments\" ng-click=\"downloadFile(attachment)\" class=\"col-sm-3\" style=\"text-align: center\">\r\n                <span class=\"fa fa-file-o\" style=\"font-size: xx-large\"></span><br />\r\n                <a href=\"\" ng-bind=\"::attachment.name\"></a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div class=\"row\">\r\n        <div class=\"pull-right\">\r\n            <button class=\"btn btn-info btn-sm\" ng-click=\"hideComments = !hideComments\"><span ng-bind=\"!!hideComments ? 'View Comments' : 'Hide Comments'\">{{ if (!!hideComments) '<span>View comments <i class=\"fa fa-chevron-down\"></i></span>' else 'Hide comments <i class=\"fa fa-chevron-up\"></i>' }}</span> <i class=\"fa fa-chevron-down\"></i></button>\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div uib-collapse=\"hideComments\" expanded=\"initCommentsSection()\">\r\n        <div class=\"input-group\">\r\n            <input type=\"text\" class=\"form-control\" ng-model=\"comment.content\" placeholder=\"Write a comment...\" aria-describedby=\"postComment\">\r\n            <span class=\"input-group-addon btn btn-success\" ng-click=\"postComment()\" id=\"postComment\">Post the comment!</span>\r\n        </div>\r\n        <br />\r\n        <div class=\"well\">\r\n            <div class=\"row\" ng-repeat=\"comment in comments\" style=\"border-top: 1px solid red; margin-top: 10px; padding-top: 10px;\">\r\n                <div class=\"col-md-4 padding-left-0\">\r\n                    <strong>\r\n                        <span style=\"font-size: small\">{{ ::comment.user.name }}, </span><br />\r\n                    </strong>\r\n                    <span style=\"font-size: smaller\" ng-bind=\"::comment.date | date: 'short'\"></span>\r\n                </div>\r\n                <div class=\"col-md-7 padding-left-0\">\r\n                    {{ ::comment.content }}\r\n                </div>\r\n                <div class=\"col-md-1 padding-left-0\">\r\n                    <button class=\"btn btn-danger btn-sm\" ng-click=\"deleteComment(comment.id)\"><i class=\"fa fa-trash-o\"></i></button>\r\n                </div>\r\n                <hr />\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ },
/* 33 */
/*!*************************************************************************!*\
  !*** ./components/_directives/sidebar-group/sidebar-group-directive.js ***!
  \*************************************************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.directive("sidebarGroup", ["GroupService", "$state", "$rootScope", function (GroupService, $state, $rootScope) {
	        var frontpageGroupDirective = {
	            restrict: "E",
	            scope: {
	                group: "="
	            },
	            template: __webpack_require__(/*! ./sidebar-group.html */ 34),
	            link: function ($scope, $element, $attributes) {
	                $scope.model = {
	                    user: {
	                        id: $rootScope.currentUser.id
	                    },
	                    group: {
	                        id: ""
	                    }
	                };
	                $scope.joinGroup = function (groupId) {
	                    $scope.model.group.id = groupId;
	                    GroupService.sendGroupRequest($scope.model).success(function (response) {
	                        delete $scope.group;
	                    }).error(function (data) {
	                        $rootScope.parseErrorMessage(data);
	                    });
	                };
	            }
	        };
	
	        return frontpageGroupDirective;
	    }]);
	};

/***/ },
/* 34 */
/*!*****************************************************************!*\
  !*** ./components/_directives/sidebar-group/sidebar-group.html ***!
  \*****************************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row well\">\r\n    <div class=\"col-md-12\">\r\n        <h4 ng-bind=\"::group.name\"></h4>\r\n        <small>{{ ::group.admin.name }} | {{ ::group.subject.name }}</small>\r\n        <p ng-bind=\"::group.description\"></p>\r\n        <p><span class=\"badge\">{{ group.occupiedCapacity }} / {{ ::group.groupCapacity }}</span> | <span class=\"label label-success\" ng-bind=\"group.status.name\"></span></p>\r\n        <button ng-click=\"joinGroup(group.id)\" class=\"pull-right btn btn-sm btn-success\"><i class=\"fa fa-plus\"></i> Join</button>\r\n        <button ui-sref=\"app.groups.details({ id: group.id })\" style=\"margin-right: 10px;\" class=\"pull-right btn btn-sm btn-success\"><i class=\"fa fa-eye\"></i> Details</button>\r\n    </div>\r\n</div>"

/***/ },
/* 35 */
/*!*******************************************************************************!*\
  !*** ./components/_directives/two-state-button/two-state-button-directive.js ***!
  \*******************************************************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.directive("twoStateButton", ["$compile", function ($compile) {
	        return {
	            restrict: "E",
	            replace: true,
	            template: __webpack_require__(/*! ./two-state-button.html */ 36),
	            scope: {
	                status: "=",
	                callback: "="
	            },
	            link: function ($scope, $element, $attributes) {
	                var currentButtonState = $scope.status;
	                var markup = angular.element("<button/>").addClass("btn btn-block");
	                var icon, text;
	
	                if (currentButtonState === true) {
	                    markup.addClass("btn-success");
	                    icon = angular.element("<i/>").addClass("glyphicon glyphicon-education");
	                    text = angular.element("<span/>").text(" Buddy Up");
	                } else {
	                    markup.addClass("btn-danger");
	                    icon = angular.element("<i/>").addClass("glyphicon glyphicon-remove");
	                    text = angular.element("<span/>").text(" Remove Buddy");
	                }
	                markup.append(icon).append(text);
	
	                markup.on("click", function () {
	                    currentButtonState = !currentButtonState;
	                    $scope.callback(currentButtonState);
	                });
	
	                var compiled = $compile(markup)($scope);
	                $element.replaceWith(compiled);
	            }
	        };
	    }]);
	};

/***/ },
/* 36 */
/*!***********************************************************************!*\
  !*** ./components/_directives/two-state-button/two-state-button.html ***!
  \***********************************************************************/
/***/ function(module, exports) {

	module.exports = "<button></button>"

/***/ },
/* 37 */
/*!***********************************************!*\
  !*** ./components/_services/group-service.js ***!
  \***********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.factory("GroupService", ["$http", function ($http) {
	        var factory = {};
	
	        factory.getGroupById = function (id) {
	            return $http.get("/api/group/" + id);
	        };
	
	        factory.getAllGroups = function () {
	            return $http.get("/api/group");
	        };
	
	        factory.createGroup = function (data) {
	            return $http.post("/api/group", data);
	        };
	
	        factory.deleteGroup = function (id) {
	            return $http.delete("/api/group/" + id);
	        };
	
	        factory.getAllGroupsWhereNoRequestIsSent = function (userId) {
	            return $http.get("/api/user/" + userId + "/group/not");
	        };
	
	        factory.getAllMemberingGroups = function (userId) {
	            return $http.get("/api/user/" + userId + "/group/member");
	        };
	
	        factory.sendGroupRequest = function (data) {
	            return $http.post("/api/group/" + data.group.id + "/member/" + data.user.id, data);
	        };
	
	        factory.getAllPosts = function (groupId) {
	            return $http.get("/api/group/" + groupId + "/post");
	        };
	
	        return factory;
	    }]);
	};

/***/ },
/* 38 */
/*!*****************************************!*\
  !*** ./components/_services/helpers.js ***!
  \*****************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.factory("Helpers", ["Notification", function (Notification) {
	        var factory = {};
	
	        factory.parseErrorMessage = function (response) {
	            var errorMessages = "";
	
	            if (typeof response === "string") errorMessages = response;else if (response.hasOwnProperty("modelState")) angular.forEach(response.modelState, function (value) {
	                errorMessages += "<p>" + value[0] + "</p>";
	            });else angular.forEach(response, function (value) {
	                errorMessages += "<p>" + value + "</p>";
	            });
	
	            Notification.error({ message: errorMessages, title: "Please correct the following fields:" });
	        };
	
	        return factory;
	    }]);
	};

/***/ },
/* 39 */
/*!**********************************************!*\
  !*** ./components/_services/post-service.js ***!
  \**********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.factory("PostService", ["$http", function ($http) {
	        var factory = {};
	
	        factory.getPostById = function (id) {
	            return $http.get("/api/post/" + id);
	        };
	
	        factory.addPost = function (data) {
	            return $http.post("/api/post", data);
	        };
	
	        factory.deletePost = function (id) {
	            return $http.delete("/api/post/" + id);
	        };
	
	        factory.getAllComments = function (id) {
	            return $http.get("/api/post/" + id + "/comment");
	        };
	
	        factory.addComment = function (data) {
	            return $http.post("/api/post/" + data.post.id + "/comment", data);
	        };
	
	        factory.deleteComment = function (data) {
	            return $http.delete("/api/post/" + data.id + "/comment/" + data.commentId);
	        };
	
	        return factory;
	    }]);
	};

/***/ },
/* 40 */
/*!*************************************************!*\
  !*** ./components/_services/subject-service.js ***!
  \*************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.factory("SubjectService", ["$http", function ($http) {
	        var factory = {};
	
	        factory.getAllSubjects = function () {
	            return $http.get("/api/subject");
	        };
	
	        return factory;
	    }]);
	};

/***/ },
/* 41 */
/*!**********************************************!*\
  !*** ./components/_services/user-service.js ***!
  \**********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.factory("UserService", ["$http", "$location", function ($http, $location) {
	        var factory = {};
	
	        factory.login = function (model) {
	            return $http.post("/api/user/login", model);
	        };
	
	        factory.getUserById = function (id) {
	            return $http.get("/api/user/" + id);
	        };
	
	        factory.getAllUsers = function () {
	            return $http.get("/api/user");
	        };
	
	        factory.getCurrentUser = function () {
	            var currentUserId = "50C308F7-E2E5-4529-8BA8-A700017C712D";
	
	            return factory.getUserById(currentUserId);
	        };
	
	        factory.saveUser = function (user) {
	            //var fd = new FormData();
	
	            //fd.append("name", user.name);
	            //fd.append("surname", user.surname);
	            //fd.append("email", user.email);
	            //fd.append("username", user.username);
	            //fd.append("password", user.password);
	
	            //if (user.image)
	            //    fd.append("file[]", user.image);
	
	            //var data = fd;
	            //var config = {
	            //    headers: { 'Content-Type': undefined },
	            //    transformRequest: angular.identity
	            //};
	            var data = {
	                Name: user.name,
	                Surname: user.surname,
	                Email: user.email,
	                Password: user.password
	            };
	
	            //return $http.post("/api/user", data, config);
	            return $http.post("/api/user", data);
	        };
	
	        factory.deleteUser = function (id) {
	            var params = {
	                id: id
	            };
	
	            return $http.delete("/api/user", { params: params });
	        };
	
	        factory.getLatestGroupsPosts = function (id) {
	            return $http.get("/api/user/" + id + "/post");
	        };
	
	        return factory;
	    }]);
	};

/***/ },
/* 42 */
/*!******************************************************************!*\
  !*** ./components/group/create-group/create-group-controller.js ***!
  \******************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("CreateGroupController", ["$scope", "GroupService", "SubjectService", "$state", function ($scope, GroupService, SubjectService, $state) {
	        $scope.model = {
	            name: "",
	            description: "",
	            groupCapacity: 0,
	            admin: $scope.currentUser,
	            subject: null
	        };
	
	        $scope.createGroup = function () {
	            GroupService.createGroup($scope.model).success(function (data) {
	                $state.go("app.groups.details", { id: data });
	            }).error(function (response) {
	                $scope.parseErrorMessage(response);
	            });
	        };
	
	        $scope.subjects = [];
	        SubjectService.getAllSubjects().success(function (data) {
	            $scope.subjects = data;
	        }).error(function (response) {
	            $scope.parseErrorMessage(response);
	        });
	    }]);
	};

/***/ },
/* 43 */
/*!********************************************************************!*\
  !*** ./components/group/group-details/group-details-controller.js ***!
  \********************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("ViewGroupDetailsController", ["$scope", "$stateParams", "GroupService", "PostService", "FileUploader", function ($scope, $stateParams, GroupService, PostService, FileUploader) {
	        var groupId = $stateParams.id;
	        $scope.group = {};
	        GroupService.getGroupById(groupId).success(function (data) {
	            $scope.group = data;
	        }).error(function (response) {
	            $scope.parseErrorMessage(response);
	        });
	
	        $scope.posts = [];
	        GroupService.getAllPosts(groupId).success(function (data) {
	            $scope.posts = data;
	        }).error(function (response) {
	            $scope.parseErrorMessage(response);
	        });
	
	        // add new post
	        $scope.uploader = new FileUploader({
	            url: "/api/post/attachment",
	            removeAfterUpload: true
	        });
	
	        $scope.uploader.filters.push({
	            name: 'syncFilter',
	            fn: function (item /*{File|FileLikeObject}*/, options) {
	                return this.queue.length < 10;
	            }
	        });
	
	        $scope.post = {
	            user: {
	                id: $scope.currentUser.id
	            },
	            group: {
	                id: groupId
	            },
	            content: ""
	        };
	
	        $scope.addPost = function () {
	            PostService.addPost($scope.post).success(function (data) {
	                $scope.uploader.queue.map(function (item) {
	                    item.formData.push({
	                        postId: data.id
	                    });
	                });
	                $scope.uploader.uploadAll();
	
	                //$scope.uploader.onCompleteAll = function () {
	                if ($scope.uploader.queue.length === 0) $scope.posts.unshift(data);else // we gotta fetch the post, to get the attachments
	                    PostService.getPostById(data.id).success(function (data) {
	                        $scope.posts.unshift(data);
	                    }).error(function (response) {
	                        $scope.parseErrorMessage(response);
	                    });
	
	                $scope.post.content = "";
	                //}
	            }).error(function (response) {
	                $scope.parseErrorMessage(response);
	            });
	        };
	    }]);
	};

/***/ },
/* 44 */
/*!****************************************************************!*\
  !*** ./components/group/list-groups/list-groups-controller.js ***!
  \****************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("ListGroupsController", ["$scope", "GroupService", "Helpers", function ($scope, GroupService, Helpers) {
	        $scope.model = {
	            user: {
	                id: "3F6E0CC2-020C-424E-B57C-7C9BDC427EF8"
	            },
	            group: {},
	            status: {
	                id: 0
	            }
	        };
	
	        $scope.groups = [];
	        GroupService.getAllGroupsWhereNoRequestIsSent($scope.model.user.id).success(function (response) {
	            $scope.groups = response;
	        }).error(function (response) {
	            Helpers.parseErrorMessage(response);
	        });
	
	        $scope.joinGroup = function (groupId) {
	            $scope.model.group.id = groupId;
	            GroupService.sendGroupRequest($scope.model);
	        };
	
	        $scope.deleteGroup = function (groupId) {
	            GroupService.deleteGroup(groupId).success(function (data) {
	                $scope.groups = $scope.groups.filter(function (item) {
	                    if (item.id === groupId) return false;
	                    return true;
	                });
	            }).error(function (response) {
	                $scope.parseErrorMessage(response);
	            });
	        };
	    }]);
	};

/***/ },
/* 45 */
/*!************************************!*\
  !*** ./components/group/states.js ***!
  \************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.run(["refs", function (refs) {
	        var $stateProvider = refs.get("$stateProvider");
	
	        $stateProvider.state("app.groups", {
	            url: "groups",
	            abstract: true,
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./list-groups/list-groups.html */ 46),
	                    controller: "ListGroupsController"
	                }
	            }
	        }).state("app.groups.list", {
	            url: "" //<-- Empty string for "app" state to override the / abstract state
	        }).state("app.groups.details", {
	            url: "/details/:id",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./group-details/group-details.html */ 47),
	                    controller: "ViewGroupDetailsController"
	                }
	            }
	        }).state("app.groups.create", {
	            url: "/create",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./create-group/create-group.html */ 48),
	                    controller: "CreateGroupController"
	                }
	            }
	        });
	    }]);
	};

/***/ },
/* 46 */
/*!*******************************************************!*\
  !*** ./components/group/list-groups/list-groups.html ***!
  \*******************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row well\" ng-repeat=\"group in groups\">\r\n    <div class=\"col-md-2\">\r\n        <img class=\"img img-responsive\" />\r\n    </div>\r\n    <div class=\"col-md-10\">\r\n        <h4 ng-bind=\"::group.name\"></h4>\r\n        <span ng-bind=\"::group.admin.name\"></span>\r\n        <span ng-bind=\"::group.description\"></span>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <span>Members: <span ng-class=\"{ 'text-danger': group.occupiedCapacity == group.groupCapacity }\" ng-bind=\"::group.occupiedCapacity\"></span> / <span ng-bind=\"::group.groupCapacity\"></span></span>\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                <span>Group status: <strong class=\"text-success\" ng-class=\"{ 'text-danger': group.status.id == 1 }\" ng-bind=\"::group.status.name\"></strong></span>\r\n            </div>\r\n        </div>\r\n        <button ng-disabled=\"group.occupiedCapacity == group.groupCapacity || group.status.id == 1\" \r\n                ng-click=\"joinGroup(group.id)\" class=\"btn btn-default btn-block\">Join Group</button>\r\n        <button ng-if=\"currentUser.id.toLowerCase() === group.admin.id.toLowerCase()\" ng-click=\"deleteGroup(group.id)\" class=\"btn btn-danger btn-block\">\r\n            Delete Group\r\n        </button>\r\n    </div>\r\n</div>"

/***/ },
/* 47 */
/*!***********************************************************!*\
  !*** ./components/group/group-details/group-details.html ***!
  \***********************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\" style=\"margin: 5px;\">\r\n    <div class=\"col-md-3 well\">\r\n        <div class=\"row\">\r\n            <span style=\"background: url(group.jpg) 50% 50% no-repeat; border-radius: 60%\"></span>\r\n        </div>\r\n        <div class=\"row\" style=\"margin: 5px;\">\r\n            <strong style=\"font-size: x-large\">Name: </strong> <span style=\"font-size: x-large\">{{ group.name }}</span>\r\n            <br />\r\n            <strong style=\"font-size: large\">Description: </strong> <span style=\"font-size: large\">{{ group.description }}</span>\r\n            <br />\r\n            <i class=\"fa fa-user-circle\"></i> Admin: <a href=\"\">{{ group.admin.name }}</a>\r\n            <hr />\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <i class=\"fa fa-user\"></i> Capacity: <span class=\"badge badge-info\">{{ group.occupiedCapacity}} / {{ group.groupCapacity }}</span>\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                <i class=\"fa fa-inbox\"></i> Status: <span ng-class=\"{'label-success': group.status.id == 0, 'label-danger' : group.status.id > 0}\" class=\"label\">{{ group.status.name }}</span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"col-md-8\">\r\n        <div class=\"row\" style=\"margin-bottom: 10px\">\r\n            <div class=\"col-md-12\">\r\n                <h4><i class=\"fa fa-pencil\"></i> Write Post</h4>\r\n                <textarea rows=\"5\" class=\"form-control\" ng-model=\"post.content\"></textarea>\r\n                <input type=\"file\" nv-file-select=\"\" uploader=\"uploader\" multiple=\"\">\r\n                <button ng-click=\"addPost()\" class=\"btn btn-success\">Add Post</button>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n        <div ng-repeat=\"post in posts\" post=\"post\" on-remove=\"posts.splice($index, 1)\"></div>\r\n    </div>\r\n</div>"

/***/ },
/* 48 */
/*!*********************************************************!*\
  !*** ./components/group/create-group/create-group.html ***!
  \*********************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <input type=\"text\" ng-model=\"model.name\" class=\"form-control\" name=\"name\" placeholder=\"Name\" />\r\n    <input type=\"text\" ng-model=\"model.description\" class=\"form-control\" name=\"description\" placeholder=\"Description\" />\r\n    <input type=\"number\" ng-model=\"model.groupCapacity\" class=\"form-control\" name=\"capacity\" placeholder=\"Capacity\" min=\"0\" />\r\n    <select class=\"form-control\" name=\"subject\" ng-model=\"model.subject\" \r\n            ng-options=\"subject as subject.name + ' ( ' + subject.areaOfStudy.name + ' )' for subject in subjects track by subject.id\"></select>\r\n    <button ng-click=\"createGroup()\" class=\"btn btn-success\">Create Group</button>\r\n</div>"

/***/ },
/* 49 */
/*!********************************************!*\
  !*** ./components/home/home-controller.js ***!
  \********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("HomeController", ["$scope", "UserService", function ($scope, UserService) {
	        $scope.posts = [];
	
	        UserService.getLatestGroupsPosts($scope.currentUser.id).success(function (data) {
	            $scope.posts = data;
	        }).error(function (response) {
	            $scope.parseErrorMessage(response);
	        });
	    }]);
	};

/***/ },
/* 50 */
/*!****************************************************!*\
  !*** ./components/home/left-sidebar-controller.js ***!
  \****************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("LeftSidebarController", ["$scope", "UserService", function ($scope, UserService) {
	        $scope.user = {};
	
	        UserService.getUserById($scope.currentUser.id).success(function (data) {
	            $scope.user = data;
	        }).error(function (data) {
	            $scope.parseErrorMessage(data);
	        });
	    }]);
	};

/***/ },
/* 51 */
/*!*****************************************************!*\
  !*** ./components/home/right-sidebar-controller.js ***!
  \*****************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("RightSidebarController", ["$scope", "GroupService", function ($scope, GroupService) {
	        $scope.grpups = [];
	        GroupService.getAllGroupsWhereNoRequestIsSent($scope.currentUser.id).success(function (response) {
	            $scope.groups = response;
	        }).error(function (response) {
	            $scope.parseErrorMessage(response);
	        });
	    }]);
	};

/***/ },
/* 52 */
/*!*************************************************************************!*\
  !*** ./components/user/list-user-groups/list-user-groups-controller.js ***!
  \*************************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("ListUserGroupsController", ["$scope", "GroupService", function ($scope, GroupService) {
	        $scope.groups = [];
	        GroupService.getAllMemberingGroups($scope.currentUser.id).success(function (response) {
	            $scope.groups = response;
	        }).error(function (response) {
	            $scope.parseErrorMessage(response);
	        });
	
	        $scope.deleteGroup = function (groupId) {
	            GroupService.deleteGroup(groupId).success(function (data) {
	                $scope.groups = $scope.groups.filter(function (item) {
	                    if (item.id === groupId) return false;
	                    return true;
	                });
	            }).error(function (response) {
	                $scope.parseErrorMessage(response);
	            });
	        };
	    }]);
	};

/***/ },
/* 53 */
/*!*************************************************************!*\
  !*** ./components/user/list-users/list-users-controller.js ***!
  \*************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("ListUsersController", ["$scope", "UserService", function ($scope, UserService) {
	        $scope.user = {};
	    }]);
	};

/***/ },
/* 54 */
/*!*******************************************************************!*\
  !*** ./components/user/register-user/register-user-controller.js ***!
  \*******************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("RegisterUserController", ["$scope", "UserService", "$state", "$rootScope", function ($scope, UserService, $state, $rootScope) {
	        $scope.user = {};
	
	        $scope.registerUser = function (form) {
	            if (form.$valid) {
	                UserService.saveUser($scope.user).success(function (data) {
	                    $rootScope.currentUser.id = data;
	                    $state.go("app.home");
	                }).error(function (response) {
	                    $scope.parseErrorMessage(response);
	                });
	            };
	        };
	
	        $scope.resetForm = function () {
	            $scope.user = {};
	        };
	        $scope.resetForm();
	    }]);
	};

/***/ },
/* 55 */
/*!***********************************!*\
  !*** ./components/user/states.js ***!
  \***********************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.run(["refs", function (refs) {
	        var $stateProvider = refs.get("$stateProvider");
	
	        $stateProvider.state("app.users", {
	            url: "users",
	            abstract: true,
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./list-users/list-users.html */ 56),
	                    controller: "ListUsersController"
	                }
	            }
	        }).state("app.users.list", {
	            url: "" //<-- Empty string for "app" state to override the / abstract state
	        }).state("app.users.profile", {
	            url: "/profile/:id",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./view-profile/view-profile.html */ 57),
	                    controller: "ViewUserProfileController"
	                }
	            }
	        }).state("app.users.profile.groups", {
	            url: "/groups",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./list-user-groups/list-user-groups.html */ 58),
	                    controller: "ListUserGroupsController"
	                }
	            }
	        }).state("app.users.register", {
	            url: "/register",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./register-user/register-user.html */ 59),
	                    controller: "RegisterUserController"
	                }
	            }
	        });
	    }]);
	};

/***/ },
/* 56 */
/*!****************************************************!*\
  !*** ./components/user/list-users/list-users.html ***!
  \****************************************************/
/***/ function(module, exports) {

	module.exports = "<h2>hello</h2>"

/***/ },
/* 57 */
/*!********************************************************!*\
  !*** ./components/user/view-profile/view-profile.html ***!
  \********************************************************/
/***/ function(module, exports) {

	module.exports = "<h2>Profile view here</h2>\r\n{{user | json}}\r\n<br />\r\n<button class=\"btn btn-danger\" ng-click=\"deleteProfile(user.id);\">Delete profile</button>"

/***/ },
/* 58 */
/*!****************************************************************!*\
  !*** ./components/user/list-user-groups/list-user-groups.html ***!
  \****************************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row well\" ng-repeat=\"group in groups\">\r\n    <div class=\"col-md-2\">\r\n        <img class=\"img img-responsive\" />\r\n    </div>\r\n    <div class=\"col-md-10\">\r\n        <h4 ng-bind=\"::group.name\"></h4>\r\n        <span ng-bind=\"::group.admin.name\"></span>\r\n        <span ng-bind=\"::group.description\"></span>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <span>Members: <span ng-class=\"{ 'text-danger': group.occupiedCapacity == group.groupCapacity }\" ng-bind=\"::group.occupiedCapacity\"></span> / <span ng-bind=\"::group.groupCapacity\"></span></span>\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                <span>Group status: <strong class=\"text-success\" ng-class=\"{ 'text-danger': group.status.id == 1 }\" ng-bind=\"::group.status.name\"></strong></span>\r\n            </div>\r\n        </div>\r\n        <button ui-sref=\"app.groups.details({ id: group.id })\" class=\"btn btn-default btn-block\">\r\n            Details\r\n        </button>\r\n        <button ng-if=\"currentUser.id.toLowerCase() === group.admin.id.toLowerCase()\" ng-click=\"deleteGroup(group.id)\" class=\"btn btn-danger btn-block\">\r\n            Delete Group\r\n        </button>\r\n    </div>\r\n</div>"

/***/ },
/* 59 */
/*!**********************************************************!*\
  !*** ./components/user/register-user/register-user.html ***!
  \**********************************************************/
/***/ function(module, exports) {

	module.exports = "<h3>Create account</h3>\r\n<form class=\"form-horizontal\" enctype=\"multipart/form-data\" name=\"registerForm\" novalidate>\r\n    <div class=\"form-group\">\r\n        <label for=\"name\" class=\"control-label col-md-2\">Name</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.name\" id=\"name\" required type=\"text\" class=\"form-control\" placeholder=\"Enter your first name here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"surname\" class=\"control-label col-md-2\">Surname</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.surname\" id=\"surname\" required type=\"text\" class=\"form-control\" placeholder=\"Enter your last name here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"email\" class=\"control-label col-md-2\">Email</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.email\" id=\"email\" required type=\"email\" class=\"form-control\" placeholder=\"Enter your email here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"password\" class=\"control-label col-md-2\">Password</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.password\" id=\"password\" required type=\"password\" class=\"form-control\" placeholder=\"Enter your password here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-3\">\r\n            <button ng-click=\"resetForm();\" class=\"btn btn-danger btn-block\"><i class=\"glyphicon glyphicon-alert\"></i> Reset form</button>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <button ng-click=\"registerUser(registerForm);\" ng-disabled=\"registerForm.$invalid\" class=\"btn btn-success btn-block\"><i class=\"glyphicon glyphicon-check\"></i> Register</button>\r\n        </div>\r\n    </div>\r\n</form>"

/***/ },
/* 60 */
/*!******************************************************!*\
  !*** ./components/user/view-profile/view-profile.js ***!
  \******************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("ViewUserProfileController", ["$scope", "$stateParams", "UserService", function ($scope, $stateParams, UserService) {
	        $scope.user = {};
	
	        UserService.getUserById($stateParams.id).success(function (data) {
	            $scope.user = data;
	        }).error(function (data) {
	            console.log("Error getting the user details");
	        });
	
	        $scope.deleteProfile = function (id) {
	            UserService.deleteUser(id).success(function () {
	                console.log("the user is gone now!");
	            }).error(function (data) {
	                console.log("Delete failed because: " + data);
	                alert(JSON.stringify(data));
	            });
	        };
	    }]);
	};

/***/ },
/* 61 */
/*!****************************!*\
  !*** ./admin ^\.\/.*\.js$ ***!
  \****************************/
/***/ function(module, exports, __webpack_require__) {

	var map = {
		"./config.js": 62
	};
	function webpackContext(req) {
		return __webpack_require__(webpackContextResolve(req));
	};
	function webpackContextResolve(req) {
		return map[req] || (function() { throw new Error("Cannot find module '" + req + "'.") }());
	};
	webpackContext.keys = function webpackContextKeys() {
		return Object.keys(map);
	};
	webpackContext.resolve = webpackContextResolve;
	module.exports = webpackContext;
	webpackContext.id = 61;


/***/ },
/* 62 */
/*!*************************!*\
  !*** ./admin/config.js ***!
  \*************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.config(["$stateProvider", function ($stateProvider) {
	        $stateProvider.state("admin", {
	            url: "/admin",
	            views: {
	                "content": {
	                    template: __webpack_require__(/*! app/admin/home.html */ 63)
	                }
	            }
	        });
	    }]);
	};

/***/ },
/* 63 */
/*!*************************!*\
  !*** ./admin/home.html ***!
  \*************************/
/***/ function(module, exports) {

	module.exports = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title></title>\r\n\t<meta charset=\"utf-8\" />\r\n</head>\r\n<body>\r\n\r\n</body>\r\n</html>\r\n"

/***/ }
]);
//# sourceMappingURL=bundle.js.map