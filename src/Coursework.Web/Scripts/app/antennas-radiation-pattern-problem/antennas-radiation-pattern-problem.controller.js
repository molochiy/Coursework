(function (angular) {

  angular
      .module("appModule")
      .controller("antennasRadiationPatternProblemController", antennasRadiationPatternProblemController);

  antennasRadiationPatternProblemController.$inject = ['$scope', '$location'];

  function antennasRadiationPatternProblemController($scope, $location) {
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