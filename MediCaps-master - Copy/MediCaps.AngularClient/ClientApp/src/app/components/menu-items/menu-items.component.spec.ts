/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MenuItemsComponent } from './menu-items.component';

let component: MenuItemsComponent;
let fixture: ComponentFixture<MenuItemsComponent>;

describe('menuItems component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MenuItemsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MenuItemsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});