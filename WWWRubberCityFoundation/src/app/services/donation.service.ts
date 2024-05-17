import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Donation } from '../models/donation';
import { endpoints } from './endpoints';

@Injectable({
  providedIn: 'root'
})
export class DonationService {
  constructor(private http: HttpClient) {}

  getDonations(): Observable<Donation[]> {
    return this.http.get<Donation[]>(endpoints.donationsController.getAll);
  }

  getDonationById(id: number): Observable<Donation> {
    return this.http.get<Donation>(`${endpoints.donationsController.getByID}/${id}`);
  }

  addDonation(donation: Donation): Observable<Donation> {
    return this.http.post<Donation>(endpoints.donationsController.add, donation);
  }

  updateDonation(donation: Donation): Observable<Donation> {
    return this.http.put<Donation>(`${endpoints.donationsController.update}/${donation.id}`, donation);
  }

  deleteDonation(id: number): Observable<void> {
    return this.http.delete<void>(`${endpoints.donationsController.delete}/${id}`);
  }
}
