import { Component, Input, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-narrow-category-page',
  templateUrl: './narrow-category-page.component.html',
  styleUrls: ['./narrow-category-page.component.css']
})
export class NarrowCategoryPageComponent implements OnInit {

  @Input()narrowCategories:any[] = []
  products:any[] = []

  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.categoryService.getAllNarrowCategories().subscribe(data=>{
      this.narrowCategories = data
    })
  }

}
