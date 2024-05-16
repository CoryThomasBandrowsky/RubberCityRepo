import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HelpRequestService } from '../services/help-request.service'
import { HelpRequestModel } from '../models/help-request-model'; 
import { Router } from '@angular/router';


@Component({
  selector: 'app-help-request',
  templateUrl: './help-request.component.html',
  styleUrls: ['./help-request.component.css']
})
export class HelpRequestComponent implements OnInit {
  helpForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private helpRequestService: HelpRequestService,
    private router: Router
  ) {}

  ngOnInit() {
    this.helpForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
      postalCode: ['', Validators.required],
      messageBody: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.helpForm.valid) {
      const formData: HelpRequestModel = this.helpForm.value;
      formData.dateSubmitted = new Date();
      this.helpRequestService.CreateHelpRequest(formData).subscribe({
        next: (response) => {
          console.log('Help Request Submitted:', response);
          this.router.navigate['help/success']
        },
        error: (error) => {
          console.error('Error submitting help request:', error);
          // Handle errors here, e.g., show an error message
        }
      });
    }
  }
}
