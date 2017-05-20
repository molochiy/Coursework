﻿(function (angular) {
  angular.module("problemsModule", []);
})(angular);

angular.module('problemsModule').directive('firstProblemForm', function () {
    return {
        template: '<div style="padding-left:5%; padding-right:5%;">'+
        '<form>' +
        '<div class="form-group" style="text-align:left;">' +
        '<label for="modulF">|F|</label>' +
        ' <input type="text" class="form-control" id="modulF" placeholder="|F|">' +
        '  </div>' +

        ' <div class="form-group" style="text-align:left;">' +
        ' <label for="argF">arg(F)</label>' +
        ' <input type="text" class="form-control" id="argF" placeholder="arg(F)">' +
        '        </div>' +

        ' <div class="form-group row" style="text-align:left;">' +
        ' <div class="col-md-6">' +
        ' <label for="M1">M<sub>1</sub></label>' +
        ' <input type="text" class="form-control" id="M1" placeholder="M1">' +
        '        </div>' +
        ' <div class="col-md-6">' +
        '   <label for="M2">M<sub>2</sub></label>' +
        '  <input type="text" class="form-control" id="M2" placeholder="M2">' +
        '     </div>' +
        ' </div>' +

        '  <div class="form-group row" style="text-align:left;">' +
        '      <div class="col-md-6">' +
        '         <label for="C1">C<sub>1</sub></label>' +
        ' <input type="text" class="form-control" id="C1" placeholder="C1">' +
        ' </div>' +
        ' <div class="col-md-6">' +
        '    <label for="C2">C<sub>2</sub></label>' +
        '    <input type="text" class="form-control" id="C2" placeholder="C2">' +
        ' </div>' +
        '</div>' +
        ' <div class="form-group" style="text-align:left;">' +
        '   <label for="eps">e</label>' +
        '   <input type="text" class="form-control" id="eps" placeholder="e">' +
        ' </div>' +

        '      <button type="submit" class="btn btn-primary">Submit</button>' +
                       ' </form>  '+
                           ' </div>'
    };
});

angular.module('problemsModule').directive('secondProblemForm', function () {
    return {
        template: '<div style="padding-left:5%; padding-right:5%;">' +
        '<form>' +
        '<div class="form-group" style="text-align:left;">' +
        '<label for="modulF">|F|</label>' +
        ' <input type="text" class="form-control" id="modulF" placeholder="|F|">' +
        '  </div>' +

        ' <div class="form-group" style="text-align:left;">' +
        ' <label for="argF">arg(F)</label>' +
        ' <input type="text" class="form-control" id="argF" placeholder="arg(F)">' +
        '        </div>' +

        ' <div class="form-group row" style="text-align:left;">' +
        ' <div class="col-md-6">' +
        ' <label for="M1">M<sub>1</sub></label>' +
        ' <input type="text" class="form-control" id="M1" placeholder="M1">' +
        '        </div>' +
        ' <div class="col-md-6">' +
        '   <label for="M2">M<sub>2</sub></label>' +
        '  <input type="text" class="form-control" id="M2" placeholder="M2">' +
        '     </div>' +
        ' </div>' +
        ' <div class="form-group" style="text-align:left;">' +
        '   <label for="eps">e</label>' +
        '   <input type="text" class="form-control" id="eps" placeholder="e">' +
        ' </div>' +

        '      <button type="submit" class="btn btn-primary">Submit</button>' +
        ' </form>  ' +
        ' </div>'
    };
});