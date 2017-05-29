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
        problems: '=',
        selectedProblemId: '='
      },
      link: function (scope, element, attrs) {
        initScrollBar('#HistoryTableContent');

        var historyTable = $(element[0]).DataTable({
          dom: "rt",
          autoWidth: false,
          ordering: true,
          order: [[ 7, "desc" ]],
          paging: false,
          scrollCollapse: true,
          data: problems,
          rowId: 'id',
          select: {
            style: 'single'
          },
          columns: [{
            "title": "|F|",
            "data": "fModule",
            "responsivePriority": 1
          }, {
            "title": "arg(F)",
            "data": "fArgument",
            "responsivePriority": 2
          }, {
            "title": "M&#8321;",
            "data": "m1",
            "responsivePriority": 3
          }, {
            "title": "M&#8322;",
            "data": "m2",
            "responsivePriority": 4
          }, {
            "title": "c&#8321;",
            "data": "c1",
            "responsivePriority": 5
          }, {
            "title": "c&#8322;",
            "data": "c2",
            "responsivePriority": 6
          }, {
            "title": "&epsilon;",
            "data": "eps",
            "responsivePriority": 7
          }, {
            "title": "Creation date",
            "data": "creationDate",
            "responsivePriority": 8,
            "render": function (data) {
              if (data) {
                var date = new Date(data);
                return moment(date).format('DD.MM.YYYY HH:mm:ss');
              }

              return "";
            }
          }, {
            "title": "State",
            "data": "stateId",
            "responsivePriority": 9,
            "render": function (data) {
              return getStateById(data);
            }
          }, {
            "data": "id",
            "visible": false
          }],
          initComplete: function (settings, json) {
            onProblemsChanged();
            onRowSelectDeselect();
          }
        });

        function getStateById(id) {
          switch (id) {
            case 1:
              return "Queued";
            case 2:
              return "In Progress";
            case 3:
              return "Finished";
            case 4:
              return "Canceled";
            case 5:
              return "Aborted";
            default:
              return "";
          }
        }

        function onRowSelectDeselect() {
          var historyTable = $('#HistoryTable').DataTable();
          historyTable
            .on('select', function (e, dt, type, indexes) {
              if (type === 'row') {
                var selected = historyTable.row({
                  "selected": true
                });

                var selectedRowData = selected.data();

                if (selectedRowData.stateId === 3) {
                  $('#ShowButton').removeClass('disabled');
                  scope.$apply(() => {
                    scope.selectedProblemId = selectedRowData.id;
                  });
                }
              }
            })
            .on('deselect', function (e, dt, type, indexes) {
              if (type === 'row') {
                scope.$apply(() => {
                  disableButton();
                });
              }
            });
        }

        function disableButton() {
          $('#ShowButton').addClass('disabled');
          scope.selectedProblemId = -1;
        }

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
            disableButton();
            historyTable.clear();
            historyTable.rows.add(newProblems);
            historyTable.draw();
          }, true);
        }
      }
    };
  }
})(angular);