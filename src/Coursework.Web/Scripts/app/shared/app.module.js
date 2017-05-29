(function (angular) {
  angular.module('appModule', ['ngRoute', 'ngCookies', 'base64', 'angularValidator'])
    .config(config)
    .run(run);

  config.$inject = ['$routeProvider', '$locationProvider'];

  function config($routeProvider, $locationProvider) {
    $routeProvider
        .when("/", {
          templateUrl: "Scripts/app/account/pages/account.html",
          controller: "accountController",
          controllerAs: "accountCtrl"
        })
        .when("/problem1", {
          templateUrl: "Scripts/app/antennas-radiation-pattern-problem/pages/arpp.html",
          controller: "arppController",
          controllerAs: "arppCtrl"
        })
        .when("/problem2", {
          templateUrl: "Scripts/app/branching-points-problem/pages/bpp.html",
          controller: "bppController",
          controllerAs: "bppCtrl"
        })
      .otherwise({ redirectTo: "/" });
  }

  run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

  function run($rootScope, $location, $cookieStore, $http) {
    $rootScope.repository = $cookieStore.get('repository') || {};
    if ($rootScope.repository.loggedUser) {
      $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
    }
  }

  isAuthenticated.$inject = ['credentialsService', '$rootScope', '$location'];

  function isAuthenticated(credentialsService, $rootScope, $location) {
    if (!credentialsService.isUserLoggedIn()) {
      $rootScope.previousState = $location.path();
      $location.path('/login');
    }
  }
})(angular);