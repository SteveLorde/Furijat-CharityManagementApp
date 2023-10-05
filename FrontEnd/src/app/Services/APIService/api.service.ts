import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from "../../../environments/environment";
import {Case} from "../../Data/Models/Case";
import {News} from "../../Data/Models/News";

@Injectable({
  providedIn: 'root'
})
export class APIService {

  serverUrl = environment.baseUrl;

  constructor(private http : HttpClient) { }


  //Backend call methods


  //News
  //----------
  //1-GET News
  GetNews() {
    return this.http.get<News>(this.serverUrl + 'api/GetNews');
  }

  //2-SET News
  SetNews(news : News) {
    return this.http.post<News>(this.serverUrl + 'api/AddNews', news);
  }
  //----------


  //Charities
  //----------

  //1-GET Charities

  //2-Add New Charity

  //3-Update Charity

  //4-Delete Charity

  //------------

  //Cases
  //-------------

  //1-GET Cases
  GetCases() {
    return this.http.get<Case>(this.serverUrl + 'api/Cases');
  }

  //GET Case by id
  getCasesById(id: number){
    return this.http.get<Case>(this.serverUrl + `api/Cases/GetCase/${id}`);
  }

  //2-Add New Case

  //3-Update Case

  //4-Delete Case

  //-----------

  //Donators
  //-------------

  //1-GET Donators

  //2-Add New Donator

  //3-Update Donator

  //4-Delete Donator

  //-----------




}
