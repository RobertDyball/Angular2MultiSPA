"use strict";
var router_1 = require('@angular/router');
var about_component_1 = require('./about.component');
var home_component_1 = require('./home.component');
var content_component_1 = require('./content.component');
var login_component_1 = require('./login/login.component');
var signup_component_1 = require('./signup/signup.component');
var appRoutes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'login', component: login_component_1.LoginComponent, data: { title: 'Login' } },
    { path: 'signup', component: signup_component_1.SignupComponent, data: { title: 'Signup' } },
    { path: 'home', component: home_component_1.HomeComponent, data: { title: 'Home' } },
    { path: 'content', component: content_component_1.ContentComponent, data: { title: 'Content' } },
    { path: 'about', component: about_component_1.AboutComponent, data: { title: 'About' } }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
exports.routedComponents = [about_component_1.AboutComponent, login_component_1.LoginComponent, signup_component_1.SignupComponent, home_component_1.HomeComponent, content_component_1.ContentComponent];
//# sourceMappingURL=app.routing.js.map