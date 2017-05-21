(function (angular) {

  angular
      .module("appModule")
      .controller("problem1Controller", problem1Controller);

  problem1Controller.$inject = [];

  function problem1Controller() {
    var vm = this;

    vm.problem1 = {

    }
  }
})(angular);