import { HttpClient } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { IProduct } from "../interfaces/IProduct";
import { Observable } from "rxjs";


@Injectable({
    providedIn:'root'
})

export class ProductService{

     private readonly connectionString:string = 'https://localhost:44318/Home' // волшебная строка, перенести

    constructor(private http:HttpClient){}

    getAllProducts():Observable<IProduct[]>{
        return this.http.get<IProduct[]>(this.connectionString + '/product')
    }

    getAllProductsByDate():Observable<IProduct[]>{
        return this.http.get<IProduct[]>(this.connectionString + '/productByDate')
    }

    getAllProductsByRating():Observable<IProduct[]>{
        return this.http.get<IProduct[]>(this.connectionString + '/productByRating')
    }

    getProductById(id:number):Observable<IProduct[]>{
        return this.http.get<IProduct[]>(this.connectionString + '/productById/' + id)
    }

    getProductByName(name:string):Observable<IProduct[]>{
        return this.http.get<IProduct[]>(this.connectionString + '/productByName/' + name)
    }
}