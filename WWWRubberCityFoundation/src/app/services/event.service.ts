import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Event } from '../models/event';
import { endpoints } from './endpoints';

@Injectable({ providedIn: 'root' })
export class EventService {
  constructor(private http: HttpClient) {}

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(endpoints.eventsController.getAll);
  }

  getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(`${endpoints.eventsController.getByID}/${id}`);
  }

  addEvent(event: Event): Observable<Event> {
    return this.http.post<Event>(endpoints.eventsController.add, event);
  }

  updateEvent(event: Event): Observable<Event> {
    return this.http.put<Event>(`${endpoints.eventsController.update}/${event.id}`, event);
  }

  deleteEvent(id: number): Observable<void> {
    return this.http.delete<void>(`${endpoints.eventsController.delete}/${id}`);
  }
}
