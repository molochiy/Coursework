(function (angular) {
  angular.module("appModule")
    .constant('PROBLEM_TYPE_IDS', problemTypeIds());

  function problemTypeIds() {
    return {
      PROBLEM11: 1,
      PROBLEM12: 2,
      PROBLEM21: 3,
      PROBLEM22: 4
    }
  }
})(angular);