import { createAction , props} from '@ngrx/store';

import { Book } from 'src/app/models/books.model';

export const ADD_Book_ACTION = '[books page] add book';
export const ADD_Book_SUCCESS = '[books page] add book success';
export const UPDATE_BOOK_ACTION = '[posts page] update book';
export const UPDATE_BOOK_ACTION_SUCCESS = '[posts page] update book success';
export const LOAD_BOOKS = '[books page] load books'; // '[books page] load books' this name used by reducer to trigger corresponding function
export const LOAD_BOOKS_SUCCESS = '[books page] load books success';
export const DELETE_BOOK_ACTION = '[posts page] delete book';
export const DELETE_BOOK_SUCCESS = '[posts page] delete book success';


export const addBook = createAction(ADD_Book_ACTION, props<{ book: Book }>());
export const addBookSuccess = createAction(ADD_Book_SUCCESS, props<{ book: Book }>());
export const updateBook = createAction(UPDATE_BOOK_ACTION, props<{ book: Book  }>());
export const updateBookSuccess = createAction(UPDATE_BOOK_ACTION_SUCCESS, props<{ book: Book }>());
export const deleteBook = createAction(DELETE_BOOK_ACTION,props<{ id: number }>());
export const deleteBookSuccess = createAction(DELETE_BOOK_SUCCESS,props<{ id: number }>());

export const loadBooks = createAction(LOAD_BOOKS);
export const loadBooksSuccess = createAction(LOAD_BOOKS_SUCCESS,props<{ books: Book[] }>()
);