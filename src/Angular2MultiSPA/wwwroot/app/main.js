"use strict";
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
// import { enableProdMode } from '@angular/core';
var app_module_1 = require('./app.module');
//enableProdMode(); //Uncomment for production
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule)
    .then(function (success) { return console.log('App bootstrapped'); })
    .catch(function (err) { return console.error(err); });
//# sourceMappingURL=main.js.map