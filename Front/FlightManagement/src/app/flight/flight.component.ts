import { Component, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Airplane } from 'src/Models/Airplane';
import { Airport } from 'src/Models/Airport';
import { Datas } from 'src/Models/Datas';
import { Flight, FlightToAdd } from 'src/Models/Flight';
import { AirplaneService } from 'src/Services/airplane.service';
import { AirportsService } from 'src/Services/airports.service';
import { FlightService } from 'src/Services/flight.service';


@Component({
    selector: 'flight',
    templateUrl: './flight.component.html'
})
export class FlightComponent {
    public flights: Flight[];
    public flightNew: Flight;
    public flightToAdd: FlightToAdd;
    private datas : Datas;
    constructor(private airplaneService: AirplaneService,private airportsService: AirportsService, private flightService: FlightService) {
      this.flightToAdd = this.getDefaultFlight();
      this.getFlights();
    }
    
    private getDefaultFlight(): Flight {
      let flightNew: Flight = {
          reference: '',
          departureAirportCode: '',
          arrivalAirportCode: '',
          distance:0,
          estimatedFuel:0,
          AirplaneCode :''
      };
      return flightNew;
  }


    public getFlights() {
      return  this.flightService.getFlights()
    .subscribe(flights => (this.flights = flights));
    }

    public save(): void {
      this.flightService.AddFlight(this.flightToAdd);
    
  }
}

