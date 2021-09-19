import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { Author } from 'src/app/models/authors.model';
import { AppState } from 'src/app/store/app.state';
import { updateAuthor } from '../../state/authors.actions';
import { getAuthorById } from '../../state/authors.selector';
import { Book } from "../../../models/books.model";
import { BookService } from 'src/app/Services/book.service';
import { authorRequest } from 'src/app/models/authorRequest';

@Component({
  selector: 'app-update-author',
  templateUrl: './update-author.component.html',
  styleUrls: ['./update-author.component.scss']
})
export class UpdateAuthorComponent implements OnInit {

  author!: Author ;
  authorForm!: FormGroup ;
  authorSubscription!: Subscription ;
  dropdownList!: { item_id: number, item_text: string }[];
  dropdownSettings = {};
  selectedItems:Array<number> = [];

  constructor(private route: ActivatedRoute, private store: Store<AppState> , private router: Router , private bookService:BookService) { }

  ngOnInit(): void {
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
    
    this.createForm()
  }

  createForm() {
    this.authorForm = new FormGroup({
      
      name: new FormControl(this.author?.Name, [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }


  onUpdateAuthor(){
    if (!this.authorForm.valid) {
      return;
    }

    

const id  = this.route.snapshot.paramMap.get("id")


    const author: authorRequest = {

      Id : id ? parseInt(id) : null,
      Name: this.authorForm.value.name,
      bookIds: [...this.selectedItems]
    };

    //dispatch the action
    this.store.dispatch(updateAuthor({author : author}));
    this.router.navigate(['']); 
  }


  

  ngOnDestroy() {
    if (this.authorSubscription) {
      this.authorSubscription.unsubscribe();
    }
  }


  public onItemSelect(event : any){
    this.selectedItems.push(event["item_id"])
  }

}
