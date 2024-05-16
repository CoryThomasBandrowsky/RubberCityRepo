import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { DashboardResult } from '../models/dashboard-result';

@Component({
  selector: 'app-helpers-dashboard',
  templateUrl: './helpers-dashboard.component.html',
  styleUrl: './helpers-dashboard.component.css'
})
export class HelpersDashboardComponent implements OnInit {

  currentUser: User;
  dashboardResults: DashboardResult[];

  constructor(private dashboardService: DashboardService,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.currentUser = this.userService.LoadState();
  
    if (this.currentUser != undefined) {
      this.dashboardService.GetDashboardResults(this.currentUser.id).subscribe({
        next: (response) => {
          this.dashboardResults = response;
        },
        error: (error) => {
          console.error('Error fetching dashboard results:', error);
        }
      });
    } else {
      // Redirect to login or show an error message
      this.router.navigate(['/login']);
    }
  }
  

}
