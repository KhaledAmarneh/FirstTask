import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Book } from 'src/app/models/books.model';
import { AppState } from 'src/app/store/app.state';
import { deleteBook, loadBooks } from '../../state/book.actions';
import { getBooks } from '../../state/books.selector';
import { booksState } from '../../state/books.state';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent implements OnInit {

  books: Observable<Book[]>=new Observable(() => {});

  constructor(private store : Store<{book:booksState}>) { }

  ngOnInit(): void {
    

    this.store.dispatch(loadBooks());
    this.books = this.store.select(getBooks);

    
    
  }



  onDeleteBook(id : number){
    

    if(confirm("Are u Sure to Delete this Book ?!")){
      this.store.dispatch(deleteBook({ id }));
    }
  }

}
