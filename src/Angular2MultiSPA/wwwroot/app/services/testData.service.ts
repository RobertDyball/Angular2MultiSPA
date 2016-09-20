import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class TestDataService {

    private url: string = 'api/';

    constructor(private http: Http) { }

    getTestData(): Observable<string[]> {
        return this.http.get(this.url + 'testData')
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
