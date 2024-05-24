import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactListComponent } from './contact/view/contact-list/contact-list.component';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { ContactDetailsComponent } from './contact/view/contact-details/contact-details.component';
import { ContactFormComponent } from './contact/view/contact-form/contact-form.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactDetailsComponent,
    ContactFormComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, CommonModule, RouterOutlet, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
