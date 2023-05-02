import { Injectable } from '@angular/core';
import { CaseDTO } from 'src/app/Models/CaseDTO';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Charity } from '../../Models/CharityDTO';

@Injectable({
  providedIn: 'root'
})
export class DonatelogService {

  Cases: CaseDTO[] = []
  Charities: Charity[] = []
  caseelement: CaseDTO
  charityelement: Charity

  constructor() { }

  PushtoListCase(caseelement: CaseDTO) {
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
