(function (angular) {

  angular
      .module("appModule")
      .controller("problem2Controller", problem2Controller);

  problem2Controller.$inject = ['$scope', '$location'];

  function problem2Controller($scope, $location) {
    var vm = this;

    vm.problem2 = {
      
    }

    function init() {
      if (!$scope.$parent.rootCtrl.userData.isUserLoggedIn) {
        $location.path('/');
      }
    }

    init();
  }
})(angular);