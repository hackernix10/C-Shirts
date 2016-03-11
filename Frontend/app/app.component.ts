import {Component} from 'angular2/core';

// creating a visual component 'AppComponent'
@Component({
    selector: 'my-app', // CSS selector for a host HTML element named my-app
    template:`
        <h1>{{title}}</h1>
        <h2>{{tshirt.title}} details!</h2>
        <div><label>id: </label>{{tshirt.id}}</div>
        <div>
            <label>title: </label>
            <div><input [(ngModel)]="tshirt.title" placeholder="name"></div>
        </div>
        <div>
            <label>print technique: </label>
            <div><input value="{{tshirt.printTechnique}}" placeholder="printTechnique"></div>
        </div>
        `
})
export class AppComponent {
    public title = 'Custom T-Shirts';
    public tshirt: TShirt = {
        id: 1,
        title: 'tell your story',
        printTechnique: 'screening'
    }
    
} // implement behaviour for view (properties & methods)
interface TShirt {
    id: number;
    title: string;
    printTechnique: string;
}