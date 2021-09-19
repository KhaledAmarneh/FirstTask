import { Book } from "src/app/models/books.model";



export interface booksState {
    books: Book[];
  }


  export const initialState: booksState = {
    books: [],
      
      
    
  };