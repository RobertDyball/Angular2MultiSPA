import { NgModule }      from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent }  from './app.component';

import { HttpModule} from '@angular/http';

import { TestDataService } from './services/testData.service';

import { routing, routedComponents } from './app.routing';

import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';

@NgModule({
    imports: [BrowserModule, FormsModule, routing, HttpModule],
    declarations: [AppComponent, routedComponents],
    providers: [Title, TestDataService],
    bootstrap: [AppComponent]
})

export class AppModule { }
