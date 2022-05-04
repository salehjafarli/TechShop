import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import { Category } from '../../Models/Category';
import { CategoryModal } from './categoryModal.component';

@Component({
  selector: 'app-category',
  template:`
  <h1 style="font-size: 40px;">Categories</h1>
  <table mat-table [dataSource]="ELEMENT_DATA" class="mat-elevation-z8">
  <!-- Position Column -->
  <ng-container matColumnDef="Id">
    <th mat-header-cell *matHeaderCellDef> Id </th>
    <td mat-cell *matCellDef="let element"> {{element.Id}} </td>
  </ng-container>

  <!-- Name Column -->
  <ng-container matColumnDef="Name">
    <th mat-header-cell *matHeaderCellDef> Name </th>
    <td mat-cell *matCellDef="let element"> {{element.Name}} </td>
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
  `]
})
export class CategoryComponent implements OnInit {

  constructor(public dialog: MatDialog) {}
  displayedColumns: string[] = ['Id', 'Name'];
  ELEMENT_DATA: Category[] = [
    {Id: 1, Name: 'Hydrogen'},
    {Id: 2, Name: 'Helium'},
    {Id: 3, Name: 'Lithium'},
    {Id: 4, Name: 'Beryllium'},
    {Id: 5, Name: 'Boron'},
    {Id: 6, Name: 'Carbon'},
    {Id: 7, Name: 'Nitrogen'},
    {Id: 8, Name: 'Oxygen'},
    {Id: 9, Name: 'Fluorine'},
    {Id: 10,Name: 'Neon'},
  ];
  clickedRows = new Set<Category>();
  ngOnInit(): void {

  }
  openDialog(row : Category): void {
    var category = new Category();
    category.Id = row.Id;
    category.Name = row.Name; 
    const dialogRef = this.dialog.open(CategoryModal, {
      width: '400px',
      data: category,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
    });
  }
}


