import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Observable } from 'rxjs';
import { Owner } from '../_interface/owner.model';
import { catchError, tap, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient) { }

  public getData = (route: string): Observable<Owner> => {
    return this.http.get<Owner>(this.createCompleteRoute(route, environment.urlAddress))
    .pipe(
      tap(res => console.log("fetched owners"))
      );
  }

  public create = (route: string, body): Observable<Owner> => {
    return this.http.post<Owner>(this.createCompleteRoute(route, environment.urlAddress), body, this.generateHeaders())
    .pipe(
      tap(res => console.log("Created owner"))
      );;
  }

  public update = (route: string, body): Observable<Owner> => {
    return this.http.put<Owner>(this.createCompleteRoute(route, environment.urlAddress), body, this.generateHeaders())
    .pipe(
      tap(res => console.log("updated owner"))
      );;
  }

  public delete = (route: string, body):Observable<Owner> => {
    return this.http.delete<Owner>(this.createCompleteRoute(route, environment.urlAddress))
    .pipe(
      tap(res => console.log("deleted owner"))
      );;
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({'Content-Type':'application/json'})
    }
  }

}
