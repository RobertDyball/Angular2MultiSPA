"use strict";
var http_1 = require('@angular/http');
exports.contentHeaders = new http_1.Headers();
exports.contentHeaders.append('Accept', 'application/json');
exports.contentHeaders.append('Content-Type', 'application/json');
exports.contentHeaders.append('Authorization', 'Bearer ' + localStorage.getItem('access_token'));
exports.authContentHeaders = new http_1.Headers();
exports.authContentHeaders.append('Accept', 'application/json');
exports.authContentHeaders.append('Content-Type', 'application/x-www-form-urlencoded');
//# sourceMappingURL=headers.js.map