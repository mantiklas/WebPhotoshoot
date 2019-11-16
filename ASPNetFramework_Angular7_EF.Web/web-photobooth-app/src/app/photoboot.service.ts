import { Injectable } from '@angular/core';
import { ApiService } from './services/ApiServices';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PhotobootService {

  constructor(public http: ApiService) { }
  send(emaiDto : any): Observable<object> {
    return this.http.Post(emaiDto, '/item/sendemail')
    
  } 
}
