import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {BookComponent} from './book/book.component';
import {AuthorComponent} from './author/author.component';

const routes: Routes = [

  {path:'books',component:BookComponent},
  {path:'authors',component:AuthorComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
