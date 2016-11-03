"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var platform_browser_1 = require('@angular/platform-browser');
var Employee_service_1 = require('./services/Employee.service');
var EmployeeComponent = (function () {
    function EmployeeComponent(_DomSanitizer, employeeService) {
        this._DomSanitizer = _DomSanitizer;
        this.employeeService = employeeService;
        this.employees = [];
    }
    EmployeeComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.employeeService.getEmployees()
            .subscribe(function (data) { return _this.employees = data; });
    };
    EmployeeComponent = __decorate([
        core_1.Component({
            selector: 'my-content',
            templateUrl: '/partial/employeeComponent'
        }), 
        __metadata('design:paramtypes', [platform_browser_1.DomSanitizer, Employee_service_1.EmployeeService])
    ], EmployeeComponent);
    return EmployeeComponent;
}());
exports.EmployeeComponent = EmployeeComponent;
//# sourceMappingURL=employee.component.js.map