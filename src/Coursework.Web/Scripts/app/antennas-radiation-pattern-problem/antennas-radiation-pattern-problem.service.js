(function(angular) {

  angular
    .module("appModule")
    .factory("antennasRadiationPatternProblemService", antennasRadiationPatternProblemService);

  antennasRadiationPatternProblemService.$inject = ['apiService', 'notificationService'];

  function antennasRadiationPatternProblemService(apiService) {
    function addProblem(problemData) {
      return apiService.post('api/problem/', problemData);
    }

    function getProblemHistory(problemTypeId) {
      return apiService.get('api/problem/all?problemTypeId=' + problemTypeId, null);
    }

    var service = {
      addProblem,
      getProblemHistory/*,
      getProblemResult*/
    }

    return service;
  }
})(angular)