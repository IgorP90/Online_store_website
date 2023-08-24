import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-narrow-categories',
  templateUrl: './narrow-categories.component.html',
  styleUrls: ['./narrow-categories.component.css']
})
export class NarrowCategoriesComponent implements OnInit {

  @Input() narrowCategories:any[] = []

  constructor() { }

  ngOnInit(): void {
  }

}
