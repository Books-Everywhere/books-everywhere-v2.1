import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from './services/user.service';
import { TokenService } from './services/token.service';
import { BaseService } from './services/base.service';
import { HttpClientModule } from '@angular/common/http';
import { AppConfig } from './config/config';
import { Helpers } from './helpers/helpers';
import { PublicComponent } from './public/public.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    PublicComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [UserService, TokenService, BaseService, AppConfig, Helpers],
  bootstrap: [AppComponent]
})

export class AppModule { }
