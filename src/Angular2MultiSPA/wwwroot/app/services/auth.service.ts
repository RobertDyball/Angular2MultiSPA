import { Injectable } from '@angular/core';

@Injectable()
export class AuthService {

    constructor() { }

    login(token: string) {
        //localStorage.removeItem('access_token');
        sessionStorage.setItem('access_token', token);
    }

    logout() {
        sessionStorage.removeItem('access_token');
    }

    loggedIn() {
        return !!sessionStorage.getItem('access_token');
    }
}