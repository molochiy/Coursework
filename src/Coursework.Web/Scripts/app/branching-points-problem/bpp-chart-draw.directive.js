(function (angular) {

    angular.module('appModule')
        .directive('secondProblemGraphic', secondProblemGraphic);

    function secondProblemGraphic() {
        return {
            restrict: 'E',
            terminal: true,
            replace: true,
            scope: {
                chartInfo: '='
            },
            template: '<div id="plot2" class="plot"></div>',
            link: function (scope, element, attrs) {

                scope.$watch('chartInfo', (newchartinfo, oldchartinfo) => {
                    if (newchartinfo && newchartinfo.x && newchartinfo.y ) {
                        drowChart(newchartinfo.x, newchartinfo.y);
                    }
                }, true);
                function drowChart(x,y) {
                    if (x && y) {
                        var trace1 = {
                            x: x,
                            y: y,
                            name: 'yaxis data',
                            type: 'scatter'
                        };

                        var data = [trace1];

                        var layout = {
                            title: 'Double Y Axis Example',
                            yaxis: { title: 'yaxis title' },
                        };

                        Plotly.newPlot('plot2', data, layout);
                    }
                }
            }
        }
    }
})(angular);