import { Action, createReducer, on } from '@ngrx/store';
import {  addBookSuccess, deleteBookSuccess, loadBooks, loadBooksSuccess, updateBook, updateBookSuccess } from './book.actions';
import { booksState, initialState } from './books.state';



export const _booksReducer = createReducer(initialState, 
  
  
  on(addBookSuccess,(state ,action)=>{
    let book = {...action.book}
    return{
        ...state,
        books:[...state.books, book],
    };
}),

on(updateBookSuccess, (state , action) => {
  
  const updatedBooks = state.books.map((book) => {
    return action.book.Id === book.Id ? action.book : book;
  });

  return {
    ...state,
    books: updatedBooks,
  };
}),on(loadBooks, (state, action) => {
  
  return {
    ...state,
    successMessage: ''
  };
}), on(deleteBookSuccess, (state, { id }) => {
  const updatedBooks = state.books.filter((book) => {
    return book.Id !== id;
  });

  return {
    ...state,
    books: updatedBooks,
  };
}),





 on(loadBooksSuccess, (state, action) => {
   console.log(state);
   
  return {
    ...state,
    books: action.books,
    
  };

})

);





export function booksReducer(state: booksState = initialState, action: Action) : booksState{
  return _booksReducer(state, action);
}