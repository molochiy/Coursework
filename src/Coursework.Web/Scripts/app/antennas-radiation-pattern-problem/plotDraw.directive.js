(function (angular) {

  angular.module('appModule')
      .directive('firstProblemGraphic', firstProblemGraphic);

  function firstProblemGraphic() {
    return {
      restrict: 'E',
      terminal: true,
      replace: true,
      scope: {
        plotInfo: '='
      },
      template: '<div id="plot1" class="plot"></div>',
      link: function (scope, element, attrs) {

        scope.$watch('plotInfo', (newPlotInfo, oldPlotInfo) => {
          if (newPlotInfo && newPlotInfo.plotData) {
            drowPlot(newPlotInfo.plotData);
          }
        }, true);
        function drowPlot(PlotData) {
          if (PlotData) {
            var data = { z: PlotData, type: 'surface' };

            var layout = {
              title: 'First Problem',
              autosize: true,
              margin: {
                l: 10,
                r: 10,
                b: 50,
                t: 30
              }
            };

            Plotly.newPlot('plot1', [data], layout);
          }
        }
      }
    }
  }
})(angular);