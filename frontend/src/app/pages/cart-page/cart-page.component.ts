import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/interfaces/IProduct';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart-page',
  templateUrl: './cart-page.component.html',
  styleUrls: ['./cart-page.component.css']
})
export class CartPageComponent implements OnInit {

  shoppingCarts:IProduct[] = []

  constructor(private cartService:CartService) { }

  ngOnInit(): void {
    this.cartService.getShoppingCart().subscribe(data=>{
      this.shoppingCarts = data  
    })
  }

}
