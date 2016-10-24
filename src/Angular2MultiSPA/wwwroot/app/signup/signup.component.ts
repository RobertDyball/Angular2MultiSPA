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
        this.http.post('/Account/Register', JSON.stringify(body), { headers: this.authService.jsonHeaders() })
            .subscribe(response => {
                if (response.status == 200) {
                    this.router.navigate(['/login']);
                } else {
                    alert(response.json().error);
                    console.log(response.json().error);
                }
            },
            error => {
                alert(error.text());
                console.log(error.text());
            });
    }

    public login(event: Event) {
        event.preventDefault();
        this.router.navigate(['/login']);
    }
}
