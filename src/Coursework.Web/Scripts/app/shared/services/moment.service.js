﻿(function (angular) {
  angular.module("appModule")
    .factory('moment', moment);

  moment.$inject = ['$window'];

  function moment($window) {
    if ($window.moment) {
      $window._thirdParty = $window._thirdParty || {};
      $window._thirdParty.moment = $window.moment;
      try {
        delete $window.moment;
      } catch (e) {
        $window.moment = undefined;
      }
    }

    return  $window._thirdParty.moment;
  };
})(angular);