(function (angular) {

  angular
      .module("appModule")
      .controller("accountController", accountController);

  accountController.$inject = ['$scope', 'accountService', 'notificationService', '$rootScope', '$location'];

  function accountController($scope, accountService, notificationService, $rootScope, $location) {
    var vm = this;
    vm.pageClass = 'page-login';
    vm.login = login;
    vm.loginUser = {};

    function login() {
      accountService.login(vm.loginUser, loginCompleted);
    }

    function loginCompleted(result) {
      if (result.data.success) {
        accountService.saveCredentials(vm.loginUser);
        notificationService.displaySuccess('Hello ' + vm.loginUser.username);
        $scope.$parent.rootCtrl.userData.displayUserInfo();
        $location.path('/problem1');
      }
      else {
        notificationService.displayError('Login failed. Try again.');
      }
    }

    vm.register = register;
    vm.registerUser = {};

    function register() {
      accountService.register(vm.registerUser, registerCompleted);
    }

    function registerCompleted(result) {
      if (result.data.success) {
        accountService.saveCredentials(vm.registerUser);
        notificationService.displaySuccess('Hello ' + vm.registerUser.username);
        $scope.$parent.rootCtrl.userData.displayUserInfo();
        $location.path('/problem1');
      }
      else {
        notificationService.displayError('Registration failed. Try again.');
      }
    }

    function init() {
      if ($scope.$parent.rootCtrl.userData.isUserLoggedIn) {
        vm.username = $rootScope.repository.loggedUser.username;
        $scope.$parent.rootCtrl.selectFirstProblem();
      }
    }

    init();
  }
})(angular);