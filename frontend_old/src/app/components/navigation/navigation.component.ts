import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/interfaces/IProduct';
import { ProductService } from 'src/app/services/product.service';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
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




