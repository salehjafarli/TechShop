import { DataRowOutlet } from '@angular/cdk/table';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import { ApiService } from 'src/app/core/services/api.service';
import { CategoryService } from 'src/app/core/services/category.service';
import { Category } from '../../core/Models/Category';
import { CategoryModal } from './categoryModal.component';

@Component({
  selector: 'app-category',
  template:`
  <h1 style="font-size: 40px;">Categories</h1>
  <button class="createBtn" style="margin: 10px 0 10px 0;" mat-raised-button (click)="openDialog()">Create</button>
  <table mat-table [dataSource]="ELEMENT_DATA" class="mat-elevation-z8">
    <!-- Position Column -->
    <ng-container matColumnDef="id">
      <th mat-header-cell *matHeaderCellDef> Id </th>
      <td mat-cell *matCellDef="let element"> {{element.id}} </td>
    </ng-container>

    <!-- Name Column -->
    <ng-container matColumnDef="name">
      <th mat-header-cell *matHeaderCellDef> Name </th>
      <td mat-cell *matCellDef="let element"> {{element.name}} </td>
    </ng-container>

    <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
    <tr mat-row *matRowDef="let row; columns: displayedColumns;" (click)="openDialog(row)"></tr>
  </table>
  `,
  styles: [`
      table {
          width: 100%;
      }
      .demo-table {
          width: 100%;
      }
      
      .mat-row .mat-cell {
        border-bottom: 1px solid transparent;
        border-top: 1px solid transparent;
        cursor: pointer;
      }
      
      .mat-row:hover .mat-cell {
        border-color: currentColor;
      }
      
      .demo-row-is-clicked {
        font-weight: bold;
      }
  `],
  providers : [CategoryService]
})
export class CategoryComponent implements OnInit {
  constructor(public dialog: MatDialog, public categoryService : CategoryService) {}
  
  displayedColumns: string[] = ['id', 'name'];
  ELEMENT_DATA: Category[] = [
    {id: 0, name: 'examp1'},
    {id: 1, name: 'examp2'}
  ]
  clickedRows = new Set<Category>();

  ngOnInit(): void {
    this.LoadCategories();
  }

  LoadCategories(){
    var response = this.categoryService.getAll();
    response.subscribe(x => 
    {
      this.ELEMENT_DATA = x.data;
    }); 
  }

  openDialog(row? : Category): void {
    let category = new Category();
    let isCreate = true;
    if(row){
      isCreate = false;
      category.id = row.id;
      category.name = row.name; 
    }
    const dialogRef = this.dialog.open(CategoryModal, {
      width: '400px',
      data: {category : category , isCreate : isCreate}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.LoadCategories();
    });
  }
}


