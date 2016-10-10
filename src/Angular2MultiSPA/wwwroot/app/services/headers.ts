import { Headers } from '@angular/http';

export const securedContentHeaders = new Headers();
securedContentHeaders.append('Accept', 'application/json');
securedContentHeaders.append('Content-Type', 'application/json');
securedContentHeaders.append('Authorization', 'Bearer ' + sessionStorage.getItem('access_token'));

export const contentHeaders = new Headers();
contentHeaders.append('Accept', 'application/json');
contentHeaders.append('Content-Type', 'application/x-www-form-urlencoded');
