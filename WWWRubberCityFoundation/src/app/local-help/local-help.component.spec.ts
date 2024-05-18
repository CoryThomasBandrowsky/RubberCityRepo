import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocalHelpComponent } from './local-help.component';

describe('LocalHelpComponent', () => {
  let component: LocalHelpComponent;
  let fixture: ComponentFixture<LocalHelpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LocalHelpComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LocalHelpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
