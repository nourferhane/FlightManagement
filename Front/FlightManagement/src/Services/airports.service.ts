import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Airport } from 'src/Models/Airport';

@Injectable({
  providedIn: 'root'
})
export class AirportsService {
  private apirul = 'https://localhost:44326/';
 
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin':'*',
    })
  };
  constructor(private http: HttpClient) { }

  getAirports(): Observable<Airport[]> {
    console.log(this.http.get<Airport[]>(this.apirul+"Airports", this.httpOptions));
    return this.http.get<Airport[]>(this.apirul+"Airports")
      .pipe(
        catchError(this.handleError<Airport[]>('getAirports', []))
      );
  }
 
  getByRef(ref : string) : Observable<Airport>{
    return this.http.get<Airport>(this.apirul+"Airport/"+ref)
    .pipe(
      catchError(this.handleError<Airport>('getAirports'))
    );
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      return of(result as T);
    };
  }

}

