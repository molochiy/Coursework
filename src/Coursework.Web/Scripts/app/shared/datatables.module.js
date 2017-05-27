(function (angular) {
  angular.module('datatablesjs', [])
    .factory('datatables', datatables);

  datatables.$inject = ['$window'];

  function datatables($window) {
    if ($window.datatables) {
      $window._thirdParty = $window._thirdParty || {};
      $window._thirdParty.datatables = $window.datatables;
      try {
        delete $window.datatables;
      } catch (e) {
        $window.datatables = undefined;
      }
    }

    return  $window._thirdParty.datatables;
  };
})(angular);