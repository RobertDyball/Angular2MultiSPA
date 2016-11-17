import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AuthService } from './auth.service';
import { Order } from '../models/order.ts';

@Injectable()
export class OrderService {

    constructor(private http: Http, private authService: AuthService) { }

    getOrder(orderId: number): Observable<Order[]> {
        return this.http.get('api/order/' + orderId.toString(), { headers: this.authService.jsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    getOrders(): Observable<Order[]> {
        return this.http.get('api/order', { headers: this.authService.jsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
