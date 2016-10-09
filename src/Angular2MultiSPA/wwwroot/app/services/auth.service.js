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
var angular2_jwt_1 = require('angular2-jwt');
var router_1 = require('@angular/router');
var AuthService = (function () {
    function AuthService(router) {
        var _this = this;
        this.router = router;
        this.lock = new Auth0Lock('angular2MultiSPA', 'localhost:7010/connect');
        this.lock.on('authenticated', function (authResult) {
            localStorage.setItem('access_token', authResult.idToken);
            _this.lock.getProfile(authResult.idToken, function (error, profile) {
                if (error) {
                    console.log(error);
                }
                localStorage.setItem('profile', JSON.stringify(profile));
            });
            _this.lock.hide();
        });
    }
    AuthService.prototype.login = function () {
        this.lock.show();
    };
    AuthService.prototype.logout = function () {
        // To log out, just remove the token and profile from local storage
        localStorage.removeItem('profile');
        localStorage.removeItem('access_token');
        // Send the user back to the dashboard after logout
        this.router.navigateByUrl('/home');
    };
    AuthService.prototype.loggedIn = function () {
        return angular2_jwt_1.tokenNotExpired();
    };
    AuthService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [router_1.Router])
    ], AuthService);
    return AuthService;
}());
exports.AuthService = AuthService;
//# sourceMappingURL=auth.service.js.map