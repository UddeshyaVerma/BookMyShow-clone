import { Component, OnInit } from '@angular/core';
import { BookMyShowService } from '../services/book-my-show.service';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent implements OnInit {

  constructor(public service :  BookMyShowService) { }

  ngOnInit(): void {
  }

}
