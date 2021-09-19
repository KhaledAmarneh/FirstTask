import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Book } from 'src/app/models/books.model';
import { AppState } from 'src/app/store/app.state';
import { addBook, addBookSuccess } from '../../state/book.actions';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent implements OnInit {
  bookForm!: FormGroup ; 

  constructor(private store: Store<AppState>) { }

  ngOnInit(): void {
    this.bookForm = new FormGroup({
      name: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
      ]),
      title: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }

  onAddBook() {
    if (!this.bookForm.valid) {
      return;
    }

    const book: Book = {

      Title: this.bookForm.value.title,
      Name: this.bookForm.value.name
      
    };

    this.store.dispatch(addBook({ book }));
  }

}
