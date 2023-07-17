import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/interfaces/IProduct';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  products:IProduct[] = [
  ]

  constructor(private productService:ProductService) { }

  ngOnInit(): void {
    this.productService.getAllProduct().subscribe(data=>{
      this.products = data
    })
  }


  
}
