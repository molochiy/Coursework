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
    vm.swapProblem = swapProblem;

    function solve() {
      console.log(vm.problemInputData);
    }

    function swapProblem() {
      vm.isFirstProblemSelected = !vm.isFirstProblemSelected;
    }

    function swapGraph() {
      vm.isFirstGraphShowing = !vm.isFirstGraphShowing;
    }

    function init() {
      if (!$scope.$parent.rootCtrl.userData.isUserLoggedIn) {
        $location.path('/');
      }

      vm.isFirstGraphShowing = true;
      vm.isFirstProblemSelected = true;
    }

    init();
  }
})(angular);