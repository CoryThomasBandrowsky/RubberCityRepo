import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-helpers-dashboard',
  templateUrl: './helpers-dashboard.component.html',
  styleUrl: './helpers-dashboard.component.css'
})
export class HelpersDashboardComponent implements OnInit {

  currentUser: User;

  constructor(private dashboardService: DashboardService,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    

    this.currentUser = this.userService.LoadState();

    this.dashboardService.GetDashboardResults(1).subscribe({
      next: (response) => {
        console.log('Help Request Submitted:', response);
        this.router.navigate['/helpers/dashboard']
      },
      error: (error) => {
        console.error('Error submitting help request:', error);
        // Handle errors here, e.g., show an error message
      }});

    if(this.currentUser != null)
    {

    }
    else
    {
      return;
    }
  }

}
