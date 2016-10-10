import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {

    constructor(private router: Router) { }

    login(token: string) {
        localStorage.setItem('access_token', token);
    }

    logout() {
        localStorage.removeItem('profile');
        localStorage.removeItem('access_token');
        this.router.navigateByUrl('/home');
    }

    loggedIn() {
        return !!localStorage.getItem('access_token');
    }
}