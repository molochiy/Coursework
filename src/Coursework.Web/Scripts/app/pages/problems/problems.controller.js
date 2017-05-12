(function (angular) {

  angular
      .module("problemsModule")
      .controller("ProblemsController", ProblemsController);

  ProblemsController.$inject = [];

  function ProblemsController() {
    var vm = this;

    vm.user = {
      photoUrl: "~/Content/images/abstract-user-photo.png",
      userLogin: "molochiy@gmail.com"
    }
  }
})(angular);