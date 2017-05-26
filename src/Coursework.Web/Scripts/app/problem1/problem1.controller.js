(function (angular) {

  angular
      .module("appModule")
      .controller("problem1Controller", problem1Controller);

  problem1Controller.$inject = ['$scope', '$location'];

  function problem1Controller($scope, $location) {
    var vm = this;

    vm.problemInputData = {};

    vm.solve = solve;
    vm.swapGraph = swapGraph;

    function solve() {
      console.log(vm.problemInputData);
    }

    function swapGraph() {
      vm.isFirstGraphShowing = !vm.isFirstGraphShowing;
    }

    function init() {
      if (!$scope.$parent.rootCtrl.userData.isUserLoggedIn) {
        $location.path('/');
      }

      vm.isFirstGraphShowing = true;
    }

    init();
  }
})(angular);