import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { JourneySearchFormComponent } from './journey-search-form/journey-search-form.component';

@NgModule({
  declarations: [
    AppComponent,
    JourneySearchFormComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
