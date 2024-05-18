import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalHelp } from '../models/local-help';
import { endpoints } from './endpoints';

@Injectable({
  providedIn: 'root'
})
export class LocalHelpService {
  constructor(private http: HttpClient) { }

  getLocalHelp(): Observable<LocalHelp[]> {
    return this.http.get<LocalHelp[]>(endpoints.localHelpController.getAll);
  }
}
