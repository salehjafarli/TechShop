import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductComponent } from './Pages/product/product.component';
import { CategoryComponent } from './Pages/category/category.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NavbarModule } from 'src/app/components/navbar.component';
import {MatTableModule} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatInputModule} from '@angular/material/input';
import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { CategoryModal } from './Pages/category/categoryModal.component';
import { ProductModal } from './Pages/product/productModal.component';
import { HttpClientModule } from '@angular/common/http';
import { ApiService } from './core/services/api.service';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    CategoryModal,
    ProductModal,
    CategoryComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule, 
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatCheckboxModule,
    NavbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    FormsModule,
    MatButtonModule,
    FontAwesomeModule
  ],
  providers: [
    ApiService,
    
  ],  
  bootstrap: [AppComponent]
})
export class AppModule { }
