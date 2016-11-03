import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AuthService } from './auth.service';
import { Employee } from '../models/employee.ts';

@Injectable()
export class EmployeeService {

    constructor(private http: Http, private authService: AuthService) { }

    getEmployees(): Observable<Employee[]> {
        return this.http.get('api/employee', { headers: this.authService.authJsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
