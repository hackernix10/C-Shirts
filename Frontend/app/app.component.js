System.register(['angular2/core'], function(exports_1, context_1) {
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
    var core_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            // creating a visual component 'AppComponent'
            AppComponent = (function () {
                function AppComponent() {
                    this.title = 'Custom T-Shirts';
                    this.tshirts = [
                        { "id": 1, "title": "tell your story", "printTechnique": "Screening" },
                        { "id": 2, "title": "ZRK", "printTechnique": "Sublimation" },
                        { "id": 3, "title": "IAZ", "printTechnique": "DOG Print" },
                        { "id": 4, "title": "Zara black", "printTechnique": "Screening" }
                    ];
                }
                AppComponent.prototype.onSelect = function (tshirt) { this.selectedTShirt = tshirt; };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'my-app',
                        template: "\n        <h1>{{title}}</h1>\n        <h2>My T-Shirts</h2>\n        <ul class=\"heroes\">\n            <li *ngFor=\"#tshirt of tshirts\"\n            [class.selected]=\"tshirt === selectedTShirt\"\n            (click)=\"onSelect(tshirt)\">\n                <span class=\"badge\">{{tshirt.id}}</span> {{tshirt.title}}\n            </li>\n        </ul>\n        <div *ngIf=\"selectedTShirt\">\n            <h2>{{selectedTShirt.title}} details!</h2>\n            <div><label>id: </label>{{selectedTShirt.id}}</div>\n            <div>\n                <label>title: </label>\n                <div><input [(ngModel)]=\"selectedTShirt.title\" placeholder=\"name\"></div>\n            </div>\n            <div>\n                <label>print technique: </label>\n                <div><input value=\"{{selectedTShirt.printTechnique}}\" placeholder=\"printTechnique\"></div>\n            </div>\n        </div>\n        ",
                        styles: ["\n        .selected {\n            background-color: #CFD8DC !important;\n            color: white;\n        }\n        .heroes {\n            margin: 0 0 2em 0;\n            list-style-type: none;\n            padding: 0;\n            width: 10em;\n        }\n        .heroes li {\n            cursor: pointer;\n            position: relative;\n            left: 0;\n            background-color: #EEE;\n            margin: .5em;\n            padding: .3em 0;\n            height: 1.6em;\n            border-radius: 4px;\n        }\n        .heroes li.selected:hover {\n            background-color: #BBD8DC !important;\n            color: white;\n        }\n        .heroes li:hover {\n            color: #607D8B;\n            background-color: #DDD;\n            left: .1em;\n        }\n        .heroes .text {\n            position: relative;\n            top: -3px;\n        }\n        .heroes .badge {\n            display: inline-block;\n            font-size: small;\n            color: white;\n            padding: 0.8em 0.7em 0 0.7em;\n            background-color: #607D8B;\n            line-height: 1em;\n            position: relative;\n            left: -1px;\n            top: -4px;\n            height: 1.8em;\n            margin-right: .8em;\n            border-radius: 4px 0 0 4px;\n        }\n        "]
                    }), 
                    __metadata('design:paramtypes', [])
                ], AppComponent);
                return AppComponent;
            }());
            exports_1("AppComponent", AppComponent);
        }
    }
});
//# sourceMappingURL=app.component.js.map