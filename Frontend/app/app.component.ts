import {Component} from 'angular2/core';
import {OnInit} from 'angular2/core';

import {TshirtService} from './tshirt.service';
import {Tshirt} from './tshirt';
import {TshirtDetailComponent} from './tshirt-detail.component';

// creating a visual component 'AppComponent'
@Component({
    selector: 'my-app', // CSS selector for a host HTML element named my-app
    template:`
        <h1>{{title}}</h1>
        <h2>My T-Shirts</h2>
        <ul class="heroes">
            <li *ngFor="#tshirt of tshirts"
            [class.selected]="tshirt === selectedTshirt"
            (click)="onSelect(tshirt)">
                <span class="badge">{{tshirt.id}}</span> {{tshirt.title}}
            </li>
        </ul>
        <my-tshirt-detail [tshirt]="selectedTshirt"></my-tshirt-detail>
        `,
    styles:[`
        .selected {
            background-color: #CFD8DC !important;
            color: white;
        }
        .heroes {
            margin: 0 0 2em 0;
            list-style-type: none;
            padding: 0;
            width: 10em;
        }
        .heroes li {
            cursor: pointer;
            position: relative;
            left: 0;
            background-color: #EEE;
            margin: .5em;
            padding: .3em 0;
            height: 1.6em;
            border-radius: 4px;
        }
        .heroes li.selected:hover {
            background-color: #BBD8DC !important;
            color: white;
        }
        .heroes li:hover {
            color: #607D8B;
            background-color: #DDD;
            left: .1em;
        }
        .heroes .text {
            position: relative;
            top: -3px;
        }
        .heroes .badge {
            display: inline-block;
            font-size: small;
            color: white;
            padding: 0.8em 0.7em 0 0.7em;
            background-color: #607D8B;
            line-height: 1em;
            position: relative;
            left: -1px;
            top: -4px;
            height: 1.8em;
            margin-right: .8em;
            border-radius: 4px 0 0 4px;
        }
    `],
    directives: [TshirtDetailComponent],
    providers: [TshirtService] // register services to be injected
})
export class AppComponent implements OnInit {
    title = 'Custom T-Shirts';
    tshirts: Tshirt[];  
    selectedTshirt: Tshirt;
       
    // _ := this variable is not part of the component's public API
    constructor(private _tshirtService: TshirtService) {}

    onSelect(tshirt: Tshirt) { this.selectedTshirt = tshirt; }
    
    getTshirts() {
        this._tshirtService.getTshirts().then(tshirts => this.tshirts = tshirts);
    }
    
    ngOnInit() {
        this.getTshirts();
    }
}