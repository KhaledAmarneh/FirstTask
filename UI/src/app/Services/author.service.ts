import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import { Author } from '../models/authors.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  readonly APIUrl="https://localhost:5001";

  constructor(private http:HttpClient) { }




  getAuthorsList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Author').pipe(
      map((data) => {
        return data;
      })
    );
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
