import { HttpClient } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { IProduct } from "../interfaces/IProduct";


@Injectable({
    providedIn:'root'
})

export class ProductService{

    constructor(http:HttpClient){}

    getAllProduct(){
        // this.http.get<IProduct>()
    }
}