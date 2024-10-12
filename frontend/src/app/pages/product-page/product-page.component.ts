import { Component, OnInit, Input } from '@angular/core';
import { NavigationComponent } from '../../components/navigation/navigation.component';
import { ActivatedRoute, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../services/product.service';
import { IProduct } from '../../interfaces/IProduct';
import { Console, log } from 'console';

@Component({
  selector: 'app-product-page',
  standalone: true,
  imports: [CommonModule, NavigationComponent],
  templateUrl: './product-page.component.html',
  styleUrl: './product-page.component.css'
})
export class ProductPageComponent implements OnInit {


  
  constructor(private productService: ProductService , private route:ActivatedRoute){}

  product:IProduct= {
    name:'',
    description:'',
    price: 0,
    image:'',
    numberOfOrders: 0,
    rating: 0
    }

  ngOnInit():void{
    this.productService.getProductById(this.route.snapshot.params['id']).subscribe(data=>{
      this.product = data
    })

    // console.log(this.product.id)
  }

}
