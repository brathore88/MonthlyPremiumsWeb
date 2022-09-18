import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpEvent, HttpHeaders} from "@angular/common/http";
import { BaseService } from './base-service.service';
import { CalculatePremium } from './Premium.model';


@Injectable({
  providedIn: 'root'
})
export class PremiumService extends BaseService{

  constructor(protected override httpClient:HttpClient) {super(httpClient); }
  
  getDeathPremium(model:CalculatePremium):Observable<CalculatePremium> {
    console.log(model)
    return this.post<CalculatePremium>(model);
  }
}
