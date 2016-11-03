import { NgModule }      from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule} from '@angular/http';

import { AppComponent }  from './app.component';
import { routing, routedComponents } from './app.routing';

import { CategoryService } from './services/Category.service';
import { EmployeeService } from './services/Employee.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';

@NgModule({
    imports: [BrowserModule, FormsModule, routing, HttpModule],
    declarations: [AppComponent, routedComponents],
    providers: [Title, CategoryService, EmployeeService, AuthService, AuthGuard],
    bootstrap: [AppComponent]
})

export class AppModule { }
