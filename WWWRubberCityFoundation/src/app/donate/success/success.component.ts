import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DonationService } from '../../services/donation.service';

@Component({
  selector: 'app-success',
  template: '<h1>Donation Successful!</h1>'
})
export class SuccessComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private donationService: DonationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const paymentId = this.route.snapshot.queryParamMap.get('paymentId');
    const payerId = this.route.snapshot.queryParamMap.get('PayerID');

    if (paymentId && payerId) {
      this.donationService.executePayPalTransaction(paymentId, payerId)
        .subscribe(response => {
          if (response.success) {
            console.log('Payment successful');
          } else {
            console.log('Payment failed');
            this.router.navigate(['/donate']);
          }
        }, error => {
          console.error('Error executing PayPal transaction', error);
          this.router.navigate(['/donate']);
        });
    } else {
      console.error('Missing paymentId or payerId');
      this.router.navigate(['/donate']);
    }
  }
}
