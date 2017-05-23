(function (angular) {

  angular
      .module("appModule")
      .controller("problem1Controller", problem1Controller);

  problem1Controller.$inject = ['$scope', '$location'];

  function problem1Controller($scope, $location) {
    var vm = this;

    vm.problem1 = {

    }

    function init() {
      if (!$scope.$parent.rootCtrl.userData.isUserLoggedIn) {
        $location.path('/');
      }
    }

    init();

  }
})(angular);