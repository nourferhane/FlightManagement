import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Airplane } from 'src/Models/Airplane';



@Injectable({
  providedIn: 'root'
})
export class AirplaneService {
  private uri = 'https://localhost:44326/';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin':'*',
    })
  };
  constructor( private http: HttpClient) { }

  getAirplanes(): Observable<Airplane[]> {
    return this.http.get<Airplane[]>(this.uri+'airplanes')
      .pipe(
        catchError(this.handleError<Airplane[]>('getAiprlanes', []))
      );
      console.log(546468468468);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      return of(result as T);
    };
  }
}
