import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { securedContentHeaders } from '../services/headers';

import { Category } from '../category.ts';

@Injectable()
export class TestDataService {

    constructor(private http: Http) { }

    getTestData(): Observable<Category[]> {
        return this.http.get('api/testData', { headers: securedContentHeaders })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
