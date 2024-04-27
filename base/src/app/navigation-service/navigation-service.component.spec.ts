import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavigationServiceComponent } from './navigation-service.component';

describe('NavigationServiceComponent', () => {
  let component: NavigationServiceComponent;
  let fixture: ComponentFixture<NavigationServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NavigationServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NavigationServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
