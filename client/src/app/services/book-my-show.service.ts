import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { MovieModel } from './MovieModel';
import { FormBuilder } from '@angular/forms';
import { TicketModel } from './TicketModel';



@Injectable({
  providedIn: 'root'
})
export class BookMyShowService {

  constructor(private http: HttpClient,private fb:FormBuilder) { }

    readonly baseURL ="https://localhost:7001/";
    list : MovieModel[];
    movie : MovieModel;
    hallName:string;
    ticket:TicketModel;
    
    //formData:TicketModel;

    ToggleNavbar() {
      if(localStorage.getItem('token') != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    formModel = this.fb.group({
      UserName:[''],
      FullName:[''],
      Email:[''],
      Phone : [''],
      City : [''],
      
        Password : [''],
       
     
     
    })
    refreshList()
    {
      this.http.get(this.baseURL+'movies')
      .toPromise()
      .then (res=> this.list = res as MovieModel[]);

    }

    getSingleList(id:number)
    {
      this.http.get(this.baseURL+'movie/'+id)
      .toPromise()
      .then (res=> this.movie = res as MovieModel);

    }

    getSingleTicket()
    {
      
      this.http.get(this.baseURL+'getTicket/'+this.movie.id)
      .toPromise()
      .then (res=> this.ticket = res as TicketModel);
    }

    postTicket(seatNo:string)
    {

      //  console.log(typeof(seatNo));
      //  console.log(seatNo);
      const endpoint = 'https://localhost:7001/bookTickets';
      // const formData : FormData = new FormData();
      // formData.append('movieTitle',this.movie.title);
      
      // formData.append('seatNo',seatNo);
      // formData.append('hallName','GOREGAON')
      // console.log(formData);
      return this.http.post(endpoint,{
        
          "id": 0,
          "movieTitle": this.movie.title,
          "seatNo": seatNo,
          "hallName": this.hallName
        
      });
    }

    register() {
      var body = {
        UserName : this.formModel.value.UserName,
        FullName : this.formModel.value.FullName,
        Email : this.formModel.value.Email,
        Phone : this.formModel.value.Phone,
        City : this.formModel.value.City,
        Password: this.formModel.value.Password

      }

      return this.http.post(this.baseURL+'api/App/Register',body);
    }


    login(obj : any) {
      return this.http.post(this.baseURL+'api/App/Login',obj)
    }

}
