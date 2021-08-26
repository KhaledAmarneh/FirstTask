import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookComponent } from './book/book.component';
import { AuthorComponent } from './author/author.component';
import {SharedService} from './shared.service';
import { AddUpdateBookComponent } from './book/add-update-book/add-update-book.component';
import { ShowDeleteBookComponent } from './book/show-delete-book/show-delete-book.component';
import { ShowDeleteAuthorComponent } from './author/show-delete-author/show-delete-author.component';
import { AddUpdateAuthorComponent } from './author/add-update-author/add-update-author.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    ShowDeleteBookComponent,
    AddUpdateBookComponent,
    AuthorComponent,
    ShowDeleteAuthorComponent,
    AddUpdateAuthorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
