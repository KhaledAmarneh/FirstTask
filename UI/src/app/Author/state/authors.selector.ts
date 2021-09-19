import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Author } from "src/app/models/authors.model";
import { authorsState } from "./authors.state";


const getAuthorState = createFeatureSelector<authorsState>('author');

export const getAuthors = createSelector(getAuthorState , (state)=>{
    return state.authors;
}


);
export const getAuthorById = (id: number) => createSelector(getAuthorState, (state) => {

    return state.authors.find((author) => author.Id === id) as Author


}
);
