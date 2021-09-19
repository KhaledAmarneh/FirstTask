import { Injectable } from "@angular/core";
import { exhaustMap, map, mergeMap, switchMap } from 'rxjs/operators';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { BookService } from "src/app/Services/book.service";
import { addBook, addBookSuccess, deleteBook, deleteBookSuccess, loadBooks, loadBooksSuccess, updateBook, updateBookSuccess } from "./book.actions";
import { Store } from "@ngrx/store";
import { booksState } from "./books.state";


@Injectable()

export class BooksEffects {


  constructor(private actions$: Actions, private bookService: BookService, private store: Store<{ book: booksState }>) { }

  loadBooks$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(loadBooks),
      mergeMap((action) => {
        return this.bookService.getBooksList().pipe(
          map((books) => {
            return loadBooksSuccess({ books });
          })
        );
      })
    );
  });


  addBook$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(addBook),
      exhaustMap((action) => {
        return this.bookService.addBook(action.book).pipe(
          map((data : any) => {
            return addBookSuccess({ book: data });
          })
        );
      })
    );
  });


  deleteBook$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(deleteBook),
      switchMap((action) => {
        return this.bookService.deleteBook(action.id).pipe(
          map((data) => {
            return deleteBookSuccess({ id: action.id });
          })
        );
      })
    );
  });

  updateBook$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(updateBook),
      switchMap((action) => {
        return this.bookService.updateBook(action.book).pipe(
          map((data) => {
            return updateBookSuccess({ book: action.book });
          })
        );
      })
    );
  });

      


}