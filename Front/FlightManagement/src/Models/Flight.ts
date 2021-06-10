export  interface Flight {
    reference: string;
    departureAirportCode: string;
    arrivalAirportCode: string;
    distance: number;
    estimatedFuel: number;
    AirplaneCode : string;
}

export  interface FlightToAdd  {
    reference: string;
    departureAirportCode: string;
    arrivalAirportCode: string;
    AirplaneCode : string;
}


export  interface Fullflight  {
    reference: string;
    airportDepart: string;
    airportDestination: string;
    distance : number;
    arrivalTime : string,
    departureTime : string,
    departureAirportCode: string;
    arrivalAirportCode: string;
    estimatedFuel: number;
    AirplaneCode : string;
    
}