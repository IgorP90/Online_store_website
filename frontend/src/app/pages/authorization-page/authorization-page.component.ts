import { Component } from '@angular/core';
import { AuthorizationService } from '../../services/authorization.service';

@Component({
  selector: 'app-authorization-page',
  standalone: true,
  imports: [],
  templateUrl: './authorization-page.component.html',
  styleUrl: './authorization-page.component.css'
})
export class AuthorizationPageComponent {

  constructor(private authorizationService: AuthorizationService){}

  login(email: string, password: string){

    console.log(this.authorizationService.login(email, password))
  }
}
