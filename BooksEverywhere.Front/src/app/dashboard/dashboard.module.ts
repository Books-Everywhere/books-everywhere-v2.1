import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';

@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    DashboardRoutingModule,
    HttpClientModule
  ],
  bootstrap: [DashboardComponent],
})

export class DashboardModule { }
