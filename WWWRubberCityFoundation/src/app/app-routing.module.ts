import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { HelpRequestComponent } from './help-request/help-request.component';
import { HelpersDashboardComponent } from './helpers-dashboard/helpers-dashboard.component';
import { AuthenticationComponent } from './authentication/authentication.component';
import { UsersSuccessComponent } from './users/success/success.component';
import { HelpRequestSuccessComponent } from './help-request/success/success.component';
import { UserProfileComponent } from './users/user-profile/user-profile.component';
import { EventsComponent } from './events/events.component';
import { ContactComponent } from './contact/contact.component';
import { DonateComponent } from './donate/donate.component';
import { DonateSuccessComponent } from './donate/success/success.component';
import { DonateCancelComponent } from './donate/cancel/cancel.component';
import { LocalHelpComponent } from './local-help/local-help.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'help', component: HelpRequestComponent },
  { path: 'help/success', component: HelpRequestSuccessComponent },
  { path: 'users/register', component: UsersComponent },
  { path: 'users/success', component: UsersSuccessComponent },
  { path: 'users/profile', component: UserProfileComponent },
  { path: 'login', component: AuthenticationComponent },
  { path: 'helpers/dashboard', component: HelpersDashboardComponent },
  { path: 'events', component: EventsComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'donate', component: DonateComponent },
  { path: 'donate/cancel', component: DonateCancelComponent },
  { path: 'donate/success', component: DonateSuccessComponent },
  { path: 'localhelp', component: LocalHelpComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
