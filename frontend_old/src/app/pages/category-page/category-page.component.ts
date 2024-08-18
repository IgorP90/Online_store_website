import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/interfaces/IProduct';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-page',
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.css']
})
export class CategoryPageComponent implements OnInit {

  narrowCategories:any[] = []
  products:IProduct[] = []

  constructor(private categoryService:CategoryService, private route:ActivatedRoute) { }

  ngOnInit(): void {
      this.categoryService.getProductsByNarrowCategoryName(this.route.snapshot.params['name']).subscribe(data=>{
      this.products = data
      })

      // this.categoryService.getProductsByWideCategoryName(this.route.snapshot.params['name']).subscribe(data=>{
      // this.products = data
      // })
    
    this.categoryService.getAllNarrowCategories().subscribe(data=>{
      this.narrowCategories = data
    })
  }

}
