import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewAuctionsComponent } from './new-auctions.component';

describe('NewAuctionsComponent', () => {
  let component: NewAuctionsComponent;
  let fixture: ComponentFixture<NewAuctionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewAuctionsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewAuctionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
