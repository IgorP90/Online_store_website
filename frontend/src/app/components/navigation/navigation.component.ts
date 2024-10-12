import { Component, Injectable, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { IProduct } from '../../interfaces/IProduct';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.css'
})

export class NavigationComponent implements OnInit {

  products:IProduct[] = []
  search_input:string = ''
  constructor(private  productService:ProductService) { }

  ngOnInit(): void { 
  }
  
  fff(value:string){
    console.log(value)
    this.productService.getProductByName(value).subscribe(data=>{
      this.products = data
    })
  }
  
}
