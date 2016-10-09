import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { AuthHttp } from 'angular2-jwt';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Observable } from 'rxjs/Rx';
import { Category } from '../category.ts';
import { contentHeaders } from '../services/headers';


@Injectable()
export class TestDataService {

    private url: string = 'api/';

    constructor(private http: Http) { }

    getTestData(): Observable<Category[]> {
        return this.http.get(this.url + 'testData', { headers: contentHeaders })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
