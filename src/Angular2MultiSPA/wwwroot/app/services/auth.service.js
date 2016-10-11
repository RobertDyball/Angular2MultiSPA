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
var http_1 = require('@angular/http');
var AuthService = (function () {
    function AuthService() {
    }
    AuthService.prototype.authJsonHeaders = function () {
        var header = new http_1.Headers();
        header.append('Content-Type', 'application/json');
        header.append('Accept', 'application/json');
        header.append('Authorization', 'Bearer ' + sessionStorage.getItem('access_token'));
        return header;
    };
    AuthService.prototype.authFormHeaders = function () {
        var header = new http_1.Headers();
        header.append('Content-Type', 'application/x-www-form-urlencoded');
        header.append('Accept', 'application/json');
        header.append('Authorization', 'Bearer ' + sessionStorage.getItem('access_token'));
        return header;
    };
    AuthService.prototype.contentHeaders = function () {
        var header = new http_1.Headers();
        header.append('Content-Type', 'application/x-www-form-urlencoded');
        header.append('Accept', 'application/json');
        return header;
    };
    AuthService.prototype.login = function (token) {
        sessionStorage.setItem('access_token', token);
    };
    AuthService.prototype.logout = function () {
        // use localstorage for persistent, browser-wide logins; session storage for per-session storage.
        //localStorage.removeItem('access_token');
        sessionStorage.removeItem('access_token');
    };
    AuthService.prototype.loggedIn = function () {
        return !!sessionStorage.getItem('access_token');
    };
    AuthService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [])
    ], AuthService);
    return AuthService;
}());
exports.AuthService = AuthService;
//# sourceMappingURL=auth.service.js.map