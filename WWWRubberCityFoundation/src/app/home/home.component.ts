import { Component, OnInit } from '@angular/core';
import { BackendService } from '../services/backend.service';
import { Router } from '@angular/router';

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

}
