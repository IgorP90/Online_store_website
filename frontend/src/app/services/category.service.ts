import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

 
 @Injectable({
    providedIn:'root'
})

export class CategoryService {

    private readonly connectionString:string = 'https://localhost:44318/Home' // волшебная строка, перенести
    private readonly connectionString2:string = 'https://localhost:44318' // волшебная строка, перенести
    constructor(private http:HttpClient){}

    getAllNarrowCategories():Observable<any[]>{
        return this.http.get<any[]>(this.connectionString + '/narrow_category')
    }

    getAllWideCategories():Observable<any[]>{
        return this.http.get<any[]>(this.connectionString + '/wide_category')
    }

    getProductsByNarrowCategoryName(categoryName:string):Observable<any[]>{
        return this.http.get<any[]>(this.connectionString + '/productsByNarrowCategory/' + categoryName)
    }

    getProductsByWideCategoryName(categoryName:string):Observable<any[]>{
        return this.http.get<any[]>(`${this.connectionString}/productsByWideCategory/${categoryName}`)
    }

    getProductsByCategoryName(categoryName:string):Observable<any[]>{
        return this.http.get<any[]>(this.connectionString + '/productsByNarrowCategory/' + categoryName) //-
    }
}
