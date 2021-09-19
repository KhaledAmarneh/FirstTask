import { Action, createReducer, on } from '@ngrx/store';
import { addAuthor, addAuthorSuccess, deleteAuthor, deleteAuthorSuccess, loadAuthors, loadAuthorsSuccess, updateAuthor, updateAuthorSuccess } from './authors.actions';
import { authorsState, initialState } from './authors.state';


export const _authorsReducer = createReducer(initialState,


on(addAuthorSuccess,(state ,action)=>{
  let author = {...action.author}
  return{
      ...state,
      authors:[...state.authors, author],
  };
}),
on(updateAuthorSuccess, (state , action) => {
  const updatedAuthors = state.authors.map((author) => {
    return action.author.Id === author.Id ? action.author : author;
  });

  return {
    ...state,
    books: updatedAuthors,
  };
}),on(loadAuthors, (state, action) => {
  
  return {
    ...state,
    successMessage: ''
  };
}), on(loadAuthorsSuccess, (state, action) => {
  console.log(state);
  
 return {
   ...state,
   authors: action.authors,
   
 };

}),
on(deleteAuthorSuccess, (state, { id }) => {
  const updatedAuthors = state.authors.filter(author => {
    return author.Id !== id;
  });

  return {
    ...state,
    authors: updatedAuthors,
  };
})




);

export function authorsReducer(state: authorsState = initialState, action: Action) : authorsState{
  return _authorsReducer(state, action);
}