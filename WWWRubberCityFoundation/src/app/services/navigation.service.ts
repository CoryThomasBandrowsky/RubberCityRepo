import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {

  constructor(private router: Router) { }

  navigateToLogin(): void {
    this.router.navigate(['/login']);
  }

  navigateToEvents(): void {
    this.router.navigate(['/events']);
  }

  navigateToContact(): void {
    this.router.navigate(['/contact']);
  }

  navigateToDonate(): void {
    this.router.navigate(['/donate']);
  }

  navigateToLocalHelp(): void {
    this.router.navigate(['/localhelp']);
  }
}
