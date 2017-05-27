(function (angular) {
  angular.module('plotlyjs', [])
    .factory('plotly', plotly);

  plotly.$inject = ['$window'];

  function plotly($window) {
    if ($window.Plotly) {
      $window._thirdParty = $window._thirdParty || {};
      $window._thirdParty.Plotly = $window.Plotly;
      try {
        delete $window.Plotly;
      } catch (e) {
        $window.Plotly = undefined;
      }
    }

    return  $window._thirdParty.Plotly;
  };
})(angular);