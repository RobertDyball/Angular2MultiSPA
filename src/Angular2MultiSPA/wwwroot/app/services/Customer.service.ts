import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AuthService } from './auth.service';
import { Customer } from '../models/customer.ts';

@Injectable()
export class CustomerService {

    constructor(private http: Http, private authService: AuthService) { }

    getCustomer(customerId: string): Observable<Customer[]> {
        return this.http.get('api/customer/' + customerId, { headers: this.authService.authJsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    getCustomers(): Observable<Customer[]> {
        return this.http.get('api/customer', { headers: this.authService.authJsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
