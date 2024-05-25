import { Component, OnInit } from '@angular/core';
import { NavigationService } from './services/navigation.service';
import { ResponsiveService } from './services/responsive.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  isMobile: boolean = false;

  constructor(public navigationService: NavigationService,
    private responsiveService: ResponsiveService
  ) { }

  ngOnInit() {
    this.responsiveService.isMobile$.subscribe(isMobile => {
      this.isMobile = isMobile;
    });
  }

  title = 'WWWRubberCityFoundation';
}
