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
          templateUrl: "Scripts/app/antennas-radiation-pattern-problem/pages/antennas-radiation-pattern-problem.html",
          controller: "antennasRadiationPatternProblemController",
          controllerAs: "aRPPCtrl"
        })
        .when("/problem2", {
          templateUrl: "Scripts/app/branching-points-problem/pages/branching-points-problem.html",
          controller: "branchingPointsProblemController",
          controllerAs: "bPPCtrl"
        })
        //.when("/customers", {
        //  templateUrl: "scripts/spa/customers/problems.html",
        //  controller: "customersCtrl"
        //})
        //.when("/customers/register", {
        //  templateUrl: "scripts/spa/customers/register.html",
        //  controller: "customersRegCtrl",
        //  resolve: { isAuthenticated: isAuthenticated }
        //})
      .otherwise({ redirectTo: "/" });

    //$locationProvider.html5Mode(true);
  }

  run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

  function run($rootScope, $location, $cookieStore, $http) {
    // handle page refreshes
    $rootScope.repository = $cookieStore.get('repository') || {};
    if ($rootScope.repository.loggedUser) {
      $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
    }
  }

  isAuthenticated.$inject = ['accountService', '$rootScope', '$location'];

  function isAuthenticated(accountService, $rootScope, $location) {
    if (!accountService.isUserLoggedIn()) {
      $rootScope.previousState = $location.path();
      $location.path('/login');
    }
  }
})(angular);