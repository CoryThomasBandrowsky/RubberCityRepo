import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent {
  loginForm: FormGroup;
  isLoading = false;
  errorMessage: string | null = null;
  emailBlurred = false;
  passwordBlurred = false;

  constructor(
    private authService: AuthenticationService,
    private userService: UserService,
    private router: Router,
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
        if(response.valid)
          {
            this.userService.SaveState(response.user);
            this.router.navigate(['helpers/dashboard'])
            this.isLoading = false;
          }
      },
      error:(error) => {
        console.error('Login failed:', error);
        this.errorMessage = 'Invalid email or password';
        this.isLoading = false;
      }
    });
  }

  onBlur(controlName: string) {
    if (controlName === 'email') {
      this.emailBlurred = true;
    } else if (controlName === 'password') {
      this.passwordBlurred = true;
    }
  }
  navigateToLogin(): void {
    this.router.navigate(['/login']);
  }
}
