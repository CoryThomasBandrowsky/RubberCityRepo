import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { endpoints} from './endpoints';
import { TestResponse } from '../models/test-response';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({ providedIn: 'root' })

export class BackendService {

  constructor(private http: HttpClient){}

  DoSetup() : Observable<TestResponse> {
    return this.http.get<TestResponse>(endpoints.homeController.home);
  }

  MakeUser(userData: User) : Observable<User> {
    return this.http.post<User>(endpoints.usersController.add, userData);
  }
}