import { Component } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';

import { Http } from '@angular/http';
import { contentHeaders } from '../services/headers';
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

    public signup(event: Event, username: string, firstname: string, password: string) {
        event.preventDefault();
        let body = 'username=' + username + '&password=' + password + '&firstname=' + firstname + '&grant_type=password';
        this.http.post('http://localhost:7010/connect/signup', body, { headers: contentHeaders })
            .subscribe(
            response => {
                this.authService.login(response.json().access_token)
                this.router.navigate(['/content']);
            },
            error => {
                alert(error.text());
                console.log(error.text());
            }
            );
    }

    public login(event: Event) {
        event.preventDefault();
        this.router.navigate(['/login']);
    }
}
