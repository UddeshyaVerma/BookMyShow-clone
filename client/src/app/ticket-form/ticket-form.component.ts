import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BookMyShowService } from '../services/book-my-show.service';

@Component({
  selector: 'app-ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.scss']
})
export class TicketFormComponent implements OnInit {

  constructor(public service : BookMyShowService,private router: Router) { }

  ngOnInit(): void {
  }

  async onSubmit(seatNo: string)
  {
    if(seatNo=="")
    {
      return alert("Invalid")
    }
    else {
      this.service.postTicket(seatNo).subscribe(
        res=> {
          alert("Booked Successfully")
        },
        err => {
          console.log(err);
        }
        )
        await this.service.getSingleTicket();
        this.router.navigateByUrl('/');
    }
    
    
  }
}
