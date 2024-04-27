import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-users-add',
  templateUrl: './users-add.component.html',
  styleUrl: './users-add.component.css'
})
export class UsersAddComponent implements OnInit {

  addUserForm: FormGroup;
  passwordVisible: boolean = false;

  constructor(private fb: FormBuilder, private userService: UserService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(): void {
    this.addUserForm = this.fb.group({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      phoneNumber: new FormControl('', Validators.required),
      postalCode: new FormControl(''),
      inputPassword: new FormControl('', [Validators.required, Validators.minLength(8)]),
    });
  }

  onSubmit(): void {
    if (this.addUserForm.valid) {
      this.userService.CreateUser(this.addUserForm.value).subscribe({
        next: (x) =>{
          console.log('Success', x);
        },
        error: (err) =>{
          console.error('Error', err);
        },
        complete: () =>{
          console.log('Completed');
        }
      })
    }
  }

  togglePasswordVisibility(): void {
    this.passwordVisible = !this.passwordVisible;
  }

}
