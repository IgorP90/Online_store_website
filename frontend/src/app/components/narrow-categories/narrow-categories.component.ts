import { Component, Input, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-narrow-categories',
  templateUrl: './narrow-categories.component.html',
  styleUrls: ['./narrow-categories.component.css']
})
export class NarrowCategoriesComponent implements OnInit {

  narrowCategories:any[] = []

  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.categoryService.getAllNarrowCategories().subscribe(data=>{
      this.narrowCategories = data
    })
  }

}
