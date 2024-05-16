import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { endpoints } from './endpoints';
import { Observable } from 'rxjs';
import { AuthenticationRequest } from '../models/authentication-request';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  constructor(private http: HttpClient) {}

  login(data: AuthenticationRequest): Observable<any> {
    return this.http.post<any>(endpoints.authenticationController.login, data);
  }
}
