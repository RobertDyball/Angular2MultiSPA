import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule} from '@angular/http';

import { TestDataService } from './services/testData.service';


@NgModule({
    imports: [BrowserModule, HttpModule],
    declarations: [AppComponent],
    providers: [TestDataService],
    bootstrap: [AppComponent]
})
export class AppModule { }
