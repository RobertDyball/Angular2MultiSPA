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
var router_1 = require('@angular/router');
//import { Router, ROUTER_DIRECTIVES } from '@angular/router';
//import { CORE_DIRECTIVES, FORM_DIRECTIVES } from '@angular/common';
var http_1 = require('@angular/http');
var headers_1 = require('../services/headers');
//const styles = require('./login.css');
//const template = require('./login.html');
var LoginComponent = (function () {
    function LoginComponent(router, titleService, http) {
        this.router = router;
        this.titleService = titleService;
        this.http = http;
    }
    LoginComponent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    LoginComponent.prototype.login = function (event, username, password) {
        var _this = this;
        event.preventDefault();
        var body = 'username=' + username + '&password=' + password + '&grant_type=password';
        this.http.post('/connect/token', body, { headers: headers_1.authContentHeaders })
            .subscribe(function (response) {
            localStorage.setItem('access_token', response.json().access_token);
            _this.router.navigate(['/content']);
        }, function (error) {
            alert(error.text());
            console.log(error.text());
        });
    };
    LoginComponent.prototype.signup = function (event) {
        event.preventDefault();
        this.router.navigate(['/signup']);
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'login',
            //directives: [ ROUTER_DIRECTIVES, CORE_DIRECTIVES, FORM_DIRECTIVES ],
            //    styles: [styles],
            templateUrl: '/partial/loginComponent'
        }), 
        __metadata('design:paramtypes', [router_1.Router, platform_browser_1.Title, http_1.Http])
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map