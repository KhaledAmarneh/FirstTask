import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';


@Component({
  selector: 'app-show-delete-book',
  templateUrl: './show-delete-book.component.html',
  styleUrls: ['./show-delete-book.component.css']
})
export class ShowDeleteBookComponent implements OnInit {

  constructor(private service:SharedService) { }


  BookList:Array<any>=[];

  ModalTitle:string = "";
  ActivateAddEditBookComp:boolean=false;
  book:any;

  ngOnInit(): void {

    this.refreshBookList();
  }

  addClick(){
    this.book={
      BookId:0,
      BookName:"",
      BookTitle:"",
    }
    this.ModalTitle="Add Book";
    this.ActivateAddEditBookComp=true;

  }

  closeClick(){
    this.ActivateAddEditBookComp=false;
    this.refreshBookList();
  }


  updateClick(item : any){
    console.log(item);
    this.book=item;
    this.ModalTitle="Edit Book";
    this.ActivateAddEditBookComp=true;
  }

  deleteClick(item : any){
    if(confirm('Are you sure??')){
      this.service.deleteBook(item.Id).subscribe(data=>{
        // alert(data.toString());
        this.refreshBookList();
      })
    }
  }
  
  
  refreshBookList() {
    this.service.getBooksList().subscribe(data=>{
      this.BookList=data;
  });
  

  }


}
