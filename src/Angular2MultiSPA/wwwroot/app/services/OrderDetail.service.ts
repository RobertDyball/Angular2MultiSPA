import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AuthService } from './auth.service';
import { OrderDetail } from '../models/orderdetail.ts';

@Injectable()
export class OrderDetailService {

    constructor(private http: Http, private authService: AuthService) { }

    getOrderDetail(orderId: number): Observable<OrderDetail[]> {
        return this.http.get('api/orderdetail/' + orderId.toString(), { headers: this.authService.jsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    getOrderDetails(): Observable<OrderDetail[]> {
        return this.http.get('api/orderdetail', { headers: this.authService.jsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
