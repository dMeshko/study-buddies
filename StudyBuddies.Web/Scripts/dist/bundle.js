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
	
	var app = angular.module("StudyBuddies", ["ui.router", "angular-loading-bar"
	//"oc.lazyLoad"
	]);
	
	__webpack_require__(/*! ./constants */ 1)(app);
	__webpack_require__(/*! ./config */ 2)(app);
	
	__webpack_require__(/*! ./common */ 11)(app);
	
	//webpack context module API
	var requireContext = __webpack_require__(/*! ./components */ 18);
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
	    __webpack_require__(/*! ./config */ 3)(ngModule);
	    __webpack_require__(/*! ./states */ 4)(ngModule);
	};

/***/ },
/* 3 */
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
/* 4 */
/*!**************************!*\
  !*** ./config/states.js ***!
  \**************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
	        $urlRouterProvider.otherwise("/"); //for undefined state go to the default/home
	
	        $stateProvider.state("app", {
	            url: "/",
	            views: {
	                "header": {
	                    controller: "HeaderController",
	                    template: __webpack_require__(/*! app/common/header.html */ 5)
	                },
	                "content": {
	                    template: __webpack_require__(/*! app/components/home/content.html */ 6)
	                },
	                "footer": {
	                    controller: "FooterController",
	                    //templateUrl: "./app/home/footer.html"
	                    template: __webpack_require__(/*! app/common/footer.html */ 7)
	                },
	                "left@app": {
	                    template: __webpack_require__(/*! app/components/home/sidebar.html */ 8),
	                    controller: "SidebarController"
	                },
	                "main@app": {
	                    template: __webpack_require__(/*! app/components/home/home.html */ 9),
	                    controller: "HomeController"
	                }
	            }
	        }).state("app.profile", {
	            url: "profile/:id",
	            views: {
	                "main@app": {
	                    template: __webpack_require__(/*! app/components/view-profile/view-profile.html */ 10),
	                    controller: "ViewUserProfileController"
	                }
	            }
	        }).state("app.register", {
	            url: "register",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! app/components/register-user/register-user.html */ 49),
	                    controller: "RegisterUserController"
	                }
	            }
	        });
	    }]);
	};

/***/ },
/* 5 */
/*!****************************!*\
  !*** ./common/header.html ***!
  \****************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"navbar navbar-inverse navbar-fixed-top\">\r\n    <div class=\"container\">\r\n        <div class=\"navbar-header\">\r\n            <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n            </button>\r\n            <a ui-sref=\"app\" class=\"navbar-brand\">{{ siteName }}</a>\r\n        </div>\r\n        <div class=\"navbar-collapse collapse\">\r\n            <ul class=\"nav navbar-nav\">\r\n                <li><a ui-sref=\"app\">Home</a></li>\r\n                <li><a ui-sref=\"app.profile\">Profile</a></li>\r\n                <li><a ui-sref=\"app.register\">Register</a></li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ },
/* 6 */
/*!**************************************!*\
  !*** ./components/home/content.html ***!
  \**************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div ui-view=\"left\" class=\"col-md-4\"></div>\r\n    <div ui-view=\"main\" class=\"col-md-8\"></div>\r\n</div>"

/***/ },
/* 7 */
/*!****************************!*\
  !*** ./common/footer.html ***!
  \****************************/
/***/ function(module, exports) {

	module.exports = "<hr />\r\n<footer>\r\n    <p>&copy; {{ currentYear }} - {{ siteName }}</p>\r\n</footer>"

/***/ },
/* 8 */
/*!**************************************!*\
  !*** ./components/home/sidebar.html ***!
  \**************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div class=\"col-md-5\">\r\n        <img class=\"img img-responsive\" ng-src =\"data:image/png;base64,{{currentUser.image}}\" />\r\n    </div>\r\n    <div class=\"col-md-7\">\r\n        <h3>{{ currentUser.fullName }}</h3>\r\n    </div>\r\n</div>"

/***/ },
/* 9 */
/*!***********************************!*\
  !*** ./components/home/home.html ***!
  \***********************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"well\" ng-repeat=\"user in users | orderBy: '-rating'\">\r\n    <featured-user user=\"user\" />\r\n</div>"

/***/ },
/* 10 */
/*!***************************************************!*\
  !*** ./components/view-profile/view-profile.html ***!
  \***************************************************/
/***/ function(module, exports) {

	module.exports = "<h2>Profile view here</h2>\r\n{{user | json}}"

/***/ },
/* 11 */
/*!*************************!*\
  !*** ./common/index.js ***!
  \*************************/
/***/ function(module, exports, __webpack_require__) {

	// list all the componenets u want included
	// i.e. list all the dependencies
	module.exports = function (ngModule) {
	    __webpack_require__(/*! ./header-controller */ 12)(ngModule);
	    __webpack_require__(/*! ./footer-controller */ 13)(ngModule);
	
	    __webpack_require__(/*! ./style.css */ 14);
	};

/***/ },
/* 12 */
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
/* 13 */
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
/* 14 */
/*!**************************!*\
  !*** ./common/style.css ***!
  \**************************/
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(/*! !./../../~/css-loader!./style.css */ 15);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(/*! ./../../~/style-loader/addStyles.js */ 17)(content, {});
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
/* 15 */
/*!******************************************!*\
  !*** ../~/css-loader!./common/style.css ***!
  \******************************************/
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(/*! ./../../~/css-loader/lib/css-base.js */ 16)();
	// imports
	
	
	// module
	exports.push([module.id, "[ui-view=\"content\"] {\r\n    margin-top: 65px;\r\n}\r\n\r\n#loading-bar .bar {\r\n  background: white;\r\n}", ""]);
	
	// exports


/***/ },
/* 16 */,
/* 17 */,
/* 18 */
/*!*********************************!*\
  !*** ./components ^\.\/.*\.js$ ***!
  \*********************************/
/***/ function(module, exports, __webpack_require__) {

	var map = {
		"./_directives/featured-user/featured-user-directive.js": 53,
		"./_directives/file-model-directive.js": 51,
		"./_services/user-service.js": 19,
		"./home/home-controller.js": 20,
		"./home/sidebar-controller.js": 21,
		"./register-user/register-user-controller.js": 47,
		"./view-profile/view-profile.js": 22
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
	webpackContext.id = 18;


/***/ },
/* 19 */
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
	
	            return $http.get("/api/user/", { params: params });
	        };
	
	        factory.getAllUsers = function () {
	            return $http.get("/api/user");
	        };
	
	        factory.getCurrentUser = function () {
	            var currentUserId = "C07806DE-3C03-4140-8E75-A6B400BDF2B9";
	
	            var params = {
	                id: currentUserId
	            };
	
	            return $http.get("/api/user/", { params: params });
	        };
	
	        factory.saveUser = function (user) {
	            var fd = new FormData();
	
	            fd.append("name", user.name);
	            fd.append("surname", user.surname);
	            fd.append("email", user.email);
	            fd.append("username", user.username);
	            fd.append("password", user.password);
	
	            if (user.image) fd.append("file[]", user.image);
	
	            var data = fd;
	            var config = {
	                headers: { 'Content-Type': undefined },
	                transformRequest: angular.identity
	            };
	
	            return $http.post("/api/user", data, config);
	        };
	
	        return factory;
	    }]);
	};

/***/ },
/* 20 */
/*!********************************************!*\
  !*** ./components/home/home-controller.js ***!
  \********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("HomeController", ["$scope", "UserService", function ($scope, UserService) {
	        $scope.users = [];
	
	        UserService.getAllUsers().success(function (data) {
	            $scope.users = data;
	        }).error(function (data) {
	            console.log("Unable to fetch the users!! " + data);
	        });
	    }]);
	};

/***/ },
/* 21 */
/*!***********************************************!*\
  !*** ./components/home/sidebar-controller.js ***!
  \***********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("SidebarController", ["$scope", "UserService", function ($scope, UserService) {
	        $scope.currentUser = {};
	
	        UserService.getCurrentUser().success(function (data) {
	            $scope.currentUser = data;
	        }).error(function (data) {
	            console.log("Error fetching the current user!! " + data);
	        });
	    }]);
	};

/***/ },
/* 22 */
/*!*************************************************!*\
  !*** ./components/view-profile/view-profile.js ***!
  \*************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("ViewUserProfileController", ["$scope", "$stateParams", "UserService", function ($scope, $stateParams, UserService) {
	        $scope.user = {};
	
	        UserService.getUserById($stateParams.id).success(function (data) {
	            $scope.user = data;
	        }).error(function (data) {
	            console.log("Error getting the user details");
	        });
	    }]);
	};

/***/ },
/* 23 */,
/* 24 */,
/* 25 */,
/* 26 */,
/* 27 */,
/* 28 */,
/* 29 */,
/* 30 */,
/* 31 */,
/* 32 */,
/* 33 */,
/* 34 */,
/* 35 */,
/* 36 */,
/* 37 */,
/* 38 */,
/* 39 */,
/* 40 */,
/* 41 */,
/* 42 */,
/* 43 */,
/* 44 */,
/* 45 */,
/* 46 */,
/* 47 */
/*!**************************************************************!*\
  !*** ./components/register-user/register-user-controller.js ***!
  \**************************************************************/
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
/* 48 */,
/* 49 */
/*!*****************************************************!*\
  !*** ./components/register-user/register-user.html ***!
  \*****************************************************/
/***/ function(module, exports) {

	module.exports = "<h3>Create account</h3>\r\n<form class=\"form-horizontal\" enctype=\"multipart/form-data\" name=\"registerForm\" novalidate>\r\n    <div class=\"form-group\">\r\n        <label for=\"name\" class=\"control-label col-md-2\">Name</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.name\" id=\"name\" required type=\"text\" class=\"form-control\" placeholder=\"Enter your first name here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"surname\" class=\"control-label col-md-2\">Surname</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.surname\" id=\"surname\" required type=\"text\" class=\"form-control\" placeholder=\"Enter your last name here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"email\" class=\"control-label col-md-2\">Email</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.email\" id=\"email\" required type=\"email\" class=\"form-control\" placeholder=\"Enter your email here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"username\" class=\"control-label col-md-2\">Username</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.username\" id=\"username\" required type=\"text\" class=\"form-control\" placeholder=\"Enter your username here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"password\" class=\"control-label col-md-2\">Password</label>\r\n        <div class=\"col-md-10\">\r\n            <input ng-model=\"user.password\" id=\"password\" required type=\"password\" class=\"form-control\" placeholder=\"Enter your password here\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"image\" class=\"control-label col-md-2\">Image</label>\r\n        <div class=\"col-md-10\">\r\n            <input id=\"image\" type=\"file\" accept=\"image/*\" file-model=\"user.image\" class=\"form-control\"/>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-3\">\r\n            <button ng-click=\"resetForm();\" class=\"btn btn-danger btn-block\"><i class=\"glyphicon glyphicon-alert\"></i> Reset form</button>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <button ng-click=\"registerUser(registerForm);\" ng-disabled=\"registerForm.$invalid\" class=\"btn btn-success btn-block\"><i class=\"glyphicon glyphicon-check\"></i> Register</button>\r\n        </div>\r\n    </div>\r\n</form>"

/***/ },
/* 50 */,
/* 51 */
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
/* 52 */,
/* 53 */
/*!*************************************************************************!*\
  !*** ./components/_directives/featured-user/featured-user-directive.js ***!
  \*************************************************************************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.directive("featuredUser", function () {
	        return {
	            restrict: "E",
	            replace: true,
	            template: __webpack_require__(/*! ./featured-user.html */ 54),
	            scope: {
	                "user": "="
	            }
	        };
	    });
	};

/***/ },
/* 54 */
/*!*****************************************************************!*\
  !*** ./components/_directives/featured-user/featured-user.html ***!
  \*****************************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        <img class=\"img img-responsive\" ng-src=\"data:image/png;base64,{{ user.image }}\" />\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n        <h4>{{ user.fullName }}</h4>\r\n        <p><i class=\"glyphicon glyphicon-star\"></i> Rating: {{ user.rating }}</p>\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n        <button class=\"btn btn-success btn-block\">\r\n            <i class=\"glyphicon glyphicon-education\"></i> Buddy up\r\n        </button>\r\n        <button ui-sref=\"app.profile({id: user.id})\" class=\"btn btn-warning btn-block\">\r\n            <i class=\"glyphicon glyphicon-eye-open\"></i> Preview\r\n        </button>\r\n    </div>\r\n</div>"

/***/ }
]);
//# sourceMappingURL=bundle.js.map