import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HelpersDashboardComponent } from './helpers-dashboard.component';

describe('HelpersDashboardComponent', () => {
  let component: HelpersDashboardComponent;
  let fixture: ComponentFixture<HelpersDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HelpersDashboardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HelpersDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
