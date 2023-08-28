import { HttpClient } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
// import { IWideCategory } from "../interfaces/IWideCategory";

import { Observable } from "rxjs";


@Injectable({
    providedIn:'root'
})

export class CategoryService{

     private readonly connectionString:string = 'https://localhost:44318/Home' // волшебная строка, перенести

    constructor(private http:HttpClient){}

    getAllWideCategories():Observable<any[]>{
        return this.http.get<any[]>(this.connectionString + '/wide_category')
    }

    getAllNarrowCategories():Observable<any[]>{
        return this.http.get<any[]>(this.connectionString + '/narrow_category')
    }

    getProductsByNarrowCategoryName(name:string):Observable<any[]>{
        return this.http.get<any[]>(this.connectionString + '/narrow_category/' + name)
    }
}