import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Airplane } from 'src/Models/Airplane';
import { Airport } from 'src/Models/Airport';
import { Flight } from 'src/Models/Flight';
import { AirplaneService } from 'src/Services/airplane.service';
import { AirportsService } from 'src/Services/airports.service';
import { FlightService } from 'src/Services/flight.service';

@Component({
  selector: 'app-flight-detail',
  templateUrl: './flight-detail.component.html',
  styleUrls: ['./flight-detail.component.css']
})

export class FlightDetailComponent implements OnInit {
  @Input('flight') flight : Flight;
  departAirpot : Airport;
  destinationAirport : Airport;
  airports : Airport[];
  airplanes : Airplane[];
  isValide = true;

  constructor(private airplaneService: AirplaneService,private flightService: FlightService, private route:ActivatedRoute, private airpotService: AirportsService, private airportsService: AirportsService) {

    this.getAirports();
    this.getAirplanes();
    //console.log(this.flight.departureAirportCode);
    //this.departAirpot = this.getAirportByRef(this.flight.departureAirportCode);
   // this.destinationAirport = this.getAirportByRef(this.flight.arrivalAirportCode);
   }

  ngOnInit(): void {


  }
  DepartChange(event) {
    console.log(event);
    this.flight.departureAirportCode = event;
}

DestinationChange(event) {
  console.log(event + "--" + this.flight.departureAirportCode);
 if(this.flight.departureAirportCode == event)
 {
  alert('depart airport cannot be the same as destination !');
  this.isValide = false;
 }
 else{
  this.isValide = true
 }

}
  getFlight(): void{
    const ref = +this.route.snapshot.paramMap.get('reference');
    this.flightService.getFlight(ref.toString())
    .subscribe(flight => this.flight = flight);
  }

  public getAirports() {
     this.airportsService.getAirports()
  .subscribe(airports => (this.airports = airports));
  }

  getAirportByRef(ref : string) : Airport{
    let airport : Airport;
    this.airpotService.getByRef(ref.toString()) .subscribe(airport => airport = airport);
    return airport;
  }

  getAirplanes(){
    this.airplaneService.getAirplanes()
    .subscribe(airplanes => (this.airplanes = airplanes));
  }

  delete(){
  console.log(this.flight.reference);
  this.flightService.RemoveFlight(this.flight.reference);
  this.getFlight();
  }
}
