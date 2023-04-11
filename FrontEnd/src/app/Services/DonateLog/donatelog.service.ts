import { Injectable } from '@angular/core';
import { Case } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class DonatelogService {

  DonatedCases: Case[] = []
  caseelement: Case

  constructor() { }

  PushtoList(caseelement: Case) {
    this.DonatedCases.push(caseelement)
}

}
