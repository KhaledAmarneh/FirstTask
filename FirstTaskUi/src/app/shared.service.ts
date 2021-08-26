import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl="https://localhost:5001";

  constructor(private http:HttpClient) { }


  getBooksList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Book');
  }

  addBook(val:any){
    return this.http.post(this.APIUrl+'/Book',val);
  }

  updateBook(val:any){
    const {Id,...body} = val
    return this.http.put(this.APIUrl+'/Book/'+Id,body);
  }

  deleteBook(val:any){
    return this.http.delete(this.APIUrl+'/Book/'+val);
  }



  getAuthorsList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Author');
  }

  addAuthor(val:any){
    return this.http.post(this.APIUrl+'/Author',val);
  }

  updateAuthor(val:any){
    const {Id,...body} = val
    return this.http.put(this.APIUrl+'/Author/'+Id,body);
  }

  deleteAuthor(val:any){
    return this.http.delete(this.APIUrl+'/Author/'+val);
  }



}

