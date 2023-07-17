import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/interfaces/IProduct';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  constructor(private productService:ProductService) { }

  product:IProduct[]=[]

  ngOnInit(): void {
    this.productService.getProduct(1).subscribe(data=>{
      this.product= data
    })
  }

}
