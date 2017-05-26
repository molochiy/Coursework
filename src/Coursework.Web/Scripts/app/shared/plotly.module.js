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

    var plotlyjs = $window._thirdParty.Plotly;
    return plotlyjs;
  };
})(angular);