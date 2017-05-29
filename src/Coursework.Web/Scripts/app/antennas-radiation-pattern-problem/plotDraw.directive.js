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
            drowPlot(newPlotInfo);
            changePlotArrowVisibility(true);
          } else {
            changePlotArrowVisibility(false);
            $('#plot1').empty();
          }
        }, true);

        function drowPlot(plotInfo) {
          var plotTitle = "Amplitude antennas radiation pattern";
          if (plotInfo.plotType === 2) {
            plotTitle = "Power distribution pattern";
          }

          var x = [];
          var y = [];
          var step = 2.0 / plotInfo.plotData.length;
          for (var i = 0; i < plotInfo.plotData.length; i++) {
            x.push(-1 + i * step);
            y.push(-1 + i * step);
          }

          x.push(1);
          y.push(1);

          var data = { x: x, y: y, z: plotInfo.plotData, type: 'surface' };

          var layout = {
            title: plotTitle,
            autosize: true,
            margin: {
              l: 10,
              r: 10,
              b: 50,
              t: 30
            },
            xaxis: {
              title: ""
            },
            yaxis: {
              title: ""
            }
          };

          Plotly.newPlot('plot1', [data], layout);
        }

        function changePlotArrowVisibility(shouldBeVisible) {
          if (shouldBeVisible) {
            $('.plot-left-arrow').removeClass('visibility-hidden');
            $('.plot-right-arrow').removeClass('visibility-hidden');
          } else {
            $('.plot-left-arrow').addClass('visibility-hidden');
            $('.plot-right-arrow').addClass('visibility-hidden');
          }
        }
      }
    }
  }
})(angular);