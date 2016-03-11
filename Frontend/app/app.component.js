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
                    this.tshirt = {
                        id: 1,
                        title: 'tell your story',
                        printTechnique: 'screening'
                    };
                }
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'my-app',
                        template: "\n        <h1>{{title}}</h1>\n        <h2>{{tshirt.title}} details!</h2>\n        <div><label>id: </label>{{tshirt.id}}</div>\n        <div><label>title: </label>{{tshirt.title}}</div>\n        <div><label>print technique: </label>{{tshirt.printTechnique}}</div>\n        "
                    }), 
                    __metadata('design:paramtypes', [])
                ], AppComponent);
                return AppComponent;
            }());
            exports_1("AppComponent", AppComponent); // implement behaviour for view (properties & methods)
        }
    }
});
//# sourceMappingURL=app.component.js.map