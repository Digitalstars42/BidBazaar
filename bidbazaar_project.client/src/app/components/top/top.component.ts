import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
@Component({
  selector: 'app-top',
  templateUrl: './top.component.html',
  styleUrls: ['./top.component.css'],
})
export class TopComponent {
  title = 'BidBazaar';
  constructor(private router: Router) {
  }
  goToHome() {
    this.router.navigateByUrl('/');
  }

  goToForm(){
    this.router.navigateByUrl('/form');
  }
}
