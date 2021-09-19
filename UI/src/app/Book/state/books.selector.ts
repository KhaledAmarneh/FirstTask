import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Book } from "src/app/models/books.model";
import { booksState } from "./books.state";


const getBooksState = createFeatureSelector<booksState>('book');

export const getBooks = createSelector(getBooksState, (state) => {

    return state.books;
}
);

export const getBookById = (id: number) => createSelector(getBooksState, (state) => {

    return state.books.find((book) => book.Id === id) as Book


}
);
