import { Routes, RouterModule, CanActivate } from '@angular/router';
import { AuthGuard } from './services/auth-guard.service';

import { AboutComponent }   from './about.component';
import { HomeComponent }      from './home.component';
import { ContentComponent }  from './content.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './login/logout.component';
import { SignupComponent } from './signup/signup.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'login', component: LoginComponent, data: { title: 'Login' } },
    { path: 'logout', component: LogoutComponent },
    { path: 'signup', component: SignupComponent, data: { title: 'Signup' } },
    { path: 'home', component: HomeComponent, data: { title: 'Home' } },
    { path: 'content', component: ContentComponent, data: { title: 'Content' }, canActivate: [AuthGuard] },
    { path: 'about', component: AboutComponent, data: { title: 'About' } }
];

export const routing = RouterModule.forRoot(appRoutes);

export const routedComponents = [AboutComponent, LoginComponent, LogoutComponent, SignupComponent, HomeComponent, ContentComponent];
