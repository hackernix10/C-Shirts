System.register(['./mock-tshirts', 'angular2/core'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var mock_tshirts_1, core_1;
    var TshirtService;
    return {
        setters:[
            function (mock_tshirts_1_1) {
                mock_tshirts_1 = mock_tshirts_1_1;
            },
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            // @Injectable decorator should be applied from the start
            // for consistency and future-proofing,
            // even if yet no dependencies exist 
            TshirtService = (function () {
                function TshirtService() {
                }
                TshirtService.prototype.getTshirts = function () {
                    return Promise.resolve(mock_tshirts_1.TSHIRTS);
                };
                TshirtService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [])
                ], TshirtService);
                return TshirtService;
            }());
            exports_1("TshirtService", TshirtService);
        }
    }
});
//# sourceMappingURL=tshirt.service.js.map