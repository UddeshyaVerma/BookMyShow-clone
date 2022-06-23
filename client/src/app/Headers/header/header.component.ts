import { Token } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookMyShowService } from 'src/app/services/book-my-show.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

 
  constructor(private router : Router,public service : BookMyShowService) { }

  ngOnInit(): void {
    
  }

  onLogOut() {
    localStorage.removeItem('token');
    this.router.navigateByUrl('/')
    // this.service.ToggleNavbar
  }

 
}
