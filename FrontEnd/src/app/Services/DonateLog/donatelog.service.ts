import { Injectable } from '@angular/core';
import { CaseDTO } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Charity } from '../../Models/Charity';

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
  }

  PushtoListCharity(charityelement: Charity) {
    this.Charities.push(charityelement)
    console.log("pushed charity to array" + " " + charityelement.name)
    console.log(this.Charities)
  }

  ReturnDonatedCharities() {
    return this.Charities
  }

}