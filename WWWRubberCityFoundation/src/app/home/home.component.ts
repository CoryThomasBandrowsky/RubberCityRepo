import { Component, OnInit } from '@angular/core';
import { BackendService } from '../services/backend.service';
import { Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})


export class HomeComponent implements OnInit {

  testResult: any;

  constructor(private backendService: BackendService,
    private router: Router){ }
  

  ngOnInit(): void {

  }

  MakeTestGet() {
    this.backendService.DoSetup().subscribe({
      next: (x) =>{
        this.testResult = x;
        var okay = "";
      },
      error: (err) => {
        console.error('Error', err);
      },
      complete: () => {
        console.log('Completed');
      }
    })
  }

  MakeTestUser() {
    this.router.navigate(['/user']);
  }
  navigateToLogin(): void {
    this.router.navigate(['/login']);
  }

  navigateToEvents(): void {
    this.router.navigate(['/events'])
  }

  navigateToContact(): void{
    this.router.navigate(['/contact'])
  }
}
