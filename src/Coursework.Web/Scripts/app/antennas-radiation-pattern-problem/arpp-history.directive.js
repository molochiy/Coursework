(function (angular) {

  angular
      .module("appModule")
      .directive("arppHistory", arppHistory);

  function arppHistory() {
    return {
      restrict: 'E',
      terminal: true,
      replace: true,
      template: '<table id="HistoryTable"></table>',
      scope: {
        problems: '='
      },
      link: function (scope, element, attrs) {
        initScrollBar('#HistoryTableContent');

        var historyTable = $(element[0]).DataTable({
          dom: "rt",
          autoWidth: false,
          ordering: true,
          paging: false,
          scrollCollapse: true,
          data: problems,
          //rowId: rowId,
          select: {
            style: 'single'
          },
          columns: [{
            "title": "|F|",
            "data": "moduleF",
            "responsivePriority": 1
          }, {
            "title": "arg(F)",
            "data": "argF",
            "responsivePriority": 2
          }, {
            "title": "M1",
            "data": "M1",
            "responsivePriority": 2
          }, {
            "title": "M2",
            "data": "M2",
            "responsivePriority": 2
          }, {
            "title": "C1",
            "data": "C1",
            "responsivePriority": 2
          }, {
            "title": "C2",
            "data": "C2",
            "responsivePriority": 2
          }, {
            "title": "e",
            "data": "e",
            "responsivePriority": 2
          }, {
            "title": "Added date",
            "data": "addedDate",
            "responsivePriority": 2,
            "render": function (data) {
              if (data) {
                var date = new Date(data);
                return moment(date).format('MMMM Do YYYY, HH:mm:ss');
              }

              return "";
            }
          }, {
            "title": "Status",
            "data": "status",
            "responsivePriority": 2
          }, {
            "data": "rowId",
            "visible": false
          }],
          initComplete: function (settings, json) {
            onProblemsChanged();
          }
        });

        function initScrollBar(containerId) {
          $(containerId).niceScroll({
            cursorcolor: '#b08a92',
            autohidemode: 'scroll',
            cursorborder: 'none',
            cursorwidth: '6px',
            sensitiverail: true
          });
        };

        function onProblemsChanged() {
          scope.$watch('problems', (newProblems, oldProblems) => {
            historyTable.clear();
            historyTable.rows.add(newProblems);
            historyTable.draw();
          });
        }
      }
    };
  }
})(angular);