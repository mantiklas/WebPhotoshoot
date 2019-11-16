import { Injectable } from '@angular/core';
import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) {
  }

  GetAll<T>(url: string): Observable<T> {
    //TODO Add Headers
    return this.http
      .get(environment.baseUrl + url)
      .pipe(map((response: any) => response))
      .pipe(catchError((err: any) => {
        throw new Object({ status: err.status, statusText: err.statusText, error: err.error });
      })
      ) as any;
  }
  Post<T>(param: any, url: string) : Observable<T> {
    //TODO Add Headers
    return this.http
      .post(environment.baseUrl + url, param )
      .pipe(map((response: any) => response))
      .pipe(catchError((err: any) => {
        throw new Object({ status: err.status, statusText: err.statusText, error: err.error });
      })
      ) as any;
  }

}
