import { Component, Inject } from "@angular/core";
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Product } from "../../Models/Product";

@Component({
    selector: 'dialog-overview-example-dialog',
    template: `
        <h1 mat-dialog-title>{{Name}}</h1>
        <div mat-dialog-content>
          <mat-form-field style="width: 100%;" appearance="fill">
            <mat-label>Id</mat-label>
            <input readonly matInput [(ngModel)]="data.Id">
          </mat-form-field>
          <mat-form-field style="width: 100%;" appearance="fill">
            <mat-label>Name</mat-label>
            <input matInput [(ngModel)]="data.Name">
          </mat-form-field>
          <mat-form-field style="width: 100%;" appearance="fill">
            <mat-label>Value</mat-label>
            <input matInput [(ngModel)]="data.Value">
          </mat-form-field>
        </div>
        <div mat-dialog-actions>
          <button mat-raised-button color="primary" [mat-dialog-close]="data.Name" cdkFocusInitial>Ok</button>
          <button mat-raised-button color="warn" (click)="onNoClick()">Cancel</button>
          <button mat-raised-button color="warn" (click)="onNoClick()">Delete</button>
        </div>
    `,
})
export class ProductModal {
    constructor(
      public dialogRef: MatDialogRef<ProductModal>,
      @Inject(MAT_DIALOG_DATA) public data: Product,
    ) {}
    Name = this.data.Name;
    onNoClick(): void {
      this.dialogRef.close();
    }
}