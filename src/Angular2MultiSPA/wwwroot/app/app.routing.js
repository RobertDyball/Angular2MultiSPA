"use strict";
var router_1 = require('@angular/router');
var about_component_1 = require('./about.component');
var home_component_1 = require('./home.component');
var content_component_1 = require('./content.component');
var appRoutes = [
    {
        path: '', redirectTo: 'home', pathMatch: 'full'
    },
    {
        path: 'home', component: home_component_1.HomeComponent, data: { title: 'Home' }
    },
    {
        path: 'content', component: content_component_1.ContentComponent, data: { title: 'Content' }
    },
    {
        path: 'about', component: about_component_1.AboutComponent, data: { title: 'About' }
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map