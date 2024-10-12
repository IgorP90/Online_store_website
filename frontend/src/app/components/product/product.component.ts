import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from '../../interfaces/IProduct';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {

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
