import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-add-update-author',
  templateUrl: './add-update-author.component.html',
  styleUrls: ['./add-update-author.component.css']
})
export class AddUpdateAuthorComponent implements OnInit {

  constructor(private service: SharedService) { }
  @Input() author: any;
  AuthorId: number = 0;
  Name: string = "";
  BookIds: string = "";


  ngOnInit(): void {
    this.AuthorId = this.author.AuthorId;
    this.Name = this.author.Name;
    this.BookIds = this.author.BookIds;
  }



  addAuthor() {
    let ids = this.BookIds.split(",");
    console.log(ids);

    let val = {
      Name: this.Name,
      BookIds: ids

    };

    this.service.addAuthor(val).subscribe(res => {
      alert(res.toString());
    });



  }


  updateAuthor() {

    let ids = this.BookIds.split(",");

    let val = {
      Id: this.author.Id,
      Name: this.Name, BookIds: ids
    };
    this.service.updateAuthor(val).subscribe(
      (res) => {alert(res.toString())},
      (error) => {console.log(error.error)},
      () => (console.log("Finished"))
      );


  }

}
