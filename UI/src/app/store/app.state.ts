import { ActionReducerMap } from "@ngrx/store";
import { authorsReducer } from "../Author/state/authors.reducer";
import { authorsState } from "../Author/state/authors.state";
import { booksReducer } from "../Book/state/books.reducer";
import { booksState } from "../Book/state/books.state";





export interface AppState {
    book: booksState;
    author: authorsState;
  }

  export const appReducer : ActionReducerMap<AppState> = {
 book: booksReducer,
 author: authorsReducer
  };