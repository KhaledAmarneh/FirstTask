import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateAuthorComponent } from './add-update-author.component';

describe('AddUpdateAuthorComponent', () => {
  let component: AddUpdateAuthorComponent;
  let fixture: ComponentFixture<AddUpdateAuthorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateAuthorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
