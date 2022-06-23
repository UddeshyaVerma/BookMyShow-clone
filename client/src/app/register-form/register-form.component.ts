import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookMyShowService } from '../services/book-my-show.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss']
})
export class RegisterFormComponent implements OnInit {

  constructor(public service : BookMyShowService,private router : Router) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res:any) => {
        if(res.succeeded)
        {
          this.service.formModel.reset();
          alert("Registered Successfully")
          this.router.navigateByUrl('/LoginForm')
        }
        else {
          console.log(res.err)
        }
      },
      err =>{
        console.log(err);
      }

    )
  }
}
