import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { AuthorService } from "src/app/Services/author.service";
import { authorsState } from "./authors.state";
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { addAuthor, addAuthorSuccess, deleteAuthor, deleteAuthorSuccess, loadAuthors, loadAuthorsSuccess, LOAD_AUTHORS, updateAuthor, updateAuthorSuccess } from "./authors.actions";
import { exhaustMap, map, mergeMap, switchMap, tap } from "rxjs/operators";

@Injectable()

export class AuthorsEffects{


constructor(private actions$:Actions , private authorService:AuthorService ,  private store: Store<{ author: authorsState }>){}

loadAuthors$ = createEffect(() => {

    
    return this.actions$.pipe(
      ofType(loadAuthors),
      mergeMap((action) => {
        return this.authorService.getAuthorsList().pipe(
          map((authors) => {
            return loadAuthorsSuccess({ authors });
          })
        );
      })
    );
  });

  addAuthor$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(addAuthor),
      exhaustMap((action) => {
        return this.authorService.addAuthor(action.author ).pipe(
          map((data : any) => {
            return addAuthorSuccess({ author: data });
          })
        );
      })
    );
  });

  deleteAuthor$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(deleteAuthor),
      switchMap((action) => {
        return this.authorService.deleteAuthor(action.id).pipe(
          map((data) => {
            return deleteAuthorSuccess({ id: action.id });
          })
        );
      })
    );
  });

  updateAuthor$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(updateAuthor),
      switchMap((action) => {
        return this.authorService.updateAuthor(action.author).pipe(
          map((data : any) => {
            return updateAuthorSuccess({ author: data });
          })
        );
      })
    );
  });


}