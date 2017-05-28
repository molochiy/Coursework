(function (angular) {

  angular
    .module("appModule")
    .factory("problemService", problemService);

  problemService.$inject = ['apiService', 'notificationService'];

  function problemService(apiService) {
    function addProblem(problemData) {
      return apiService.post('api/problem/', problemData);
    }

    function getProblemHistory(problemTypeId) {
      return apiService.get('api/problem/all?problemTypeId=' + problemTypeId, null);
    }

    function getProblemResult(problemId, problemTypeId) {
      return apiService.get('api/results?problemId=' + problemId + '&problemTypeId=' + problemTypeId, null);
    }

    var service = {
      addProblem,
      getProblemHistory,
      getProblemResult
    }

    return service;
  }
})(angular)