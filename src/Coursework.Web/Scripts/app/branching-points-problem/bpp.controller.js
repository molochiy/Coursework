(function (angular) {

  angular
      .module("appModule")
      .controller("bppController", bppController);

  bppController.$inject = ['$scope', '$location', 'PROBLEM_TYPE_IDS', 'problemService', 'notificationService'];

  function bppController($scope, $location, PROBLEM_TYPE_IDS, problemService, notificationService) {
    var vm = this;

    vm.variables = {
      problemsHistory: [],
      problemInputData: {},
      selectedProblemId: -1,
      formulationProblemType: 1
    }

    vm.fucntions = {
      swapProblemType,
      isFirstProblemSelected,
      swapGraph,
      solve,
      show,
      refreshHistory
    }

    function swapProblemType() {
      vm.variables.problemInputData.typeId = vm.fucntions.isFirstProblemSelected() ? PROBLEM_TYPE_IDS.PROBLEM22 : PROBLEM_TYPE_IDS.PROBLEM21;
      getHistory();
      vm.variables.formulationProblemType = vm.variables.formulationProblemType === 1 ? 2 : 1;
      vm.variables.plotInfo = null;
    }

    function isFirstProblemSelected() {
      return vm.variables.problemInputData.typeId === PROBLEM_TYPE_IDS.PROBLEM21;
    }

    function swapGraph() {
      vm.variables.isFirstGraphShowing = !vm.variables.isFirstGraphShowing;
    }

    function solve() {
      problemService.addProblem(vm.variables.problemInputData)
      .then(response => {
        notificationService.displaySuccess('Problem is added.');
        console.log(response);
        vm.variables.problemsHistory.push(response.data);
      })
      .catch(response => {
        onError(response);
      });
    }

    function show() {
      if (vm.variables.selectedProblemId !== -1) {
        console.log(vm.variables.selectedProblemId);
        }

      problemService.getProblemResult(vm.variables.selectedProblemId, vm.variables.problemInputData.typeId)
          .then(response => {
              console.log(response);
              vm.variables.chartInfo = response.data.result.branchingLines;
          })
           .catch(response => {
          console.log(response);
        });
    }

    function refreshHistory() {
      getHistory();
    }

    function getHistory() {
      problemService.getProblemHistory(vm.variables.problemInputData.typeId)
      .then(response => {
        $scope.$applyAsync(() => {
          while (vm.variables.problemsHistory.length > 0) {
            vm.variables.problemsHistory.pop();
          }
          vm.variables.problemsHistory.push.apply(vm.variables.problemsHistory, response.data);
        });
      })
      .catch(response => {
        onError(response);
      });
    }

    function onError(response) {
      console.log(response);
      notificationService.displayError(response.data.message);
    }

    function init() {
      if (!$scope.$parent.rootCtrl.userData.isUserLoggedIn) {
        $location.path('/');
      }

      vm.variables.isFirstGraphShowing = true;
      vm.variables.problemInputData.typeId = PROBLEM_TYPE_IDS.PROBLEM21;
      getHistory();
      $scope.$applyAsync(() => {
          vm.variables.chartInfo = null;
          vm.variables.formulationProblemType = 1;
      });
    }

    init();
  }
})(angular);