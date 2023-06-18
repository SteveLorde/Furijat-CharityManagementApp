import { Injectable } from '@angular/core';
import { Case } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Charity } from '../../Models/Charity';

@Injectable({
  providedIn: 'root'
})
export class DonatelogService {

  Cases: Case[] = []
  Charities: Charity[] = []
  caseelement: Case
  charityelement: Charity

  constructor() { }

  PushtoListCase(caseelement: Case) {
    this.Cases.push(caseelement)
    console.log("pushed case to array" + " " + caseelement.firstName + " " + caseelement.lastName)
    console.log(this.Charities)
  }

  PushtoListCharity(charityelement: Charity) {
    this.Charities.push(charityelement)
    console.log("pushed charity to array" + " " + charityelement.name)
    console.log(this.Charities)
  }

  ReturnDonatedCharities() {
    return this.Charities
  }

  ReturnDonatedCases() {
    return this.Cases
  }

}
