import { Component, AfterViewInit } from '@angular/core';
import { Donation } from '../models/donation';
import { DonationService } from '../services/donation.service';
import { Router } from '@angular/router';

declare var paypal: any;

@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css']
})
export class DonateComponent {
  donation: Donation = new Donation(0, '', '', 0, new Date(), '');
  amount: number = 1.00; //default

  constructor(private donationService: DonationService, private router: Router) {}

  createPayPalTransaction(): void {
    this.donationService.paypalDonation(this.amount).subscribe(response => {
      window.location.href = response.approvalUrl; // Redirect to PayPal
    }, error => {
      console.error('Error creating PayPal transaction', error);
    });
  }

  navigateToLogin(): void {
    this.router.navigate(['/login']);
  }

  navigateToEvents(): void {
    this.router.navigate(['/events']);
  }

  navigateToContact(): void {
    this.router.navigate(['/contact']);
  }
}
