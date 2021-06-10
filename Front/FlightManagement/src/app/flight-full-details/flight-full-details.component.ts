import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Airport } from 'src/Models/Airport';
import { Flight, Fullflight } from 'src/Models/Flight';
import { AirportsService } from 'src/Services/airports.service';
import { FlightService } from 'src/Services/flight.service';

@Component({
  selector: 'app-flight-full-details',
  templateUrl: './flight-full-details.component.html',
  styleUrls: ['./flight-full-details.component.css']
})
export class FlightFullDetailsComponent implements OnInit {
  public flight: Fullflight;
  departAirpot : Airport;
  destinationAirport : Airport;
  constructor(private route:ActivatedRoute, private flightService: FlightService, private airpotService: AirportsService) {
   
   }

  ngOnInit(): void {
    this.getFullFlight();

    console.log(this.departAirpot.code);

  }

  getFullFlight(): void{
    const ref = this.route.snapshot.params['reference'];
    this.flightService.getFlight(ref.toString() )
    .subscribe(flight => this.flight = flight);
  }

  getAirportByRef(ref : string) : Airport{
    let airport : Airport;
    this.airpotService.getByRef(ref.toString()) .subscribe(airport => airport = airport);
    return airport;
  }
}
