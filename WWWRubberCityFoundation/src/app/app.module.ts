import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './users/users.component';
import { UsersAddComponent } from './users/users-add/users-add.component';
import { UsersDeleteComponent } from './users/users-delete/users-delete.component';
import { UsersUpdateComponent } from './users/users-update/users-update.component';
import { UsersGetComponent } from './users/users-get/users-get.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserComponent,
    UsersAddComponent,
    UsersDeleteComponent,
    UsersUpdateComponent,
    UsersGetComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
