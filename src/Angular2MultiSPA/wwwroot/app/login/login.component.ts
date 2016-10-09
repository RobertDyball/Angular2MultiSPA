import { Component } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';

import { Http, Headers } from '@angular/http';
import { contentHeaders, authContentHeaders } from '../services/headers';

@Component({
    selector: 'login',
    templateUrl: '/partial/loginComponent'
})

export class LoginComponent {
    constructor(public router: Router, private titleService: Title, public http: Http) {
    }

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    public login(event: Event, username: string, password: string) {
        event.preventDefault();
        
        let body = 'username=' + username + '&password=' + password + '&grant_type=password';

        // TODO: check scopes
        // https://github.com/openiddict/openiddict-core/issues/181
        // http://kerryritter.com/authorizing-your-net-core-mvc6-api-requests-with-openiddict-and-identity/

        // see also: https://hgminerva.wordpress.com/2016/03/23/angular-2-and-asp-net-web-api-authentication/

        // to check your returned tokens: https://jwt.io/

        this.http.post('/connect/token', body, { headers: authContentHeaders })
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

    public signup(event: Event) {
        event.preventDefault();
        this.router.navigate(['/signup']);
    }
}
