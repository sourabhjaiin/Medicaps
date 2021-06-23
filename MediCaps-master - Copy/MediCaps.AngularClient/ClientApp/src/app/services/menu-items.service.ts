import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
@Injectable()
export class MenuItemsService {
  url = 'http://localhost:59186/api/menuitems';
  constructor(private http: HttpClient) {

  }
  getAllMenuItems() {
    return this.http.get(this.url);
  }
  handleErrors(error: HttpErrorResponse) {
  }
}
