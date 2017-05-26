(function (angular) {
  angular.module('nicescrolljs', [])
    .factory('nicescroll', nicescroll);

  nicescroll.$inject = ['$window'];

  function nicescroll($window) {
    if ($window.nicescroll) {
      $window._thirdParty = $window._thirdParty || {};
      $window._thirdParty.nicescroll = $window.nicescroll;
      try {
        delete $window.nicescroll;
      } catch (e) {
        $window.nicescroll = undefined;
      }
    }
    var nicescrolljs = $window._thirdParty.nicescroll;
    return nicescrolljs;
  };
})(angular);