﻿(function (angular) {

  angular
      .module("appModule")
      .controller("arppController", arppController);

  arppController.$inject = ['$scope', '$location', 'PROBLEM_TYPE_IDS', 'problemService', 'notificationService'];

  function arppController($scope, $location, PROBLEM_TYPE_IDS, problemService, notificationService) {
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
      showResult,
      refreshHistory
    }

    function swapProblemType() {
      vm.variables.problemInputData.typeId = vm.fucntions.isFirstProblemSelected() ? PROBLEM_TYPE_IDS.PROBLEM12 : PROBLEM_TYPE_IDS.PROBLEM11;
      getHistory();
      vm.variables.formulationProblemType = vm.variables.formulationProblemType === 1 ? 2 : 1;
      vm.variables.plotInfo = null;
    }

    function isFirstProblemSelected() {
      return vm.variables.problemInputData.typeId === PROBLEM_TYPE_IDS.PROBLEM11;
    }

    function swapGraph() {
      if (vm.variables.plotInfo.plotType === 2){
        vm.variables.plotInfo = {
          z: vm.variables.result.f,
          x: vm.variables.result.fx,
          y: vm.variables.result.fy,
          plotType: 1
        }
      }
      else {
        vm.variables.plotInfo = {
          z: vm.variables.result.i,
          x: vm.variables.result.ix,
          y: vm.variables.result.iy,
          plotType: 2
        }
      }

    }

    function showResult() {
      if (vm.variables.selectedProblemId !== -1) {
        console.log(vm.variables.selectedProblemId);

        problemService.getProblemResult(vm.variables.selectedProblemId, vm.variables.problemInputData.typeId)
        .then(response => {
          console.log(response);
          vm.variables.result = {
            f: response.data.result.f,
            fx: response.data.result.fx,
            fy: response.data.result.fy,
            i: response.data.result.i,
            ix: response.data.result.ix,
            iy: response.data.result.iy
          }

          vm.variables.plotInfo = {
            z: vm.variables.result.f,
            x: vm.variables.result.fx,
            y: vm.variables.result.fy,
            plotType: 1
          }
        })
        .catch(response => {
          console.log(response);
        });
      }
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
      vm.variables.problemInputData.typeId = PROBLEM_TYPE_IDS.PROBLEM11;
      getHistory();
      $scope.$applyAsync(() => {
        vm.variables.plotInfo = null;
        vm.variables.formulationProblemType = 1;
      });
    }

    init();
  }
})(angular);