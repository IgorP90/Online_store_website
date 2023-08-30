import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/interfaces/IProduct';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-narrow-category-page',
  templateUrl: './narrow-category-page.component.html',
  styleUrls: ['./narrow-category-page.component.css']
})
export class NarrowCategoryPageComponent implements OnInit {

  narrowCategories:any[] = []
  products:IProduct[] = []

  constructor(private categoryService:CategoryService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.categoryService.getProductsByNarrowCategoryName(this.route.snapshot.params['name']).subscribe(data=>{
      console.log(this.route.snapshot.params['name'])
      this.products = data[0].products
    })

    this.categoryService.getAllNarrowCategories().subscribe(data=>{
      this.narrowCategories = data
    })
  }

}
