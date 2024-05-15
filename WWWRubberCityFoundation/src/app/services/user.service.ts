import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { endpoints} from './endpoints';
import { TestResponse } from '../models/test-response';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({ providedIn: 'root' })

export class UserService {

  private userKey = '';

  constructor(private http: HttpClient){}

  CreateUser(userData: User) : Observable<User> {
    return this.http.post<User>(endpoints.usersController.add, userData);
  }

  SaveState(user: User): void {
    const userString = JSON.stringify(user);
    sessionStorage.setItem(this.userKey, userString);
  }

  LoadState(): User | null {
    const userString = sessionStorage.getItem(this.userKey);
    return userString ? JSON.parse(userString) : null;
  }

  ClearState(): void {
    sessionStorage.removeItem(this.userKey);
  }
}
