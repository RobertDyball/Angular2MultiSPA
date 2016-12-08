import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AuthService } from './auth.service';
import { SampleData } from '../models/sampleData.ts';

@Injectable()
export class SampleDataService {

    constructor(private http: Http, private authService: AuthService) { }

    getSampleData(): Observable<SampleData> {
        return this.http.get('api/sampleData', { headers: this.authService.jsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
