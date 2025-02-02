import { Component, Input, NgModule, OnInit } from '@angular/core';
import { NavigationComponent } from '../../components/navigation/navigation.component';
import { IProduct } from '../../interfaces/IProduct';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-admin-page',
  standalone: true,
  imports: [ 
    NavigationComponent,
    FormsModule,
    CommonModule,
    FormsModule
  ],
  templateUrl: './admin-page.component.html',
  styleUrl: './admin-page.component.css'
})
export class AdminPageComponent implements OnInit {

  constructor(private  productService:ProductService, private categoryService:CategoryService) { }

  @Input() product:IProduct = {
    name: '',
    description: '',
    price: 0,
    image: '',
    numberOfOrders: 0,
    rating: 0
  }

  narrowCategories:any[] = []

  ngOnInit(): void { 
    this.categoryService.getAllNarrowCategories().subscribe(data=>{
      this.narrowCategories = data
    })
  }

  sendProduct(form:NgForm):void{
    this.productService.postProduct(this.product)
    console.log(form);
}
}
