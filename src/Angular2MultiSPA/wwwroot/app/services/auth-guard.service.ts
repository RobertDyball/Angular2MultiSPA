import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CanActivate } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private auth: AuthService, private router: Router) { }

    // see : http://jasonwatmore.com/post/2016/08/16/angular-2-jwt-authentication-example-tutorial

    canActivate() {
        if (!this.auth.loggedIn()) {
            this.router.navigate(['']);
            return false;
        }
        return true;
    }

}