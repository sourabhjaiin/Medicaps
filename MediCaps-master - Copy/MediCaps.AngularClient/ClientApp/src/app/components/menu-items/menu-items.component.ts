import { Component, OnDestroy, OnInit } from '@angular/core';
import { MenuItemsService } from '../../services/menu-items.service';
import { Subscription } from 'rxjs';
@Component({
    selector: 'app-menu-items',
    templateUrl: './menu-items.component.html',
    styleUrls: ['./menu-items.component.css']
})
/** menuItems component*/
export class MenuItemsComponent implements OnInit, OnDestroy {
/** menuItems ctor */
  menuItems: any;
  menuitemsServices_Subscription: Subscription;
  constructor(private menuItemsService: MenuItemsService) {

  }
  ngOnInit() {
    this.menuItemsService.getAllMenuItems().subscribe(data => this.menuItems = data, error => alert('Error'));
  }
  ngOnDestroy() {
    this.menuitemsServices_Subscription.unsubscribe();
  }
}
