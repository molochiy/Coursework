(function (angular) {
  angular.module('appModule')
    .controller('rootController', rootController);

  rootController.$inject = ['$scope', '$location', 'accountService', '$rootScope'];
  function rootController($scope, $location, accountService, $rootScope) {
    var vm = this;

    vm.userData = {};

    vm.userData.displayUserInfo = displayUserInfo;
    vm.logout = logout;

    vm.selectFirstProblem = selectFirstProblem;
    vm.selectSecondProblem = selectSecondProblem;

    function selectFirstProblem() {
      vm.isFirstProblemSelected = true;
      $location.path('/problem1');
    }

    function selectSecondProblem() {
      vm.isFirstProblemSelected = false;
      $location.path('/problem2');
    }

    function displayUserInfo() {
      vm.userData.isUserLoggedIn = accountService.isUserLoggedIn();

      if (vm.userData.isUserLoggedIn) {
        vm.username = $rootScope.repository.loggedUser.username;
        selectFirstProblem();
      }
    }

    function logout() {
      accountService.removeCredentials();
      $location.path('/');
      vm.userData.displayUserInfo();
    }

    function init() {
      vm.userData.displayUserInfo();
    }

    init();
  }

})(angular);