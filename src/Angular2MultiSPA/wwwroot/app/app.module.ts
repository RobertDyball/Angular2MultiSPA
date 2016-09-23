import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent }  from './app.component';

import { HttpModule} from '@angular/http';
import { TestDataService } from './services/testData.service';

import { AboutComponent }   from './about.component';
import { HomeComponent }      from './home.component';
import { ContentComponent }  from './content.component';

import { routing } from './app.routing';

@NgModule({
    imports: [BrowserModule, FormsModule, routing, HttpModule],
    declarations: [AppComponent, AboutComponent, HomeComponent, ContentComponent],
    providers: [TestDataService],
    bootstrap: [AppComponent]
})
export class AppModule { }
