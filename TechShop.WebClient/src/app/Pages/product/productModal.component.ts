import { Component, Inject } from "@angular/core";
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ProductService } from "src/app/core/services/product.service";
import { Product } from "../../core/Models/Product";

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
            <input matInput [(ngModel)]="data.product.name">
          </mat-form-field>
          <mat-form-field style="width: 100%;" appearance="fill">
            <mat-label>Value</mat-label>
            <input matInput [(ngModel)]="data.product.value">
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
    providers : [ProductService]
})
export class ProductModal {
    constructor(
      public dialogRef: MatDialogRef<ProductModal>,
      public productService : ProductService,
      @Inject(MAT_DIALOG_DATA) public data: { product : Product ,isCreate : boolean},
    ) {}

    Name = this.data.product.name;
    

    onYesClick(): void {
      let dialogres = false;
      if(this.data.isCreate){
        this.productService.create(this.data.product).subscribe(x => dialogres = x.data);
      }
      else{
        this.productService.update(this.data.product).subscribe(x => dialogres = x.data);
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