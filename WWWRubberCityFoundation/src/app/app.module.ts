import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { ReactiveFormsModule } from '@angular/forms';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { HelpRequestComponent } from './help-request/help-request.component';
import { UsersSuccessComponent } from '../app/users/success/success.component';
import { HelpersDashboardComponent } from './helpers-dashboard/helpers-dashboard.component';
import { RequestorsDashboardComponent } from './requestors-dashboard/requestors-dashboard.component';
import { AuthenticationComponent } from './authentication/authentication.component'


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UsersComponent,
    HelpRequestComponent,
    UsersSuccessComponent,
    HelpersDashboardComponent,
    RequestorsDashboardComponent,
    AuthenticationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [
    provideClientHydration(),
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
