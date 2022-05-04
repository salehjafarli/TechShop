import { Component } from '@angular/core';
import { faBox } from '@fortawesome/free-solid-svg-icons';
import { faList } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-root',
  template: `
    <app-navbar></app-navbar>
    <div class="content" role="main">
      <router-outlet></router-outlet>
    </div>
  `,
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  boxicon = faBox;
  listicon = faList;
  title = 'TechShop';
}
