import { Injectable } from '@angular/core';

@Injectable()
export class AuthService {

    constructor() { }

    login(token: string) {
        sessionStorage.setItem('access_token', token);
    }

    logout() {
        // use localstorage for persistent, browser-wide logins; session storage for per-session storage.
        //localStorage.removeItem('access_token');
        sessionStorage.removeItem('access_token');
    }

    loggedIn() {
        return !!sessionStorage.getItem('access_token');
    }
}