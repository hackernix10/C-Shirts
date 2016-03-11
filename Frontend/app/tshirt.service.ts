import {TSHIRTS} from './mock-tshirts';
import {Injectable} from 'angular2/core';

// @Injectable decorator should be applied from the start
// for consistency and future-proofing,
// even if yet no dependencies exist 
@Injectable()
export class TshirtService {
    getTshirts() {
        return TSHIRTS;
    }        
}