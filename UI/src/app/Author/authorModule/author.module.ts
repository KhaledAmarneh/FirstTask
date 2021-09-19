import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorsListComponent } from '../authors-list/authors-list/authors-list.component';
import { AddAuthorComponent } from '../add-author/add-author/add-author.component';
import { UpdateAuthorComponent } from '../update-author/update-author/update-author.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { _authorsReducer } from '../state/authors.reducer';
import { AuthorsEffects } from '../state/authors.effects';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';



const routes: Routes =[{
  path: '',
  component: AuthorsListComponent,
  children:[
    {
      path: 'add',
      component: AddAuthorComponent,
    },

    {
      path: 'edit/:id',
      component: UpdateAuthorComponent,
    },
  ]

},
];




@NgModule({
  declarations: [AuthorsListComponent,
    AddAuthorComponent,
    UpdateAuthorComponent],


   
    



  
  
  
    imports: [CommonModule ,FormsModule,ReactiveFormsModule,
       RouterModule.forChild(routes),
       NgMultiSelectDropDownModule.forRoot(),
       
       StoreModule.forFeature('author', _authorsReducer),
       EffectsModule.forFeature([AuthorsEffects]) ,
      ],
    
  






})
export class AuthorModule { }
