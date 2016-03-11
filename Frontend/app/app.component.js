System.register(['angular2/core', './tshirt.service', './tshirt-detail.component'], function(exports_1, context_1) {
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
    var core_1, tshirt_service_1, tshirt_detail_component_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (tshirt_service_1_1) {
                tshirt_service_1 = tshirt_service_1_1;
            },
            function (tshirt_detail_component_1_1) {
                tshirt_detail_component_1 = tshirt_detail_component_1_1;
            }],
        execute: function() {
            // creating a visual component 'AppComponent'
            AppComponent = (function () {
                // _ := this variable is not part of the component's public API
                function AppComponent(_tshirtService) {
                    this._tshirtService = _tshirtService;
                    this.title = 'Custom T-Shirts';
                }
                AppComponent.prototype.onSelect = function (tshirt) { this.selectedTshirt = tshirt; };
                AppComponent.prototype.getTshirts = function () {
                    this.tshirts = this._tshirtService.getTshirts();
                };
                AppComponent.prototype.ngOnInit = function () {
                    this.getTshirts();
                };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'my-app',
                        template: "\n        <h1>{{title}}</h1>\n        <h2>My T-Shirts</h2>\n        <ul class=\"heroes\">\n            <li *ngFor=\"#tshirt of tshirts\"\n            [class.selected]=\"tshirt === selectedTshirt\"\n            (click)=\"onSelect(tshirt)\">\n                <span class=\"badge\">{{tshirt.id}}</span> {{tshirt.title}}\n            </li>\n        </ul>\n        <my-tshirt-detail [tshirt]=\"selectedTshirt\"></my-tshirt-detail>\n        ",
                        styles: ["\n        .selected {\n            background-color: #CFD8DC !important;\n            color: white;\n        }\n        .heroes {\n            margin: 0 0 2em 0;\n            list-style-type: none;\n            padding: 0;\n            width: 10em;\n        }\n        .heroes li {\n            cursor: pointer;\n            position: relative;\n            left: 0;\n            background-color: #EEE;\n            margin: .5em;\n            padding: .3em 0;\n            height: 1.6em;\n            border-radius: 4px;\n        }\n        .heroes li.selected:hover {\n            background-color: #BBD8DC !important;\n            color: white;\n        }\n        .heroes li:hover {\n            color: #607D8B;\n            background-color: #DDD;\n            left: .1em;\n        }\n        .heroes .text {\n            position: relative;\n            top: -3px;\n        }\n        .heroes .badge {\n            display: inline-block;\n            font-size: small;\n            color: white;\n            padding: 0.8em 0.7em 0 0.7em;\n            background-color: #607D8B;\n            line-height: 1em;\n            position: relative;\n            left: -1px;\n            top: -4px;\n            height: 1.8em;\n            margin-right: .8em;\n            border-radius: 4px 0 0 4px;\n        }\n    "],
                        directives: [tshirt_detail_component_1.TshirtDetailComponent],
                        providers: [tshirt_service_1.TshirtService] // register services to be injected
                    }), 
                    __metadata('design:paramtypes', [tshirt_service_1.TshirtService])
                ], AppComponent);
                return AppComponent;
            }());
            exports_1("AppComponent", AppComponent);
        }
    }
});
//# sourceMappingURL=app.component.js.map