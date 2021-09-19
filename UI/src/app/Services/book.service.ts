import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Book } from '../models/books.model';
@Injectable({
  providedIn: 'root'
})
export class BookService {

  readonly APIUrl="https://localhost:5001";

  constructor(private http:HttpClient) { }


  getBooksList():Observable<Book[]>{
    return this.http.get<Book[]>(this.APIUrl+'/Book').pipe(
      map((data) => {
        return data;
      })
    );
}
  

  addBook(book :Book):Observable<{name:string}>{
  
    return this.http.post<{name:string}>(this.APIUrl+'/Book',book);
  }

  updateBook(book : Book ){
    

    // const {Id,...body} = val
    return this.http.put(this.APIUrl+'/Book/'+book.Id,book);
  }

  deleteBook(val:any){
    return this.http.delete(this.APIUrl+'/Book/'+val);
  }
}
