import { Injectable } from '@angular/core';
import { Headers } from '@angular/http';

@Injectable()
export class AuthService {

    constructor() { }

    authJsonHeaders() {
        let header = new Headers();
        header.append('Content-Type', 'application/json');
        header.append('Accept', 'application/json');
        header.append('Authorization', 'Bearer ' + sessionStorage.getItem('access_token'));
        return header;
    }

    authFormHeaders() {
        let header = new Headers();
        header.append('Content-Type', 'application/x-www-form-urlencoded');
        header.append('Accept', 'application/json');
        header.append('Authorization', 'Bearer ' + sessionStorage.getItem('access_token'));
        return header;
    }

    contentHeaders() {
        let header = new Headers();
        header.append('Content-Type', 'application/x-www-form-urlencoded');
        header.append('Accept', 'application/json');
        return header;
    }

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