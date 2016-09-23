import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AboutComponent }   from './about.component';
import { HomeComponent }      from './home.component';
import { ContentComponent }  from './content.component';

const appRoutes: Routes = [
    {
        path: '', redirectTo: 'home', pathMatch: 'full'
    },
    {
        path: 'home', component: HomeComponent, data: { title: 'Home' }
    },
    {
        path: 'content', component: ContentComponent, data: { title: 'Content' }
    },
    {
        path: 'about', component: AboutComponent, data: { title: 'About' }
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);

