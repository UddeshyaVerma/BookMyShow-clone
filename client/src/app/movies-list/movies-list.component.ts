import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookMyShowService } from '../services/book-my-show.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.scss']
})
export class MoviesListComponent implements OnInit {

  constructor(public service : BookMyShowService,private router: Router ) { }

  //imagesrc=["../../assets/image1.avif","../../assets/image3.avif","../../assets/image4.avif","../../assets/image5.avif","../../assets/image6.avif"]
  ngOnInit(): void {

    this.service.refreshList();
  }
  
  movieHandler = (id:number) => {
    this.service.getSingleList(id);
    //console.log(this.service.movie);
    this.router.navigateByUrl('/Dashboard');


  }

}
