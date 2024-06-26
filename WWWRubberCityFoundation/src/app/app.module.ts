import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Add this import
import { HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { HelpRequestComponent } from './help-request/help-request.component';
import { UsersSuccessComponent } from './users/success/success.component';
import { HelpersDashboardComponent } from './helpers-dashboard/helpers-dashboard.component';
import { RequestorsDashboardComponent } from './requestors-dashboard/requestors-dashboard.component';
import { AuthenticationComponent } from './authentication/authentication.component';
import { MatCardModule } from '@angular/material/card';
import { HelpRequestSuccessComponent } from './help-request/success/success.component';
import { UserProfileComponent } from './users/user-profile/user-profile.component';
import { EventsComponent } from './events/events.component';
import { ContactComponent } from './contact/contact.component';
import { DonateComponent } from './donate/donate.component';
import { DonateSuccessComponent } from './donate/success/success.component';
import { DonateCancelComponent } from './donate/cancel/cancel.component';
import { LocalHelpComponent } from './local-help/local-help.component';
import { MenuComponent } from './menu/menu.component';
import { MenuMobileComponent } from './menu-mobile/menu-mobile.component';
import { ResponsiveService } from './services/responsive.service';
import { MatToolbarModule } from '@angular/material/toolbar';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UsersComponent,
    HelpRequestComponent,
    UsersSuccessComponent,
    HelpersDashboardComponent,
    RequestorsDashboardComponent,
    AuthenticationComponent,
    HelpRequestSuccessComponent,
    UserProfileComponent,
    EventsComponent,
    ContactComponent,
    DonateComponent,
    DonateSuccessComponent,
    DonateCancelComponent,
    LocalHelpComponent,
    MenuComponent,
    MenuMobileComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule, // Add this to imports
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    FormsModule,
    MatToolbarModule
    ],
  providers: [ResponsiveService],
  bootstrap: [AppComponent]
})
export class AppModule { }
