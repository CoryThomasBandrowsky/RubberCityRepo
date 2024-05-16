import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent {
  loginForm: FormGroup;
  isLoading = false;
  errorMessage: string | null = null;

  constructor(
    private authService: AuthenticationService,
    private fb: FormBuilder
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }

    this.isLoading = true;
    this.errorMessage = null;

    const loginData = this.loginForm.value;
    this.authService.login(loginData).subscribe({
      next:(response) => {
        console.log('Login successful:', response);
        // Handle successful login (e.g., store token, navigate to another page)
        this.isLoading = false;
      },
      error:(error) => {
        console.error('Login failed:', error);
        this.errorMessage = 'Invalid email or password';
        this.isLoading = false;
      }
    });
  }
}
