import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { Book } from 'src/app/models/books.model';
import { AppState } from 'src/app/store/app.state';
import { updateBook } from '../../state/book.actions';
import { getBookById } from '../../state/books.selector';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.scss']
})
export class UpdateBookComponent implements OnInit, OnDestroy {

  book!: Book;
  bookForm!: FormGroup;
  bookSubscription!: Subscription;

  constructor(private route: ActivatedRoute, private store: Store<AppState>, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id) {
        
        this.bookSubscription = this.store
          .select(getBookById(parseInt(id)))
          .subscribe((data) => {
            this.book = data;
            this.createForm()
          });
      }
    });


  }

  createForm() {
    this.bookForm = new FormGroup({
      title: new FormControl(this.book?.Title, [
        Validators.required,
        Validators.minLength(3),
      ]),
      name: new FormControl(this.book?.Name, [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }


  onUpdateBook() {
    if (!this.bookForm.valid) {
      return;
    }


    this.book = { ...this.book,
      Title: this.bookForm.value.title,
      Name: this.bookForm.value.name
    };




    //dispatch the action
    this.store.dispatch(updateBook({ book:this.book }));
    this.router.navigate(['']); // redircet to the books main page
  }




  ngOnDestroy() {
    if (this.bookSubscription) {
      this.bookSubscription.unsubscribe();
    }
  }

}

