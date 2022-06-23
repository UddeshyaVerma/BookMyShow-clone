import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BookMyShowService } from '../services/book-my-show.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {

  constructor(private service : BookMyShowService,private router : Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') != null)
    {
      this.router.navigateByUrl("/");
    }
  }

  formModel= {
    UserName:'',
    Password:''
  }

  onSubmit(form : NgForm) {
    console.log(form.value);
    // console.log(form);
    this.service.login(form.value).subscribe(
      (res:any) => {
        localStorage.setItem("token",res.token);
        this.router.navigateByUrl("/");
       
      },
      err => {
        console.log(err.error)
        alert(err.error)
      }
    );
  }


}
