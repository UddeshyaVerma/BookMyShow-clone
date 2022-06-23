import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {ReactiveFormsModule} from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HeaderComponent } from './Headers/header/header.component';
import { CarouselComponent } from './carousel/carousel.component';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { MoviesListComponent } from './movies-list/movies-list.component';
import { CategoryComponent } from './category/category.component';
import { FooterComponent } from './footer/footer.component'
import { HttpClientModule } from '@angular/common/http';

import { MovieDashboardComponent } from './movie-dashboard/movie-dashboard.component';
import { BookingComponent } from './booking/booking.component';
import { TicketFormComponent } from './ticket-form/ticket-form.component';
import { TicketComponent } from './ticket/ticket.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { BookMyShowService } from './services/book-my-show.service';
import { LoginFormComponent } from './login-form/login-form.component';

@NgModule({
  declarations: [
    AppComponent,
    
    HeaderComponent,
         CarouselComponent,
         MoviesListComponent,
         CategoryComponent,
         FooterComponent,
         
         MovieDashboardComponent,
         BookingComponent,
         TicketFormComponent,
         TicketComponent,
         RegisterFormComponent,
         LoginFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [BookMyShowService],
  bootstrap: [AppComponent]
})
export class AppModule { }
