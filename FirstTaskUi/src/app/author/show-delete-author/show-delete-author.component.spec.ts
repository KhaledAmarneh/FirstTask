import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeleteAuthorComponent } from './show-delete-author.component';

describe('ShowDeleteAuthorComponent', () => {
  let component: ShowDeleteAuthorComponent;
  let fixture: ComponentFixture<ShowDeleteAuthorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeleteAuthorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowDeleteAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
