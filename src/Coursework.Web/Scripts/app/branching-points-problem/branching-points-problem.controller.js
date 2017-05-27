(function (angular) {

  angular
      .module("appModule")
      .controller("branchingPointsProblemController", branchingPointsProblemController);

  branchingPointsProblemController.$inject = ['$scope', '$location'];

  function branchingPointsProblemController($scope, $location) {
    var vm = this;

    vm.branchingPointsProblem = {
      
    }

    function init() {
      if (!$scope.$parent.rootCtrl.userData.isUserLoggedIn) {
        $location.path('/');
      }
    }

    init();
  }
})(angular);