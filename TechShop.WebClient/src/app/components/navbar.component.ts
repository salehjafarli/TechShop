import { Component, NgModule } from "@angular/core";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BrowserModule } from '@angular/platform-browser';
import { faBox ,faList } from '@fortawesome/free-solid-svg-icons';
import { RouterModule } from "@angular/router";

@Component({
  selector: 'app-navbar',
  template: `
  <div style="height: 60px; background-color : blue;" class="navbar">
      <div class="card-container">
          <a class="card" rel="noopener" routerLink="/products"  >
            <fa-icon [icon]="boxicon"></fa-icon>
            <span>Products</span>
            <svg class="material-icons" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z"/></svg>    </a>
          <a class="card" rel="noopener" routerLink="/categories"  >
            <fa-icon [icon]="listicon"></fa-icon>
            <span>Categories</span>
            <svg class="material-icons" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z"/></svg>
          </a>
        </div>  
  </div>
  `,
  styleUrls : ['./navbar.component.scss']
})
export class NavbarComponent {
  boxicon = faBox;
  listicon = faList;
  title = 'TechShop';
}

@NgModule({
  declarations: [
      NavbarComponent
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    RouterModule
  ],
  exports : [NavbarComponent]
})
export class NavbarModule{}