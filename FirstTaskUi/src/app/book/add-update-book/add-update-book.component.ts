import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { BookComponent } from '../book.component';


@Component({
  selector: 'app-add-update-book',
  templateUrl: './add-update-book.component.html',
  styleUrls: ['./add-update-book.component.css']
})
export class AddUpdateBookComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() book: any;
  BookId: number = 0;
  BookTitle: string = "";
  BookName: string = "";



  ngOnInit(): void {

    this.BookId = this.book.BookId;
    this.BookTitle = this.book.BookTitle;
    this.BookName = this.book.BookName;
  }

  addBook() {
    let val = {
      Name: this.BookName,
      Title: this.BookTitle

    };

    this.service.addBook(val).subscribe(res => {
      alert(res.toString());
    });



  }


  updateBook() {

    let val = {
      Id: this.book.Id, name: this.BookName, title: this.BookTitle
    };
    this.service.updateBook(val).subscribe(
      (res) => {alert(res.toString())},
      (error) => {console.log(error.error)},
      () => (console.log("Finished"))
      );

    


  }

}
