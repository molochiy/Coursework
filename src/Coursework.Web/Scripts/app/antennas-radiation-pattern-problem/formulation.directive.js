(function (angular) {

    angular.module('appModule')
        .directive('formulationProblem', formulationProblem);

    function formulationProblem() {
        return {
            restrict: 'E',
            terminal: true,
            replace: true,
            scope: {
                formulationproblemtype: '='
            },
            template: '<div class="problem-description-content"></div>',
            link: function (scope, element, attrs) {
                $('.problem-description').niceScroll({
                    cursorcolor: '#b08a92',
                    autohidemode: 'scroll',
                    cursorborder: 'none',
                    cursorwidth: '6px',
                    sensitiverail: true
                });
                scope.$watch('formulationproblemtype', (newformulationproblemtype, oldformulationproblemtype) => {
                    if (newformulationproblemtype) {
                        $(element[0]).empty();
                        $(element[0]).append(getProblemDescByType(newformulationproblemtype));
                        MathJax.Hub.Queue(["Typeset", MathJax.Hub]);
                    }
                }, true);
                
                function getProblemDescByType(typeId) {
                    switch (typeId) {
                        case 1: return `<div> $$\\sigma(I)=\\iint\\limits_{\\Omega} \\left[ P(\\xi_1,\\xi_2)-|f(\\xi_1,\\xi_2)|^2 \\right] ^2 \\mathrm{d}\\xi_1 \\mathrm{d}\\xi_2 $$</div>
                                        <div> $$ + \\iint\\limits_{R \\setminus \\Omega} \\left[ |f(\\xi_1,\\xi_2)|^2 \\right] ^2 \\mathrm{d}\\xi_1 \\mathrm{d}\\xi_2 $$ </div >
                                        <div> $$\\sigma(I)\\rightarrow \\min_{I\\in H_1},\\quad I_{nm}\\in H_1$$ </div>`;
                        case 2: return `<div> $$\\sigma(I)=\\iint\\limits_{\\Omega} \\left[ P(\\xi_1,\\xi_2)-|f(\\xi_1,\\xi_2)|^2 \\right] ^2 \\mathrm{d}\\xi_1 \\mathrm{d}\\xi_2 $$</div>
                                        <div> $$+ \\alpha\\sum_{n=-M_1}^{M_1} \\sum_{m=-M_2(n)}^{M_2(n)}\\left|I_{nm} \\right|^2$$</div>
                                        <div> $$P(\\xi_1,\\xi_2)=|f(\\xi_1,\\xi_2)|^2$$</div>
                                        <div> $$\\sigma(I)\\rightarrow \\min_{I\\in H_1},\\quad I_{nm}\\in H_1$$ </div>`
                    }
                }
            }
        }
    }
})(angular);