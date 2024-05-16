import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-success',
  templateUrl: './success.component.html',
  styleUrl: './success.component.css'
})
export class HelpRequestSuccessComponent {
  constructor(private router: Router) { }

  ngOnInit() {
    // Redirect to the dashboard after 10 seconds
    setTimeout(() => {
      this.router.navigate(['/home']); // Adjust the route as necessary
    }, 10000);
  }

  continue() {
    // Function to handle manual redirection when user clicks the link
    this.router.navigate(['/home']); // Adjust the route as necessary
  }
}
