import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html',
  styleUrl: './top.component.css'
})
export class TopComponent implements OnInit{
  title = 'BidBazaar';
  constructor() {
  }

  ngOnInit() {
  }
}
