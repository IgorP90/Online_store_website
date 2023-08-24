import { Component, HostBinding, OnInit } from '@angular/core';
import { IProduct } from 'src/app/interfaces/IProduct';
import { ProductService } from 'src/app/services/product.service';
import { CategoryService } from 'src/app/services/category.service';
import {trigger, state, style, transition, animate} from '@angular/animations'

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
  animations:[
    trigger('general_category', [
      state('left', style({transform:'translate(-300px, 0)'})),
      state('right',style({transform:'translate(0px, 0)'})),
      transition('*<=>*', animate('200ms')),
    ])
  ]
})
export class HomePageComponent implements OnInit {

  products:IProduct[] = []
  productsByDateTime:IProduct[] = []
  productsByRating:IProduct[] = []
  
  wideCategories:any[] = [] 
  narrowCategories:any[] = []  

  constructor(private productService:ProductService, private categoryService:CategoryService) { }

  ngOnInit(): void {

    this.productService.getAllProducts().subscribe(data=>{
      this.products = data
    })

    this.productService.getAllProductsByDate().subscribe(data=>{
      this.productsByDateTime = data
    })

    this.productService.getAllProductsByRating().subscribe(data=>{
      this.productsByRating = data
    })

    this.categoryService.getAllWideCategories().subscribe(data=>{
      this.wideCategories = data
    })

    this.categoryService.getAllNarrowCategories().subscribe(data=>{
      this.narrowCategories = data
    })
  }

  event:string = ''
  
}
