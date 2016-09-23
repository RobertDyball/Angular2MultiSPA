"use strict";
var router_1 = require('@angular/router');
var about_component_1 = require('./about.component');
var home_component_1 = require('./home.component');
var content_component_1 = require('./content.component');
var appRoutes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: home_component_1.HomeComponent
    },
    {
        path: 'content',
        component: content_component_1.ContentComponent
    },
    {
        path: 'about',
        component: about_component_1.AboutComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map