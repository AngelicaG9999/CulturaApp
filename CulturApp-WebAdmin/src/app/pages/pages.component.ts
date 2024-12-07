import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from '../shared/header/header.component';

@Component({
    selector: 'app-pages',
    templateUrl: './pages.component.html',
    styles: [],
    standalone: true,
    imports: [HeaderComponent, RouterOutlet]
})
export class PagesComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
