import { Component, OnInit } from '@angular/core';
import { DomSanitizer} from '@angular/platform-browser';

import { EmployeeService } from './services/Employee.service';
import { Employee } from './models/Employee.ts';

@Component({
    selector: 'my-content',
    templateUrl: '/partial/employeeComponent'
})

export class EmployeeComponent implements OnInit {
    employees: Employee[] = [];

    constructor(
        private _DomSanitizer: DomSanitizer,
        private employeeService: EmployeeService
    ) { }

    ngOnInit() {
        this.employeeService.getEmployees()
            .subscribe((data: Employee[]) => this.employees = data);
    }
}
