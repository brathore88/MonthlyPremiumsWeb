import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpEvent, HttpHeaders, HttpParams} from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor(protected httpClient:HttpClient) { }
  getDeathPremium(params:HttpParams){
  const headerOptions = new HttpHeaders();
   
     headerOptions.set('Content-Type', 'application/json');
     return this.httpClient.get('http://localhost:13846/api/Premium/GetPremium', { params: params ,
    headers: headerOptions});
    }
}
