import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AuthService } from './auth.service';
import { Category } from '../models/category.ts';

@Injectable()
export class CategoryService {

    constructor(private http: Http, private authService: AuthService) { }

    getCategories(): Observable<Category[]> {
        return this.http.get('api/category', { headers: this.authService.jsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
