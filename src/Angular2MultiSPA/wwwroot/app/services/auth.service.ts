import { Injectable } from '@angular/core';
import { tokenNotExpired } from 'angular2-jwt';
import { Router } from '@angular/router';

declare var Auth0Lock: any;

@Injectable()
export class AuthService {

    lock = new Auth0Lock('angular2MultiSPA', 'localhost:7010/connect');

    constructor(private router: Router) {
        this.lock.on('authenticated', (authResult: any) => {
            localStorage.setItem('access_token', authResult.idToken);

            this.lock.getProfile(authResult.idToken, (error: any, profile: any) => {
                if (error) {
                    console.log(error);
                }

                localStorage.setItem('profile', JSON.stringify(profile));
            });

            this.lock.hide();
        });
    }

    login() {
        this.lock.show();
    }

    logout() {
        // To log out, just remove the token and profile from local storage
        localStorage.removeItem('profile');
        localStorage.removeItem('access_token');

        // Send the user back to the dashboard after logout
        this.router.navigateByUrl('/home');
    }

    loggedIn() {
        return tokenNotExpired();
    }
}