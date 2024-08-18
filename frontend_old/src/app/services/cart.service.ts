import { HttpClient } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { IProduct } from "../interfaces/IProduct";

@Injectable({
        providedIn:'root'
})

export class CartService{

    
    private readonly connectionString:string = 'https://localhost:44318/Home' // волшебная строка, перенести
    
    constructor(private http:HttpClient){}
    
    getShoppingCart():Observable<any[]>{
        return this.http.get<any[]>(this.connectionString + '/shopping_cart')
    }

    addInShoppingCart(id:number){
        return this.http.post(`${this.connectionString}/shopping_cart/id`, id)
    }


}