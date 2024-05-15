import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { endpoints} from './endpoints';
import { TestResponse } from '../models/test-response';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { DashboardResult } from '../models/dashboard-result'

@Injectable({ providedIn: 'root' })

export class DashboardService {

  constructor(private http: HttpClient){}

  GetDashboardResults(id: number) : Observable<DashboardResult[]> {
    const url = `${endpoints.dashboardController.get}?id=${id}`;
    return this.http.get<DashboardResult[]>(url);
  }
}
