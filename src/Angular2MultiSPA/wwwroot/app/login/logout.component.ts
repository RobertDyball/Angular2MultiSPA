import { Component } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'logout',
    template: '<p>logging off</p>'
})

export class LogoutComponent {
    constructor(public router: Router, private authService: AuthService) {
        this.authService.logout();
        this.router.navigate(['']);
    }
}
