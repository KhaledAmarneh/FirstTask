import { createAction , props} from '@ngrx/store';
import { authorRequest } from 'src/app/models/authorRequest';
import { Author } from 'src/app/models/authors.model';


export const ADD_AUTHOR_ACTION = '[authors page] add author';
export const ADD_AUTHOR_SUCCESS = '[authors page] add author success';
export const UPDATE_AUTHOR_ACTION = '[authors page] update author';
export const UPDATE_AUTHOR_SUCCESS = '[authors page] update author success';
export const DELETE_AUTHOR_ACTION = '[authors page] delete author';
export const DELETE_AUTHOR_SUCCESS = '[authors page] delete author success ';

export const LOAD_AUTHORS = '[authors page] load authors'; // '[authors page] load authors' this name used by reducer to trigger corresponding function
export const LOAD_AUTHORS_SUCCESS = '[authors page] load authors success';

export const addAuthor = createAction( ADD_AUTHOR_ACTION, props<{ author: authorRequest }>());
export const addAuthorSuccess = createAction( ADD_AUTHOR_SUCCESS, props<{ author: Author }>());

export const updateAuthor = createAction(UPDATE_AUTHOR_ACTION, props<{ author: authorRequest }>());
export const updateAuthorSuccess = createAction(UPDATE_AUTHOR_SUCCESS, props<{ author: Author }>());

  export const deleteAuthor = createAction(DELETE_AUTHOR_ACTION,props<{ id: number }>()); 
  export const deleteAuthorSuccess = createAction(DELETE_AUTHOR_SUCCESS,props<{ id: number }>() ); 

  export const loadAuthors = createAction(LOAD_AUTHORS);
  export const loadAuthorsSuccess = createAction(
    LOAD_AUTHORS_SUCCESS,
    props<{ authors: Author[] }>()
  );
