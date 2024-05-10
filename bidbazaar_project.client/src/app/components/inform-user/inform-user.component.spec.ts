import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformUserComponent } from './inform-user.component';

describe('InformUserComponent', () => {
  let component: InformUserComponent;
  let fixture: ComponentFixture<InformUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InformUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InformUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
