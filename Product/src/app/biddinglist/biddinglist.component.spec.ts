import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiddinglistComponent } from './biddinglist.component';

describe('BiddinglistComponent', () => {
  let component: BiddinglistComponent;
  let fixture: ComponentFixture<BiddinglistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BiddinglistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BiddinglistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
