import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/interfaces/IProduct';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  constructor(private productService:ProductService, private cartService:CartService, private route:ActivatedRoute) { }

  product:IProduct= {
  name:'',
  description:'',
  price: 0,
  image:'',
  numberOfOrders: 0,
  rating: 0
  }

  ngOnInit(): void {
    this.productService.getProductById(this.route.snapshot.params['id']).subscribe(data=>{
      this.product = data
    })
  }

  addInShoppingCart(id:number){
    this.cartService.addInShoppingCart(id).subscribe()
  }
}
