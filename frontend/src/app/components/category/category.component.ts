import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from 'src/interfaces/IProduct';
import { ICategory } from 'src/interfaces/ICategory';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})

export class CategoryComponent implements OnInit {

  constructor(private http:HttpClient) {}
  sss : ICategory = {}
  ngOnInit(): void { 
  }

          req:any = this.http.get<ICategory>('https://localhost:44381/Home/category').subscribe(data=>{
          this.sss.name = data.name
          this.sss.image = data.image
      })
  

}