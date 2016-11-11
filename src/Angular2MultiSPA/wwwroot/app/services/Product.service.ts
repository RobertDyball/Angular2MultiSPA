import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AuthService } from './auth.service';
import { Product } from '../models/product.ts';

@Injectable()
export class ProductService {

    constructor(private http: Http, private authService: AuthService) { }

    getProducts(id: number): Observable<Product[]> {
        return this.http.get('api/product?id=' + id.toString(), { headers: this.authService.jsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
