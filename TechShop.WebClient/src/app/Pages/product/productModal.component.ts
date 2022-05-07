import { Component, Inject, OnInit } from "@angular/core";
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {FormControl,  Validators} from '@angular/forms';
import { Category } from "src/app/core/Models/Category";
import { CategoryService } from "src/app/core/services/category.service";
import { ProductService } from "src/app/core/services/product.service";
import { Product, ProductCreate, ProductUpdate } from "../../core/Models/Product";

@Component({
    selector: 'dialog-overview-example-dialog',
    template: `
        <h1 mat-dialog-title>{{Name}}</h1>
        <div mat-dialog-content>

          <ng-container *ngIf="!data.isCreate">
            <mat-form-field style="width: 100%;" appearance="fill">
              <mat-label>Id</mat-label>
              <input readonly matInput [(ngModel)]="data.product.id">
            </mat-form-field>
          </ng-container>

          <mat-form-field style="width: 100%;" appearance="fill">
            <mat-label>Name</mat-label>
            <input matInput [(ngModel)]="data.product.name" [formControl]="NameFormControl">
            <mat-error *ngIf="NameFormControl.hasError('required')">
              Required
            </mat-error>
          </mat-form-field>

          <mat-form-field style="width: 100%;" appearance="fill">
            <mat-label>Value</mat-label>
            <input type="number" matInput [(ngModel)]="data.product.value" [formControl]="ValueFormControl">
            <mat-error *ngIf="ValueFormControl.hasError('required')">
              Required
            </mat-error>
            <mat-error *ngIf="ValueFormControl.hasError('min')">
              Min value is 0
            </mat-error>
          </mat-form-field>

          <mat-form-field appearance="fill">
            <mat-label>Select an option</mat-label>
            <mat-select [(ngModel)]="selectedCat" [compareWith]="compareFn" [formControl]="CategoryFormControl">
              <mat-option *ngFor="let category of categories" [value]="category">{{category.name}}</mat-option>
            </mat-select>
            <mat-error *ngIf="CategoryFormControl.hasError('required')">
              Category selection is required
            </mat-error>
          </mat-form-field>

        </div>

        <div mat-dialog-actions>
          <button mat-raised-button color="primary" (click)="onYesClick()" [mat-dialog-close]="data.product.name" cdkFocusInitial>Ok</button>
          <button mat-raised-button color="warn" (click)="onNoClick()">Cancel</button>
          <ng-container *ngIf="!data.isCreate"> 
            <button mat-raised-button color="warn" (click)="onDeleteClick(data.product.id)">Delete</button>
          </ng-container>
        </div>
    `,
    providers : [ProductService, CategoryService]
})
export class ProductModal implements OnInit {

    constructor(
      public dialogRef: MatDialogRef<ProductModal>,
      public productService : ProductService,
      public categoryService : CategoryService,
      @Inject(MAT_DIALOG_DATA) public data: { product : Product ,isCreate : boolean},
    ) {}

    ValueFormControl = new FormControl('', [Validators.required, Validators.min(0)]);
    NameFormControl = new FormControl('', [Validators.required]);
    CategoryFormControl = new FormControl('', [Validators.required]);

    Name = this.data.product.name;
    categories : Category[] = [];  
    _selectedCat = new Category();
    
    get selectedCat() : Category{
      return this._selectedCat;
    }
    set selectedCat(value : Category){
      this._selectedCat = value;
      this.data.product.category = value;
    }


    ngOnInit(): void {
      this.selectedCat = this.data.product.category;
      this.LoadCategories();
      console.log(this.selectedCat);
    }

    LoadCategories(){
      var response = this.categoryService.getAll();
      response.subscribe(x => 
      {
        this.categories = x.data;
      }); 
    }
    compareFn(obj1: any, obj2: any) {
      return obj1 && obj2 ? obj1.id === obj2.id : obj1 === obj2;
    }

    onYesClick(): void {
      
      let dialogres = false;
      if(this.data.isCreate){
        let product = new ProductCreate();
        product.name = this.data.product.name;
        product.value = this.data.product.value;
        product.categoryid = this.selectedCat.id;
        this.productService.create(product).subscribe(x => dialogres = x.data);
      }
      else{
        let product = new ProductUpdate();
        product.id = this.data.product.id;
        product.name = this.data.product.name;
        product.value = this.data.product.value;
        product.categoryid = this.selectedCat.id;
        this.productService.update(product).subscribe(x => dialogres = x.data);
      }
      this.dialogRef.close(dialogres);
    }

    onDeleteClick(id : number){
      let dialogres = false;
      console.log(id);
      this.productService.delete(id).subscribe(x => dialogres = x.data);
      this.dialogRef.close(dialogres);
    }

    onNoClick(): void {
      this.dialogRef.close();
    }
}