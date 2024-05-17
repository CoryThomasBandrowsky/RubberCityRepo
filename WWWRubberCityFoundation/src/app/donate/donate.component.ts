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
export class DonateComponent implements AfterViewInit {
  donation: Donation = new Donation(0, '', '', 0, new Date(), '');

  constructor(private donationService: DonationService, private router: Router) {}

  ngAfterViewInit(): void {
    this.loadPayPalScript().then(() => {
      this.renderPayPalButton();
    });
  }

  loadPayPalScript(): Promise<void> {
    return new Promise((resolve, reject) => {
      if ((window as any).paypal) {
        resolve();
      } else {
        const script = document.createElement('script');
        script.src = 'https://www.paypal.com/sdk/js?client-id=AaBmMR5jI82BxBzBTB8IV_Se7n-n0qcVGd8futctk7Rn26UPcIO53lMYIYKnYFv5Rz3v5F5JDELN2ok3';
        script.onload = () => {
          resolve();
        };
        script.onerror = (error) => {
          reject(error);
        };
        document.body.appendChild(script);
      }
    });
  }

  renderPayPalButton(): void {
    paypal.Buttons({
      createOrder: (data, actions) => {
        return actions.order.create({
          purchase_units: [{
            amount: {
              value: this.donation.amount.toString()
            }
          }]
        });
      },
      onApprove: (data, actions) => {
        return actions.order.capture().then(details => {
          this.donation.PaymentId = details.id; // Capture payment ID
          this.onDonationSuccess();
        });
      }
    }).render('#paypal-button-container');
  }

  onDonationSuccess(): void {
    console.log('Transaction completed by ' + this.donation.donorName);
    // Save donation details to your backend
    this.donationService.addDonation(this.donation).subscribe(response => {
      console.log('Donation successful', response);
      // Optionally, you can reset the form or provide feedback to the user here.
    });
  }

  onSubmit(): void {
    this.donationService.addDonation(this.donation).subscribe(response => {
      console.log('Donation successful', response);
      // Optionally, you can reset the form or provide feedback to the user here.
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
