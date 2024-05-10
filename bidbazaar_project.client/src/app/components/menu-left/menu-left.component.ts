import { Component } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-menu-left',
  templateUrl: './menu-left.component.html',
  styleUrl: './menu-left.component.css'
})
export class MenuLeftComponent {
  constructor(private router: Router) {
  }
  goToHome() {
    this.router.navigateByUrl('/');
  }
  goToChat(){
    this.router.navigateByUrl('/chat')
  }
  goToFavorite(){
    this.router.navigateByUrl('/favorite')
  }
  goToNotification(){
    this.router.navigateByUrl('/notification')
  }
}
