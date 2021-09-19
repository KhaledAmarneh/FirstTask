import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { AddAuthorComponent } from './Author/add-author/add-author/add-author.component';
// import { AuthorsListComponent } from './Author/authors-list/authors-list/authors-list.component';
// import { UpdateAuthorComponent } from './Author/update-author/update-author/update-author.component';
import { AddBookComponent } from './Book/add-book/add-book/add-book.component';
import { BooksListComponent } from './Book/books-list/books-list/books-list.component';
import { UpdateBookComponent } from './Book/update-book/update-book/update-book.component';

const routes: Routes = [

  {
    path: '',
    loadChildren:()=>import('./Book/bookModule/book.module').then((m)=>m.BookModule)

    
  },
  {
    path: 'authors',
    loadChildren:()=>import('./Author/authorModule/author.module').then((m)=>m.AuthorModule)
   
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
