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
	
	var app = angular.module("StudyBuddies", ["ui.router" /*,
	                                                      "oc.lazyLoad"*/
	]);
	
	__webpack_require__(/*! ./constants */ 1)(app);
	__webpack_require__(/*! ./states */ 2)(app);
	
	__webpack_require__(/*! ./common */ 9)(app);
	
	//webpack context module API
	var requireContext = __webpack_require__(/*! ./components */ 16);
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
/*!*******************!*\
  !*** ./states.js ***!
  \*******************/
/***/ function(module, exports, __webpack_require__) {

	module.exports = function (ngModule) {
	    ngModule.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
	        $urlRouterProvider.otherwise("/"); //for undefined state go to the default/home
	
	        $stateProvider.state("app", {
	            url: "/",
	            views: {
	                "header": {
	                    controller: "HeaderController",
	                    template: __webpack_require__(/*! ./common/header.html */ 3)
	                },
	                "content": {
	                    template: __webpack_require__(/*! ./components/home/content.html */ 4)
	                },
	                "footer": {
	                    controller: "FooterController",
	                    //templateUrl: "./app/home/footer.html"
	                    template: __webpack_require__(/*! ./common/footer.html */ 5)
	                },
	                "left@app": {
	                    template: __webpack_require__(/*! ./components/home/sidebar.html */ 6)
	                },
	                "main@app": {
	                    template: __webpack_require__(/*! ./components/home/home.html */ 7),
	                    controller: "HomeController"
	                }
	            }
	        }).state("app.profile", {
	            url: "profile",
	            views: {
	                "content@": {
	                    template: __webpack_require__(/*! ./components/view-profile/view-profile.html */ 8)
	                }
	            }
	        });;
	    }]);
	};

/***/ },
/* 3 */
/*!****************************!*\
  !*** ./common/header.html ***!
  \****************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"navbar navbar-inverse navbar-fixed-top\">\r\n    <div class=\"container\">\r\n        <div class=\"navbar-header\">\r\n            <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n            </button>\r\n            <a ui-sref=\"app\" class=\"navbar-brand\">{{ siteName }}</a>\r\n        </div>\r\n        <div class=\"navbar-collapse collapse\">\r\n            <ul class=\"nav navbar-nav\"></ul>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ },
/* 4 */
/*!**************************************!*\
  !*** ./components/home/content.html ***!
  \**************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"row\">\r\n    <div ui-view=\"left\" class=\"col-md-4\"></div>\r\n    <div ui-view=\"main\" class=\"col-md-8\"></div>\r\n</div>"

/***/ },
/* 5 */
/*!****************************!*\
  !*** ./common/footer.html ***!
  \****************************/
/***/ function(module, exports) {

	module.exports = "<hr />\r\n<footer>\r\n    <p>&copy; {{ currentYear }} - {{ siteName }}</p>\r\n</footer>"

/***/ },
/* 6 */
/*!**************************************!*\
  !*** ./components/home/sidebar.html ***!
  \**************************************/
/***/ function(module, exports) {

	module.exports = "<h1>aside</h1>"

/***/ },
/* 7 */
/*!***********************************!*\
  !*** ./components/home/home.html ***!
  \***********************************/
/***/ function(module, exports) {

	module.exports = "<h2>wassup!</h2>\r\n{{ users | json }}"

/***/ },
/* 8 */
/*!***************************************************!*\
  !*** ./components/view-profile/view-profile.html ***!
  \***************************************************/
/***/ function(module, exports) {

	module.exports = "<h2>Profile view here</h2>"

/***/ },
/* 9 */
/*!*************************!*\
  !*** ./common/index.js ***!
  \*************************/
/***/ function(module, exports, __webpack_require__) {

	// list all the componenets u want included
	// i.e. list all the dependencies
	module.exports = function (ngModule) {
	    __webpack_require__(/*! ./header-controller */ 10)(ngModule);
	    __webpack_require__(/*! ./footer-controller */ 11)(ngModule);
	    __webpack_require__(/*! ./style.css */ 12);
	};

/***/ },
/* 10 */
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
/* 11 */
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
/* 12 */
/*!**************************!*\
  !*** ./common/style.css ***!
  \**************************/
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(/*! !./../../~/css-loader!./style.css */ 13);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(/*! ./../../~/style-loader/addStyles.js */ 15)(content, {});
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
/* 13 */
/*!******************************************!*\
  !*** ../~/css-loader!./common/style.css ***!
  \******************************************/
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(/*! ./../../~/css-loader/lib/css-base.js */ 14)();
	// imports
	
	
	// module
	exports.push([module.id, "[ui-view=\"content\"] {\r\n    margin-top: 65px;\r\n}", ""]);
	
	// exports


/***/ },
/* 14 */,
/* 15 */,
/* 16 */
/*!*********************************!*\
  !*** ./components ^\.\/.*\.js$ ***!
  \*********************************/
/***/ function(module, exports, __webpack_require__) {

	var map = {
		"./_services/user-service.js": 34,
		"./home/home-controller.js": 17,
		"./view-profile/view-profile.js": 18
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
	webpackContext.id = 16;


/***/ },
/* 17 */
/*!********************************************!*\
  !*** ./components/home/home-controller.js ***!
  \********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("HomeController", ["$scope", "UserService", function ($scope, UserService) {
	        $scope.users = [];
	
	        UserService.getAllUsers().success(function (response) {
	            $scope.users = response;
	        }).error(function () {
	            console.log("error!!");
	        });
	    }]);
	};

/***/ },
/* 18 */
/*!*************************************************!*\
  !*** ./components/view-profile/view-profile.js ***!
  \*************************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.controller("ViewUserProfileController", ["$scope", function ($scope) {
	        console.log("view it!");
	    }]);
	};

/***/ },
/* 19 */,
/* 20 */,
/* 21 */,
/* 22 */,
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
/* 34 */
/*!**********************************************!*\
  !*** ./components/_services/user-service.js ***!
  \**********************************************/
/***/ function(module, exports) {

	module.exports = function (ngModule) {
	    ngModule.factory("UserService", ["$http", "$location", function ($http, $location) {
	        var factory = {};
	
	        factory.getAllUsers = function () {
	            return $http.get("/api/user");
	        };
	
	        return factory;
	    }]);
	};

/***/ }
]);
//# sourceMappingURL=bundle.js.map