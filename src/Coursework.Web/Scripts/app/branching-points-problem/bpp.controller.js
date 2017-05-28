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
      show
    }

    function swapProblemType() {
      vm.variables.problemInputData.typeId = vm.fucntions.isFirstProblemSelected() ? PROBLEM_TYPE_IDS.PROBLEM22 : PROBLEM_TYPE_IDS.PROBLEM21;
      getHistory();
      vm.variables.formulationProblemType = vm.variables.formulationProblemType === 1 ? 2 : 1;
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
      vm.variables.chartInfo = {
          x: [1, 1.05, 1.1, 1.15, 1.2, 1.25, 1.3, 1.35, 1.4, 1.45, 1.5, 1.55, 1.6, 1.65, 1.7, 1.75, 1.8, 1.85, 1.9, 1.95,
              2, 2.05, 2.1, 2.15, 2.2, 2.25, 2.3, 2.35, 2.4, 2.45, 2.5, 2.55, 2.6, 2.65, 2.7, 2.75, 2.8, 2.85, 2.9, 2.95,
              3, 3.05, 3.1, 3.15, 3.2, 3.25, 3.3, 3.35, 3.4, 3.45, 3.5, 3.55, 3.6, 3.65, 3.7, 3.75, 3.8, 3.85, 3.9, 3.95,
              4
          ],
          y: [
              0.2004449, 0.6981702, 1, 0.8863916, 0.8693649, 0.9255888, 0.9252481, 0.9181686, 0.9083395,
              0.8699636, 0.8026274, 0.7284968, 0.6636573, 0.6220268, 0.6025350, 0.6044026,
              0.6194048, 0.6394967, 0.6615956, 0.6819725, 0.6950528, 0.6977330, 0.6861988, 0.6608598, 0.6283012, 0.5966283,
              0.5684527, 0.5459441, 0.5288758, 0.5155076, 0.5028279, 0.4901779, 0.4789723, 0.4668821, 0.4546568,
              0.4400940, 0.4197895, 0.3913777, 0.3572283, 0.3095090, 0.2586845, 0.2138608, 0.1920109, 0.0817701, 0.1608082, 0.1412755, 0.1366797, 0.1439412,
              0.1580010, 0.1849124, 0.2152397, 0.2360079, 0.2489110, 0.2511323, 0.2454152, 0.2352743, 0.2265063, 0.2257193, 0.2332029, 0.2486998, 0.2531098
          ]
      }
    }

    function getHistory() {
      problemService.getProblemHistory(vm.variables.problemInputData.typeId)
      .then(response => {
        console.log(response);
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
          vm.variables.chartInfo = {
              x: null,
              y: null,
          }
          vm.variables.formulationProblemType = 1;
      });
    }

    init();
  }
})(angular);