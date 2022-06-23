import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

import { BookingComponent } from './booking/booking.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { MovieDashboardComponent } from './movie-dashboard/movie-dashboard.component';
import { MoviesListComponent } from './movies-list/movies-list.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { TicketFormComponent } from './ticket-form/ticket-form.component';
import { TicketComponent } from './ticket/ticket.component';

const routes: Routes = [

  {path:"Dashboard",component:MovieDashboardComponent},
  {path:"",component:MoviesListComponent},
  {path:"Book",component:BookingComponent},
  {path:"Ticket",component:TicketFormComponent,canActivate:[AuthGuard]},
  {path:"TicketView",component:TicketComponent},
  {path:"RegisterForm",component:RegisterFormComponent},
  {path:"LoginForm",component:LoginFormComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
