import { Component } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';

import { Http } from '@angular/http';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'signup',
    templateUrl: '/partial/signupComponent'
})

export class SignupComponent {

    constructor(public router: Router, private titleService: Title, public http: Http, private authService: AuthService) { }

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    public signup(event: Event, username: string, password: string) {
        event.preventDefault();

        let body = { 'email': username, 'password': password };
        this.http.post('http://localhost:7010/Account/Register', JSON.stringify(body), { headers: this.authService.jsonHeaders() })
            .subscribe(
            response => {
                if (response.status != 200) {
                    alert(response.statusText);
                    console.log(response.statusText);
                }
                else
                if (response.json().error != null && response.json().error.length > 0) {
                    alert(response.json().error);
                    console.log(response.json().error);
                }
                else {
                    this.authService.login(response.json())
                }
            });
    }

    public login(event: Event) {
        event.preventDefault();
        this.router.navigate(['/login']);
    }
}
