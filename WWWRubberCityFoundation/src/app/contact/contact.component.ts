import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})
export class ContactComponent {

  constructor(private router: Router){ }


  navigateToLogin(): void {
    this.router.navigate(['/login']);
  }

  navigateToEvents(): void {
    this.router.navigate(['/events'])
  }
}