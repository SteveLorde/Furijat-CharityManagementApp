import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.css']
})
export class SearchbarComponent implements OnInit {

  searchitem: any;

  constructor() { }

  ngOnInit(): void {
  }

  Search(ItemName: string) {
    console.log("found your item called" + ItemName)
  }

}
