import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-show-delete-author',
  templateUrl: './show-delete-author.component.html',
  styleUrls: ['./show-delete-author.component.css']
})
export class ShowDeleteAuthorComponent implements OnInit {

  constructor(private service:SharedService) { }

  

  AuthorList:Array<any>=[];

  ModalTitle:string = "";
  ActivateAddEditAuthorComp:boolean=false;
  author:any;


  ngOnInit(): void {

    this.refreshAuthorList();
  }

  addClick(){
    this.author={
      AuthorId:0,
      Name:"",
      BookIds:[]  ,
    }
    this.ModalTitle="Add Author";
    this.ActivateAddEditAuthorComp=true;

  }

  closeClick(){
    this.ActivateAddEditAuthorComp=false;
    this.refreshAuthorList();
  }


  updateClick(item : any){
    console.log(item);
    this.author=item;
    this.ModalTitle="Edit Author";
    this.ActivateAddEditAuthorComp=true;
  }

  deleteClick(item : any){
    if(confirm('Are you sure??')){
      this.service.deleteAuthor(item.Id).subscribe(data=>{
        // alert(data.toString());
        this.refreshAuthorList();
      })
    }
  }







  refreshAuthorList() {
    this.service.getAuthorsList().subscribe(data=>{
      this.AuthorList=data;
  });

}

}
