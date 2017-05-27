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
      accountService.login(vm.loginUser)
      .then(response => loginCompleted(response))
      .catch(response => loginFailed(response));
    }

    function loginFailed(response) {
      notificationService.displayError(response.data);
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
      accountService.register(vm.registerUser)
      .then(response => registerCompleted(response))
      .catch(response => registrationFailed());
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

    function registrationFailed() {
      notificationService.displayError('Registration failed. Try again.');
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