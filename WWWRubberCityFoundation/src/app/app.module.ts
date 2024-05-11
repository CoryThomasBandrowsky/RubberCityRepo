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
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { HelpRequestComponent } from './help-request/help-request.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserComponent,
    UsersAddComponent,
    UsersDeleteComponent,
    UsersUpdateComponent,
    UsersGetComponent,
    HelpRequestComponent,
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
