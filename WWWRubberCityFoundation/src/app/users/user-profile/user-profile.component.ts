import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { User } from '../../models/user';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  user: User;
  selectedFile: File | null = null;

  constructor(
    private userService: UserService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.user = this.userService.LoadState();
  }

  onImageUpload(event: any) {
    this.selectedFile = event.target.files[0];
  }

  saveProfile() {
    if (this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);
      formData.append('userId', this.user.id.toString());

      this.userService.uploadProfilePicture(formData).subscribe(response => {
        // Assuming the response contains the updated user with the image path
        this.user = response;
        this.userService.SaveState(this.user); // Save updated user state
      });
    }
  }
}
