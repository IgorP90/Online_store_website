import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/interfaces/IProduct';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  constructor() { }

  @Input() product:IProduct = {
    name: '',
    description: '',
    price: 0,
    image: '',
    numberOfOrders: 0,
    rating: 0
  }

  ngOnInit(): void {
  }
     
}