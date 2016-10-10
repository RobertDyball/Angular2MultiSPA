"use strict";
var http_1 = require('@angular/http');
exports.securedContentHeaders = new http_1.Headers();
exports.securedContentHeaders.append('Accept', 'application/json');
exports.securedContentHeaders.append('Content-Type', 'application/json');
exports.securedContentHeaders.append('Authorization', 'Bearer ' + sessionStorage.getItem('access_token'));
exports.contentHeaders = new http_1.Headers();
exports.contentHeaders.append('Accept', 'application/json');
exports.contentHeaders.append('Content-Type', 'application/x-www-form-urlencoded');
//# sourceMappingURL=headers.js.map