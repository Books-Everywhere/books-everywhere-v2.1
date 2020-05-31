import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// import { MatCheckboxModule } from '@angular/material/checkbox';
// import { MatButtonModule } from '@angular/material/button';
// import { MatInputModule } from '@angular/material/input';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { MatFormFieldModule } from '@angular/material/form-field';
// import { MatSidenavModule } from '@angular/material/sidenav';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from './services/user.service';
import { TokenService } from './services/token.service';
import { BaseService } from './services/base.service';
import { HttpClientModule } from '@angular/common/http';
import { AppConfig } from './config/config';
import { Helpers } from './helpers/helpers';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    // BrowserAnimationsModule,
    // MatButtonModule,
    // MatCheckboxModule,
    // MatInputModule,
    // MatFormFieldModule,
    // MatSidenavModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [UserService, TokenService, BaseService, AppConfig, Helpers],
  bootstrap: [AppComponent]
})

export class AppModule { }
