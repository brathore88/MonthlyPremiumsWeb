import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpEvent, HttpHeaders} from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class BaseServiceService {

  constructor(protected httpClient:HttpClient) { }
  

  protected post<T>(body:any,uri?:string):Observable<T>{
    const json = JSON.stringify(body)

    const requestOptions = BaseServiceService.getRequestOptions();

    const path = 'this.getPath(uri)';

    return this.httpClient.post<T>(path, json, requestOptions)
  }
  
  private static getRequestOptions():{headers:HttpHeaders} {
    const headerDict = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
    }
    return {
      headers: new HttpHeaders(headerDict),
    };
  }
}
