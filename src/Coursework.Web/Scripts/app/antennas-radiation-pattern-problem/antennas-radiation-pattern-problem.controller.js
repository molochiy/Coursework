(function (angular) {

  angular
      .module("appModule")
      .controller("antennasRadiationPatternProblemController", antennasRadiationPatternProblemController);

  antennasRadiationPatternProblemController.$inject = ['$scope', '$location', 'PROBLEM_TYPE_IDS', 'antennasRadiationPatternProblemService', 'notificationService'];

  function antennasRadiationPatternProblemController($scope, $location, PROBLEM_TYPE_IDS, antennasRadiationPatternProblemService, notificationService) {
    var vm = this;

    vm.problemsHistory = [];

    vm.problemInputData = {};

    vm.solve = solve;
    vm.swapGraph = swapGraph;
    vm.swapProblem = swapProblem;
    vm.isFirstProblemSelected = isFirstProblemSelected;

    function solve() {
      antennasRadiationPatternProblemService.addProblem(vm.problemInputData)
      .then(response => {
        notificationService.displaySuccess('Problem is added.');
        console.log(response);
      })
      .catch(response => {
        onError(response);
      });
    }

    function onError(response) {
      console.log(response);
      notificationService.displayError(response.data.message);
    }

    function swapProblem() {
      vm.problemInputData.typeId = vm.isFirstProblemSelected() ? PROBLEM_TYPE_IDS.PROBLEM12 : PROBLEM_TYPE_IDS.PROBLEM11;
    }

    function swapGraph() {
      vm.isFirstGraphShowing = !vm.isFirstGraphShowing;
    }


    function getHistory() {
      antennasRadiationPatternProblemService.getProblemHistory(vm.problemInputData.typeId)
      .then(response => {
        console.log(response);
          $scope.$applyAsync(() => {
            vm.problemsHistory.push.apply(vm.problemsHistory, response.data);
          });
        })
      .catch(response => {
        onError(response);
      });
    }

    function isFirstProblemSelected() {
      return vm.problemInputData.typeId === PROBLEM_TYPE_IDS.PROBLEM11;
    }

    function init() {
      if (!$scope.$parent.rootCtrl.userData.isUserLoggedIn) {
        $location.path('/');
      }

      vm.isFirstGraphShowing = true;
      vm.problemInputData.typeId = PROBLEM_TYPE_IDS.PROBLEM11;
      getHistory();
    }

    init();
  }
})(angular);