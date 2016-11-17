import { NgModule }      from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule} from '@angular/http';

import { AppComponent }  from './app.component';
import { routing, routedComponents } from './app.routing';

import { CategoryService } from './services/Category.service';
import { ProductService } from './services/Product.service';
import { EmployeeService } from './services/Employee.service';
import { CustomerService } from './services/Customer.service';
import { OrderService } from './services/Order.service';
import { OrderDetailService } from './services/OrderDetail.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';

@NgModule({
    imports: [BrowserModule, FormsModule, routing, HttpModule],
    declarations: [AppComponent, routedComponents],
    providers: [Title, CategoryService, ProductService, EmployeeService, CustomerService, OrderService, OrderDetailService, AuthService, AuthGuard],
    bootstrap: [AppComponent]
})

export class AppModule { }
