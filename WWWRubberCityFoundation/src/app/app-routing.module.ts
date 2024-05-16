import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { HelpRequestComponent } from './help-request/help-request.component';
import { HelpersDashboardComponent } from './helpers-dashboard/helpers-dashboard.component';
import { AuthenticationComponent } from './authentication/authentication.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'need-help', component: HelpRequestComponent },
  { path: 'users/register', component: UsersComponent },
  { path: 'users/success', component: HelpRequestComponent },
  { path: 'login', component: AuthenticationComponent },
  { path: 'helpers/dashboard', component: HelpersDashboardComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
