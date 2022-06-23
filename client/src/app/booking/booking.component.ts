import { Component, OnInit } from '@angular/core';
import { BookMyShowService } from '../services/book-my-show.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent implements OnInit {

  constructor(public service :  BookMyShowService,private router: Router) { }


  ngOnInit(): void {
  }

  EventHandler(hallName : string)

  {
    this.service.hallName=hallName;
    
    this.router.navigateByUrl('/Ticket');
  }

}
