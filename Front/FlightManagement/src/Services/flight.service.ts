import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Flight, FlightToAdd, Fullflight } from 'src/Models/Flight';

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  private uri = 'https://localhost:44326/';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin':'*',
    })
  };
  constructor(private http: HttpClient) { }

  
  getFlights(): Observable<Flight[]> {
    return this.http.get<Flight[]>(this.uri+'flights')
      .pipe(
        catchError(this.handleError<Flight[]>('getFlights', []))
      );
  }

  getFlight(ref: string): Observable<Fullflight> {
    return this.http.get<Fullflight>(this.uri+'flight/'+ref)
      .pipe(
        catchError(this.handleError<Fullflight>('getFlights'))
      );
  }


  AddFlight(flight :FlightToAdd): Observable<FlightToAdd> {
    return this.http.post<FlightToAdd>(this.uri, flight, this.httpOptions).pipe(
      tap((Flight: FlightToAdd) => console.log(`added flight w/ id=${Flight.reference}`)),
      catchError(this.handleError<FlightToAdd>('addflight'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      return of(result as T);
    };
  }
}

