import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/interfaces/IProduct';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  private readonly connectionString:string = 'https://localhost:44318/Home' // волшебная строка, перенести

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }


  product:any

  gg = this.http.get<IProduct>(this.connectionString).subscribe(data=> this.product = data)
      
}