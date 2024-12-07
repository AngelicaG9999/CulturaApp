import {Component, Input, OnInit, ViewChild} from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import {NavItem} from '../../models/nav-item';
import { MatIconModule } from '@angular/material/icon';
import { NgFor, NgIf } from '@angular/common';
import { MatMenuModule } from '@angular/material/menu';

@Component({
    selector: 'app-menu-item',
    templateUrl: './menu-item.component.html',
    styles: [],
    standalone: true,
    imports: [MatMenuModule, NgFor, NgIf, MatIconModule, RouterLink]
})
export class MenuItemComponent implements OnInit {
  @Input() items: NavItem[];
  @ViewChild('childMenu', {static: true}) public childMenu;

  constructor(public router: Router) { }

  ngOnInit() {
  }

}
