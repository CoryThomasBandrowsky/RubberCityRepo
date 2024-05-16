import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { User } from '../../models/user';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit{
  user: User;
  constructor(
    private userService: UserService,
    private router: Router,
  ){}

  ngOnInit(): void {
    this.user = this.userService.LoadState();
  }
  
  onImageUpload(event: any) {
    // Handle image upload logic
  }

  saveProfile() {
    // Handle save profile logic
  }
}
