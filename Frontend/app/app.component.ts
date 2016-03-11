import {Component} from 'angular2/core';

// creating a visual component 'AppComponent'
@Component({
    selector: 'my-app', // CSS selector for a host HTML element named my-app
    template: '<h1>My First Angular 2 App</h1>'
})
export class AppComponent { } // implement behaviour for view (properties & methods)