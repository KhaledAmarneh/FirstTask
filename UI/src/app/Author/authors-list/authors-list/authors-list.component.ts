import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Author } from 'src/app/models/authors.model';
import { AppState } from 'src/app/store/app.state';
import { deleteAuthor, loadAuthors } from '../../state/authors.actions';
import { getAuthors } from '../../state/authors.selector';

@Component({
  selector: 'app-authors-list',
  templateUrl: './authors-list.component.html',
  styleUrls: ['./authors-list.component.scss']
})
export class AuthorsListComponent implements OnInit {

  authors : Observable<Author[]> | undefined

  constructor(private store : Store<AppState>) { }

  ngOnInit(): void {

    this.store.dispatch(loadAuthors());
    this.authors = this.store.select(getAuthors);

  }


  onDeleteAuthor(id : number){

    if(confirm("Are u Sure to Delete this Author ?!")){
      this.store.dispatch(deleteAuthor({ id }));
    }
  }

}
