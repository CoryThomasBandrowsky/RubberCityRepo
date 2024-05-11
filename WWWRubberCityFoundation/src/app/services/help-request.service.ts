import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { endpoints} from './endpoints';
import { TestResponse } from '../models/test-response';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { HelpRequestModel } from '../models/help-request-model'

@Injectable({ providedIn: 'root' })

export class HelpRequestService {

  constructor(private http: HttpClient){}

  CreateHelpRequest(helpRequestData: HelpRequestModel) : Observable<HelpRequestModel> {
    return this.http.post<HelpRequestModel>(endpoints.helpRequestController.add, helpRequestData);
  }
}
