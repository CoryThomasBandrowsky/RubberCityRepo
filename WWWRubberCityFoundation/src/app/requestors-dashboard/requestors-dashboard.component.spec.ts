import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestorsDashboardComponent } from './requestors-dashboard.component';

describe('RequestorsDashboardComponent', () => {
  let component: RequestorsDashboardComponent;
  let fixture: ComponentFixture<RequestorsDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RequestorsDashboardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RequestorsDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
