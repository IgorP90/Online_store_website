import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { IUser } from "../interfaces/IUser"
import { Observable } from "rxjs";
import { log } from "console";

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  private readonly connectionString:string = 'https://localhost:44356/Auth' // волшебная строка, перенести
  constructor(private http:HttpClient) { }

  login(email: string, passwors: string):Observable<IUser>{
    return this.http.get<IUser>(this.connectionString + '/getuser/1')

}

  logout():void{

  }
}
