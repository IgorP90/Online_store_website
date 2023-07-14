import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/interfaces/IProduct';
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})

export class AdminPageComponent implements OnInit {

  constructor( private http: HttpClient) { }

  private readonly connectionString:string = 'https://localhost:44318/Home' // волшебная строка, перенести

  ngOnInit(): void {
  } 

   product:IProduct= {
     name: "Cucumder",
     description: 'Green cucumber',
     price: 98.99
   }

  addProduct(product:IProduct){
    try {
      this.http.post(this.connectionString, product ).subscribe()
    } catch (error) {
      console.log(error)
    }
      
  }

  getProduct(){
    try {
      let fff = this.http.get<IProduct>(this.connectionString).subscribe(data => console.log(data))
    } catch (error) {
      console.log(error)
    }
    
  }
}


  


