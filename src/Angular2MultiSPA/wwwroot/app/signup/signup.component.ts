import { Component } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';
// import { CORE_DIRECTIVES, FORM_DIRECTIVES } from '@angular/common';
import { Http } from '@angular/http';
import { contentHeaders } from '../services/headers';

// const styles = require('./signup.css');
//const template = require('./signup.html');

@Component({
    selector: 'signup',
    // directives: [ CORE_DIRECTIVES, FORM_DIRECTIVES ],
    // styles: [styles],
    templateUrl: '/partial/signupComponent'
})
export class SignupComponent {
    constructor(public router: Router, private titleService: Title, public http: Http) {
    }

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    public signup(event: Event, username: string, password: string) {
        event.preventDefault();
        let body = JSON.stringify({ username, password });
        this.http.post('http://localhost:7010/connect', body, { headers: contentHeaders })
            .subscribe(
            response => {
                localStorage.setItem('access_token', response.json().access_token);
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
