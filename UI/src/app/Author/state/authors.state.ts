import { Author } from "src/app/models/authors.model";



export interface authorsState {
    authors: Author[];
  }


  export const initialState: authorsState = {
    authors: [
      
    ],
  };