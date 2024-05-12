import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { HelpRequestComponent } from './help-request/help-request.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'users/register', component: UsersComponent },
  { path: 'need-help', component: HelpRequestComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
