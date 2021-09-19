import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
// import { UpdateBookComponent } from './Book/update-book/update-book/update-book.component';
// import { BooksListComponent } from './Book/books-list/books-list/books-list.component';
// import { AuthorsListComponent } from './Author/authors-list/authors-list/authors-list.component';
// import { AddAuthorComponent } from './Author/add-author/add-author/add-author.component';
// import { UpdateAuthorComponent } from './Author/update-author/update-author/update-author.component';
import { HttpClientModule } from '@angular/common/http';
// import { AddBookComponent } from './Book/add-book/add-book/add-book.component';
import { StoreModule } from '@ngrx/store';
import { appReducer } from './store/app.state';
import { ReactiveFormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { booksReducer } from './Book/state/books.reducer';



@NgModule({
  declarations: [
     AppComponent,
    // AddBookComponent,
    // UpdateBookComponent,
    // BooksListComponent,
    // AuthorsListComponent,
    // AddAuthorComponent,
    // UpdateAuthorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    StoreModule.forRoot({}),
    EffectsModule.forRoot([]),
    ReactiveFormsModule,
    StoreDevtoolsModule.instrument({
      maxAge: 25, // Retains last 25 states
      logOnly: environment.production, // Restrict extension to 
    }),
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
