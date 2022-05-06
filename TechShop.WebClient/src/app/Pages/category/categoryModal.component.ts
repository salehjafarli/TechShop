import { Component, Inject } from "@angular/core";
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { CategoryService } from "src/app/core/services/category.service";
import { Category } from "../../core/Models/Category";

@Component({
    selector: 'dialog-overview-example-dialog',
    template: `
        <h1 mat-dialog-title>{{Name}}</h1>
        <div mat-dialog-content>
        <ng-container *ngIf="!data.isCreate">
            <mat-form-field style="width: 100%;" appearance="fill">
              <mat-label>Id</mat-label>
              <input readonly matInput [(ngModel)]="data.category.id">
            </mat-form-field>
        </ng-container>
          <mat-form-field style="width: 100%;" appearance="fill">
            <mat-label>Name</mat-label>
            <input matInput [(ngModel)]="data.category.name">
          </mat-form-field>
        </div>
        <div mat-dialog-actions>
          <button mat-raised-button color="primary" (click)="onYesClick()" [mat-dialog-close]="data.category.name" cdkFocusInitial>Ok</button>
          <button mat-raised-button color="warn" (click)="onNoClick()">Cancel</button>
          <ng-container *ngIf="!data.isCreate"> 
            <button mat-raised-button color="warn" (click)="onDeleteClick(data.category.id)">Delete</button>
          </ng-container>
        </div>
    `,
    providers : [CategoryService]
})
export class CategoryModal {
    constructor(
      public dialogRef: MatDialogRef<CategoryModal>,
      public categoryService : CategoryService,
      @Inject(MAT_DIALOG_DATA) public data: { category : Category ,isCreate : boolean},
    ){
      console.log(data)
    }

    Name = this.data.category.name;

    onYesClick(): void {
      let dialogres = false;
      if(this.data.isCreate){
        this.categoryService.create(this.data.category).subscribe(x => dialogres = x.data);
      }
      else{
        this.categoryService.update(this.data.category).subscribe(x => dialogres = x.data);
      }
      this.dialogRef.close(dialogres);
    }

    onDeleteClick(id : number){
      let dialogres = false;
      console.log(id);
      this.categoryService.delete(id).subscribe(x => dialogres = x.data);
      this.dialogRef.close(dialogres);
    }
    
    onNoClick(): void {
      this.dialogRef.close();
    }
}