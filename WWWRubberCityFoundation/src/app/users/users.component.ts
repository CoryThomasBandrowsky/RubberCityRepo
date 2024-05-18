import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  userForm: FormGroup;

  constructor(private fb: FormBuilder,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.userForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      postalCode: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      inputPassword: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['']
    }, {
      validator: this.mustMatch('inputPassword', 'confirmPassword')
    });
  }

  mustMatch(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.controls[password];
      const confirmPasswordControl = formGroup.controls[confirmPassword];

      if (confirmPasswordControl.errors && !confirmPasswordControl.errors['mustMatch']) {
        return;
      }

      if (passwordControl.value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ mustMatch: true });
      } else {
        confirmPasswordControl.setErrors(null);
      }
    };
  }

  onSubmit() {
    if (this.userForm.valid) {
      const formData: User = this.userForm.value;
      formData.imagePath = "na";
      this.userService.CreateUser(formData).subscribe({
        next: (response) => {
          console.log('Help Request Submitted:', response);
          this.router.navigate['/users/sucess']
        },
        error: (error) => {
          console.error('Error submitting help request:', error);
          // Handle errors here, e.g., show an error message
        }
      });
    }
  }
}
