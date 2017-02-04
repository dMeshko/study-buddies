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
	
	var app = angular.module("StudyBuddies", ["ui.router", "ui.bootstrap", "angular-loading-bar", "uiRouterStyles", "ui-notification"
	//"oc.lazyLoad"
	]);
	
	__webpack_require__(/*! ./constants */ 1)(app);
	__webpack_require__(/*! ./config */ 2)(app);
	
	__webpack_require__(/*! ./common */ 13)(app);
	
	//webpack context module API
	var requireContext = __webpack_require__(/*! ./components */ 20);
	requireAll(requireContext, app);
	
	requireContext = __webpack_require__(/*! ./admin */ 52);
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
	    __webpack_require__(/*! ./run */ 12)(ngModule);
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
	        });
	    }]);
	};

/***/ },
/* 6 */
/*!****************************!*\
  !*** ./common/header.html ***!
  \****************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"navbar navbar-inverse navbar-fixed-top\">\r\n    <div class=\"container\">\r\n        <div class=\"navbar-header\">\r\n            <button type=\"button\" class=\"navbar-toggle\" ng-click=\"isNavCollapsed = !isNavCollapsed\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n            </button>\r\n            <a ui-sref=\"app.home\" class=\"navbar-brand\">{{ siteName }}</a>\r\n        </div>\r\n        <div class=\"navbar-collapse collapse\" uib-collapse=\"isNavCollapsed\">\r\n            <ul class=\"nav navbar-nav\">\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.home\">Home</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.profile\">Profile</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.register\">Register</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.groups.create\">Create Group</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.groups.list\">View Groups</a></li>\r\n                <li ui-sref-active=\"active\"><a ui-sref=\"app.groups.member\">My Groups</a></li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</div>"

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

	module.exports = "<div class=\"row\">\r\n    <div class=\"cover\" img=\"data:image/png;base64,{{currentUser.coverImage}}\"></div>\r\n    <div class=\"row\">\r\n        hello\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-5\">\r\n        <img class=\"img img-responsive\" ng-src =\"data:image/png;base64,{{currentUser.image}}\" />\r\n    </div>\r\n    <div class=\"col-md-7\">\r\n        <h3>{{ currentUser.fullName }}</h3>\r\n    </div>\r\n</div>\r\n<div class=\"row\"><div class=\"col-lg-offset-4 col-md-4\"><hr /></div></div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <h5><i class=\"glyphicon glyphicon-user\"></i> {{currentUser.username}}</h5>\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n        <h5><i class=\"glyphicon glyphicon-baby-formula\"></i> {{currentUser.institutions}}</h5>\r\n    </div>\r\n</div>\r\n<div class=\"row\"><div class=\"col-lg-offset-4 col-md-4\"><hr /></div></div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <span uib-rating ng-model=\"rate\"></span>\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n        <p>10 reviews</p>\r\n    </div>\r\n</div>\r\n<hr />\r\n<div class=\"row\">\r\n    some other interesting part goes here\r\n</div>"

/***/ },
/* 10 */
/*!***********************************!*\
  !*** ./components/home/home.html ***!
  \***********************************/
/***/ function(module, exports) {

	module.exports = "{{posts | json}}"

/***/ },
/* 11 */
/*!********************************************!*\
  !*** ./components/home/right-sidebar.html ***!
  \********************************************/
/***/ function(module, exports) {

	module.exports = "<sidebar-group ng-repeat=\"group in groups\" group=\"group\" />"

/***/ },
/* 12 */
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
	            id: "50C308F7-E2E5-4529-8BA8-A700017C712D",
	            name: "Darko Meshkovski"
	        };
	    }]);
	};

/***/ },
/* 13 */
/*!*************************!*\
  !*** ./common/index.js ***!
  \*************************/
/***/ function(module, exports, __webpack_require__) {

	// list all the componenets u want included
	// i.e. list all the dependencies
	module.exports = function (ngModule) {
	    __webpack_require__(/*! ./header-controller */ 14)(ngModule);
	    __webpack_require__(/*! ./footer-controller */ 15)(ngModule);
	
	    __webpack_require__(/*! ./style.css */ 16);
	};

/***/ },
/* 14 */
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
/* 15 */
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
/* 16 */
/*!**************************!*\
  !*** ./common/style.css ***!
  \**************************/
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(/*! !./../../~/css-loader!./style.css */ 17);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(/*! ./../../~/style-loader/addStyles.js */ 19)(content, {});
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
/* 17 */
/*!******************************************!*\
  !*** ../~/css-loader!./common/style.css ***!
  \******************************************/
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(/*! ./../../~/css-loader/lib/css-base.js */ 18)();
	// imports
	
	
	// module
	exports.push([module.id, "[ui-view=\"content\"] {\r\n    margin-top: 65px;\r\n}\r\n\r\n#loading-bar .bar {\r\n  background: white;\r\n}\r\n\r\n.separator:after {\r\n    content: \"|\";\r\n}\r\n\r\n.featured_user {\r\n    min-height: 20px;\r\n    padding: 19px;\r\n    margin-bottom: 20px;\r\n    background-color: white;\r\n    border: 2px solid #18bc9c;\r\n    border-radius: 4px;\r\n}\r\n\r\n.cover {\r\n    background-size: cover;\r\n}", ""]);
	
	// exports


/***/ },
/* 18 */,
/* 19 */,
/* 20 */
/*!*********************************!*\
  !*** ./components ^\.\/.*\.js$ ***!
  \*********************************/
/***/ function(module, exports, __webpack_require__) {

	var map = {
		"./_directives/cover-image/cover-image-directive.js": 21,
		"./_directives/featured-user/featured-user-directive.js": 22,
		"./_directives/file-model-directive.js": 24,
		"./_directives/frontpage-group/frontpage-group-directive.js": 25,
		"./_directives/sidebar-group/sidebar-group-directive.js": 27,
		"./_directives/two-state-button/two-state-button-directive.js": 29,
		"./_services/group-service.js": 31,
		"./_services/helpers.js": 32,
		"./_services/subject-service.js": 33,
		"./_services/user-service.js": 34,
		"./group/create-group/create-group-controller.js": 35,
		"./group/group-details/group-details-controller.js": 36,
		"./group/list-groups/list-groups-controller.js": 37,
		"./group/states.js": 38,
		"./home/home-controller.js": 42,
		"./home/left-sidebar-controller.js": 43,
		"./home/right-sidebar-controller.js": 44,
		"./user/list-users/list-users-controller.js": 45,
		"./user/register-user/register-user-controller.js": 46,
		"./user/states.js": 47,
		"./user/view-profile/view-profile.js": 51
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
	webpackContext.id = 20;


/***/ },
/* 21 */
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
/* 22 */
/*!*************************************************************************!*\
  !*** ./components/_directives/featured-user/featured-user-directive.js ***!
  \*************************************************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.directive("featuredUser", function () {
	        return {
	            restrict: "E",
	            replace: true,
	            template: __webpack_require__(/*! ./featured-user.html */ 23),
	            scope: {
	                "user": "=",
	                "callback": "="
	            }
	        };
	    });
	};

/***/ },
/* 23 */
/*!*****************************************************************!*\
  !*** ./components/_directives/featured-user/featured-user.html ***!
  \*****************************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div class=\"col-md-2\">\r\n        <img class=\"img img-responsive\" ng-src=\"data:image/png;base64,{{ user.image }}\" />\r\n    </div>\r\n    <div class=\"col-md-7\">\r\n        <h4>{{ user.fullName }}<small>&nbsp;&nbsp;[{{ user.username }}]</small></h4>\r\n        <p>\r\n            <span uib-rating ng-model=\"user.rating\" read-only=\"true\" ng-class=\"{ 'text-danger': user.rating <= 2, 'text-info': user.rating > 2 && user.rating <= 4, 'text-success': user.rating > 4 }\"></span>\r\n            <span class=\"separator\"></span>\r\n            <span>some important info</span>\r\n            <span class=\"separator\"></span>\r\n            <span>something</span>\r\n        </p>\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n        <!--<two-state-button status=\"true\" callback=\"callback\" />-->\r\n        <button class=\"btn btn-success btn-block\">\r\n            <i class=\"glyphicon glyphicon-education\"></i> Buddy up\r\n        </button>\r\n        <button ui-sref=\"app.profile({id: user.id})\" class=\"btn btn-warning btn-block\">\r\n            <i class=\"glyphicon glyphicon-eye-open\"></i> Preview\r\n        </button>\r\n    </div>\r\n</div>"

/***/ },
/* 24 */
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
/* 25 */
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
	            template: __webpack_require__(/*! ./frontpage-group.html */ 26),
	            link: function ($scope, $element, $attributes) {}
	        };
	
	        return frontpageGroupDirective;
	    });
	};

/***/ },
/* 26 */
/*!*********************************************************************!*\
  !*** ./components/_directives/frontpage-group/frontpage-group.html ***!
  \*********************************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div class=\"col-md-2\">\r\n        <img src=\"\" class=\"img img-responsive\" />\r\n    </div>\r\n    <div class=\"col-md-10\">\r\n        <h4>title</h4>\r\n        <small>author | subject</small>\r\n        <p>Description</p>\r\n        <p><span>Members x/y</span> | <span>Group Status: Assembly</span></p>\r\n    </div>\r\n</div>"

/***/ },
/* 27 */
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
	            template: __webpack_require__(/*! ./sidebar-group.html */ 28),
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
/* 28 */
/*!*****************************************************************!*\
  !*** ./components/_directives/sidebar-group/sidebar-group.html ***!
  \*****************************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row well\">\r\n    <div class=\"col-md-12\">\r\n        <h4 ng-bind=\"::group.name\"></h4>\r\n        <small>{{ ::group.admin.name }} | {{ ::group.subject.name }}</small>\r\n        <p ng-bind=\"::group.description\"></p>\r\n        <p><span class=\"badge\">{{ group.occupiedCapacity }} / {{ ::group.groupCapacity }}</span> | <span class=\"label label-success\" ng-bind=\"group.status.name\"></span></p>\r\n        <button ng-click=\"joinGroup(group.id)\" class=\"pull-right btn btn-sm btn-success\"><i class=\"fa fa-plus\"></i> Join</button>\r\n        <button ui-sref=\"app.groups.details({ id: group.id })\" style=\"margin-right: 10px;\" class=\"pull-right btn btn-sm btn-success\"><i class=\"fa fa-eye\"></i> Details</button>\r\n    </div>\r\n</div>"

/***/ },
/* 29 */
/*!*******************************************************************************!*\
  !*** ./components/_directives/two-state-button/two-state-button-directive.js ***!
  \*******************************************************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.directive("twoStateButton", ["$compile", function ($compile) {
	        return {
	            restrict: "E",
	            replace: true,
	            template: __webpack_require__(/*! ./two-state-button.html */ 30),
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
/* 30 */
/*!***********************************************************************!*\
  !*** ./components/_directives/two-state-button/two-state-button.html ***!
  \***********************************************************************/
/***/ function(module, exports) {

	module.exports = "<button></button>"

/***/ },
/* 31 */
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
	
	        factory.getAllGroupsWhereNoRequestIsSent = function (userId) {
	            return $http.get("/api/user/" + userId + "/group/not");
	        };
	
	        factory.sendGroupRequest = function (data) {
	            return $http.post("/api/group/" + data.group.id + "/member/" + data.user.id, data);
	        };
	
	        return factory;
	    }]);
	};

/***/ },
/* 32 */
/*!*****************************************!*\
  !*** ./components/_services/helpers.js ***!
  \*****************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.factory("Helpers", ["Notification", function (Notification) {
	        var factory = {};
	
	        factory.parseErrorMessage = function (response) {
	            var errorMessages = "";
	
	            if (typeof response === "string") errorMessages = response;else angular.forEach(response.modelState, function (value) {
	                errorMessages += "<p>" + value[0] + "</p>";
	            });
	
	            Notification.error({ message: errorMessages, title: "Please correct the following fields:" });
	        };
	
	        return factory;
	    }]);
	};

/***/ },
/* 33 */
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
/* 34 */
/*!**********************************************!*\
  !*** ./components/_services/user-service.js ***!
  \**********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.factory("UserService", ["$http", "$location", function ($http, $location) {
	        var factory = {};
	
	        factory.getUserById = function (id) {
	            var params = {
	                id: id
	            };
	
	            return $http.get("/api/user", { params: params });
	        };
	
	        factory.getAllUsers = function () {
	            return $http.get("/api/user");
	        };
	
	        factory.getCurrentUser = function () {
	            var currentUserId = "1507a17d-0143-40be-858b-e20fdb0a8eeb";
	
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
/* 35 */
/*!******************************************************************!*\
  !*** ./components/group/create-group/create-group-controller.js ***!
  \******************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("CreateGroupController", ["$scope", "GroupService", "SubjectService", function ($scope, GroupService, SubjectService) {
	        $scope.model = {
	            name: "",
	            description: "",
	            groupCapacity: 0,
	            admin: {
	                id: "50C308F7-E2E5-4529-8BA8-A700017C712D",
	                name: "Darko Meshkovski"
	            },
	            subject: null
	        };
	
	        $scope.createGroup = function () {
	            GroupService.createGroup($scope.model).success(function (response) {
	                alert("DONE" + response);
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
/* 36 */
/*!********************************************************************!*\
  !*** ./components/group/group-details/group-details-controller.js ***!
  \********************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("ViewGroupDetailsController", ["$scope", "$stateParams", "GroupService", function ($scope, $stateParams, GroupService) {
	        var groupId = $stateParams.id;
	        $scope.group = {};
	        GroupService.getGroupById(groupId).success(function (data) {
	            $scope.group = data;
	        }).error(function (response) {
	            $scope.parseErrorMessage(response);
	        });
	    }]);
	};

/***/ },
/* 37 */
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
	    }]);
	};

/***/ },
/* 38 */
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
	                    template: __webpack_require__(/*! ./list-groups/list-groups.html */ 39),
	                    controller: "ListGroupsController"
	                }
	            }
	        }).state("app.groups.list", {
	            url: "" //<-- Empty string for "app" state to override the / abstract state
	        }).state("app.groups.details", {
	            url: "/details/:id",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./group-details/group-details.html */ 40),
	                    controller: "ViewGroupDetailsController"
	                }
	            }
	        }).state("app.groups.create", {
	            url: "/create",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./create-group/create-group.html */ 41),
	                    controller: "CreateGroupController"
	                }
	            }
	        });
	    }]);
	};

/***/ },
/* 39 */
/*!*******************************************************!*\
  !*** ./components/group/list-groups/list-groups.html ***!
  \*******************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row well\" ng-repeat=\"group in groups\">\r\n    <div class=\"col-md-2\">\r\n        <img class=\"img img-responsive\" />\r\n    </div>\r\n    <div class=\"col-md-10\">\r\n        <h4 ng-bind=\"::group.name\"></h4>\r\n        <span ng-bind=\"::group.admin.name\"></span>\r\n        <span ng-bind=\"::group.description\"></span>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <span>Members: <span ng-class=\"{ 'text-danger': group.occupiedCapacity == group.groupCapacity }\" ng-bind=\"::group.occupiedCapacity\"></span> / <span ng-bind=\"::group.groupCapacity\"></span></span>\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                <span>Group status: <strong class=\"text-success\" ng-class=\"{ 'text-danger': group.status.id == 1 }\" ng-bind=\"::group.status.name\"></strong></span>\r\n            </div>\r\n        </div>\r\n        <button ng-disabled=\"group.occupiedCapacity == group.groupCapacity || group.status.id == 1\" \r\n                ng-click=\"joinGroup(group.id)\" class=\"btn btn-default btn-block\">Join Group</button>\r\n    </div>\r\n</div>"

/***/ },
/* 40 */
/*!***********************************************************!*\
  !*** ./components/group/group-details/group-details.html ***!
  \***********************************************************/
/***/ function(module, exports) {

	module.exports = "<h2>details</h2>\r\n<pre>{{ group | json }}</pre>"

/***/ },
/* 41 */
/*!*********************************************************!*\
  !*** ./components/group/create-group/create-group.html ***!
  \*********************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <input type=\"text\" ng-model=\"model.name\" class=\"form-control\" name=\"name\" placeholder=\"Name\" />\r\n    <input type=\"text\" ng-model=\"model.description\" class=\"form-control\" name=\"description\" placeholder=\"Description\" />\r\n    <input type=\"number\" ng-model=\"model.groupCapacity\" class=\"form-control\" name=\"capacity\" placeholder=\"Capacity\" min=\"0\" />\r\n    <select class=\"form-control\" name=\"subject\" ng-model=\"model.subject\" \r\n            ng-options=\"subject as subject.name + ' ( ' + subject.areaOfStudy.name + ' )' for subject in subjects track by subject.id\"></select>\r\n    <button ng-click=\"createGroup()\" class=\"btn btn-success\">Create Group</button>\r\n</div>"

/***/ },
/* 42 */
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
	            console.log("Unable to fetch the users!! " + response);
	            $scope.parseErrorMessage(response);
	        });
	    }]);
	};

/***/ },
/* 43 */
/*!****************************************************!*\
  !*** ./components/home/left-sidebar-controller.js ***!
  \****************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("LeftSidebarController", ["$scope", "UserService", function ($scope, UserService) {
	        $scope.currentUser = {};
	
	        UserService.getCurrentUser().success(function (data) {
	            $scope.currentUser = data;
	        }).error(function (data) {
	            $scope.parseErrorMessage(data);
	        });
	
	        $scope.rate = 3;
	    }]);
	};

/***/ },
/* 44 */
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
/* 45 */
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
/* 46 */
/*!*******************************************************************!*\
  !*** ./components/user/register-user/register-user-controller.js ***!
  \*******************************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("RegisterUserController", ["$scope", "UserService", function ($scope, UserService) {
	        $scope.user = {};
	
	        $scope.registerUser = function (form) {
	            if (form.$valid) {
	                UserService.saveUser($scope.user).success(function (data) {
	                    console.log(data);
	                }).error(function (data) {
	                    console.log(data);
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
/* 47 */
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
	                    template: __webpack_require__(/*! ./list-users/list-users.html */ 48),
	                    controller: "ListUsersController"
	                }
	            }
	        }).state("app.users.list", {
	            url: "" //<-- Empty string for "app" state to override the / abstract state
	        }).state("app.users.profile", {
	            url: "/profile/:id",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./view-profile/view-profile.html */ 49),
	                    controller: "ViewUserProfileController"
	                }
	            }
	        }).state("app.users.register", {
	            url: "/register",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./register-user/register-user.html */ 50),
	                    controller: "RegisterUserController"
	                }
	            }
	        });
	    }]);
	};

/***/ },
/* 48 */
/*!****************************************************!*\
  !*** ./components/user/list-users/list-users.html ***!
  \****************************************************/
/***/ function(module, exports) {

	module.exports = "<h2>hello</h2>"

/***/ },
/* 49 */
/*!********************************************************!*\
  !*** ./components/user/view-profile/view-profile.html ***!
  \********************************************************/
/***/ function(module, exports) {

	module.exports = "<h2>Profile view here</h2>\r\n{{user | json}}\r\n<br />\r\n<button class=\"btn btn-danger\" ng-click=\"deleteProfile(user.id);\">Delete profile</button>"

/***/ },
/* 50 */
/*!**********************************************************!*\
  !*** ./components/user/register-user/register-user.html ***!
  \**********************************************************/
/***/ function(module, exports) {

	module.exports = "<h3>Create account</h3>\r\n<form class=\"form-horizontal\" enctype=\"multipart/form-data\" name=\"registerForm\" novalidate>\r\n    <div class=\"form-group\">\r\n        <label for=\"name\" class=\"control-label col-md-2\">Name</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.name\" id=\"name\" required type=\"text\" class=\"form-control\" placeholder=\"Enter your first name here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"surname\" class=\"control-label col-md-2\">Surname</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.surname\" id=\"surname\" required type=\"text\" class=\"form-control\" placeholder=\"Enter your last name here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"email\" class=\"control-label col-md-2\">Email</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.email\" id=\"email\" required type=\"email\" class=\"form-control\" placeholder=\"Enter your email here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"username\" class=\"control-label col-md-2\">Username</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.username\" id=\"username\" required type=\"text\" class=\"form-control\" placeholder=\"Enter your username here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"password\" class=\"control-label col-md-2\">Password</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.password\" id=\"password\" required type=\"password\" class=\"form-control\" placeholder=\"Enter your password here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"image\" class=\"control-label col-md-2\">Image</label>\r\n        <div class=\"col-md-10\">\r\n            <input id=\"image\" type=\"file\" accept=\"image/*\" file-model=\"user.image\" class=\"form-control\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-3\">\r\n            <button ng-click=\"resetForm();\" class=\"btn btn-danger btn-block\"><i class=\"glyphicon glyphicon-alert\"></i> Reset form</button>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <button ng-click=\"registerUser(registerForm);\" ng-disabled=\"registerForm.$invalid\" class=\"btn btn-success btn-block\"><i class=\"glyphicon glyphicon-check\"></i> Register</button>\r\n        </div>\r\n    </div>\r\n</form>"

/***/ },
/* 51 */
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
/* 52 */
/*!****************************!*\
  !*** ./admin ^\.\/.*\.js$ ***!
  \****************************/
/***/ function(module, exports, __webpack_require__) {

	var map = {
		"./config.js": 53
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
	webpackContext.id = 52;


/***/ },
/* 53 */
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
	                    template: __webpack_require__(/*! app/admin/home.html */ 54)
	                }
	            }
	        });
	    }]);
	};

/***/ },
/* 54 */
/*!*************************!*\
  !*** ./admin/home.html ***!
  \*************************/
/***/ function(module, exports) {

	module.exports = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title></title>\r\n\t<meta charset=\"utf-8\" />\r\n</head>\r\n<body>\r\n\r\n</body>\r\n</html>\r\n"

/***/ }
]);
//# sourceMappingURL=bundle.js.map