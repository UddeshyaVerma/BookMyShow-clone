import { Component, OnInit } from '@angular/core';
import { BookMyShowService } from '../services/book-my-show.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-dashboard',
  templateUrl: './movie-dashboard.component.html',
  styleUrls: ['./movie-dashboard.component.scss']
})
export class MovieDashboardComponent implements OnInit {

  constructor(public service :  BookMyShowService,private router: Router) { }
  
  ngOnInit(): void {
    // console.log(this.service.movie.cast);
    // cothis.service?.movie?.cast?.split(",");
  }
  // console.log(this.service?.movie?.cast);
  //  split =this.castlist.split(',');
  // cast = this.service.movie.cast.splitt
  
  EventHandler() {
    this.router.navigateByUrl('/Book');
  }

}
