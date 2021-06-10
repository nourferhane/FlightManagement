import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightFullDetailsComponent } from './flight-full-details/flight-full-details.component';
import { FlightComponent } from './flight/flight.component';

const routes: Routes = [
  { path: 'fulldetails/:reference', component: FlightFullDetailsComponent },
  { path: '', component: FlightComponent }

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
