import { Book } from "./books.model";

  
export interface Author {
    Id?: number;
    Name: string;
    Books: Book[];
    
  }