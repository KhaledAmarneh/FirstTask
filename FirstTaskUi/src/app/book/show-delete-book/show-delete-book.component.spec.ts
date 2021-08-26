import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeleteBookComponent } from './show-delete-book.component';

describe('ShowDeleteBookComponent', () => {
  let component: ShowDeleteBookComponent;
  let fixture: ComponentFixture<ShowDeleteBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeleteBookComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowDeleteBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
