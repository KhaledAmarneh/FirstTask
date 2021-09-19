import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { authorRequest } from 'src/app/models/authorRequest';
import { Author } from 'src/app/models/authors.model';
import { Book } from 'src/app/models/books.model';
import { BookService } from 'src/app/Services/book.service';
import { AppState } from 'src/app/store/app.state';
import { addAuthor } from '../../state/authors.actions';


@Component({
  selector: 'app-add-author',
  templateUrl: './add-author.component.html',
  styleUrls: ['./add-author.component.scss']
})
export class AddAuthorComponent implements OnInit {

  authorForm!: FormGroup;
  dropdownList!: { item_id: number, item_text: string }[];
  selectedItems:Array<number> = [];
  dropdownSettings = {};


public onItemSelect(event : any){
  console.log(event,'1231321312');
  this.selectedItems.push(event["item_id"])
}

  constructor(private store: Store<AppState>, private bookService: BookService) { }

  ngOnInit() {


    this.bookService.getBooksList().subscribe((data) => (this.dropdownList = data.map(book => { return {item_id: book.Id ?? 0, item_text: book.Name} })));

    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    this.authorForm = new FormGroup({
      name: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
      ]),
      // title: new FormControl(null, [
      //   Validators.required,
      //   Validators.minLength(6),
      // ]),
    });




  }





  onAddAuthor() {
    if (!this.authorForm.valid) {
      return;
    }

    console.log([...this.selectedItems]);
    

    const author: authorRequest = {
      Name: this.authorForm.value.name,
      
      
      bookIds: [...this.selectedItems]

    };

    this.store.dispatch(addAuthor({ author: author }));
  }
}

