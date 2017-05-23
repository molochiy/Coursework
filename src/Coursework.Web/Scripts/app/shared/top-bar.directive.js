(function (angular) {

  angular.module('appModule')
  .directive('topBar', topBar);

  function topBar() {
    return {
      restrict: 'E',
      replace: true,
      templateUrl: '/Scripts/app/shared/pages/topBar.html'
    }
  }
})(angular);