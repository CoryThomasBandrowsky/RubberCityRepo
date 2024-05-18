import { Component, OnInit } from '@angular/core';
import { LocalHelpService } from '../services/local-help.service';
import { LocalHelp } from '../models/local-help';

@Component({
  selector: 'app-local-help',
  templateUrl: './local-help.component.html',
  styleUrls: ['./local-help.component.css']
})
export class LocalHelpComponent implements OnInit {

  localHelpList: LocalHelp[];

  constructor(private localHelpService: LocalHelpService) { }

  ngOnInit(): void {
    this.localHelpService.getLocalHelp().subscribe({
      next: (response) => {
        this.localHelpList = response;
      },
      error: (error) => {
        console.error('Error fetching local help data:', error);
      }
    });
  }
}
