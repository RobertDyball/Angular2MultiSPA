import { Headers } from '@angular/http';

export const contentHeaders = new Headers();
contentHeaders.append('Accept', 'application/json');
contentHeaders.append('Content-Type', 'application/json');
contentHeaders.append('Authorization', 'Bearer ' + localStorage.getItem('access_token'));

export const authContentHeaders = new Headers();
authContentHeaders.append('Accept', 'application/json');
authContentHeaders.append('Content-Type', 'application/x-www-form-urlencoded');
