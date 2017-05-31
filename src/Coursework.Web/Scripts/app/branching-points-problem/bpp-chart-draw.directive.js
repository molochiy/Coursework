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
                    if (newchartinfo) {
                      drowChart(newchartinfo);
                    } else {
                      $('#plot2').empty();
                    }
                }, true);
                function drowChart(chartinfo) {
                    if (chartinfo) {
                        //var trace1 = {
                        //    x: x,
                        //    y: y,
                        //    name: 'yaxis data',
                        //    type: 'scatter'
                        //};
                        var data = [];
                        for (i = 0; i < chartinfo.length; i++) {
                            var trace1 = {
                                x: chartinfo[i].x,
                                y: chartinfo[i].y,
                                type: 'scatter',
                                name: ''
                            };
                            data.push(trace1);
                        }
                        

                        var layout = {
                          title: 'Branching lines',
                          yaxis: { title: 'C2' },
                          xaxis: { title: 'C1' },
                        };

                        Plotly.newPlot('plot2', data, layout);
                    }
                }
            }
        }
    }
})(angular);