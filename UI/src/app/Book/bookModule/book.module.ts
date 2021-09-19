import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { BooksListComponent } from '../books-list/books-list/books-list.component';
import { AddBookComponent } from '../add-book/add-book/add-book.component';
import { UpdateBookComponent } from '../update-book/update-book/update-book.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { BooksEffects } from '../state/books.effects';
import { StoreModule } from '@ngrx/store';
import { _booksReducer } from '../state/books.reducer';



const routes: Routes =[{
  path: '',
  component: BooksListComponent,
  children:[
    {
      path: 'add',
      component: AddBookComponent,
    },

    {
      path: 'edit/:id',
      component: UpdateBookComponent,
    },
  ]

},
];




@NgModule({
  declarations: [
    AddBookComponent,
    UpdateBookComponent,
    BooksListComponent,],


   
    



  
  
  
    imports: [CommonModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forChild(routes),
      StoreModule.forFeature('book', _booksReducer),

      EffectsModule.forFeature([BooksEffects]) , 
    ],

    
  






})
export class BookModule { }
