import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Product } from '../../Models/Product';
import { ProductModal } from './productModal.component';

@Component({
  selector: 'app-product',
  template: `
  <h1 style="font-size: 40px;">Products</h1>
  <table mat-table [dataSource]="ELEMENT_DATA" class="mat-elevation-z8">
 
    <ng-container matColumnDef="Id">
      <th mat-header-cell *matHeaderCellDef> Id </th>
      <td mat-cell *matCellDef="let element"> {{element.Id}} </td>
    </ng-container>
  
    <ng-container matColumnDef="Name">
      <th mat-header-cell *matHeaderCellDef> Name </th>
      <td mat-cell *matCellDef="let element"> {{element.Name}} </td>
    </ng-container>

    <ng-container matColumnDef="Value">
      <th mat-header-cell *matHeaderCellDef> Value </th>
      <td mat-cell *matCellDef="let element"> {{element.Value}} </td>
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
export class ProductComponent implements OnInit {

  constructor(public dialog: MatDialog) {}
  displayedColumns: string[] = ['Id', 'Name', 'Value'];
  ELEMENT_DATA: Product[] = [
    {Id: 1, Name: 'Hydrogen', Value : 2},
    {Id: 2, Name: 'Helium',Value : 2},
    {Id: 3, Name: 'Lithium',Value : 2},
    {Id: 4, Name: 'Beryllium',Value : 2},
    {Id: 5, Name: 'Boron',Value : 2},
    {Id: 6, Name: 'Carbon',Value : 2},
    {Id: 7, Name: 'Nitrogen',Value : 2},
    {Id: 8, Name: 'Oxygen',Value : 2},
    {Id: 9, Name: 'Fluorine',Value : 2},
    {Id: 10,Name: 'Neon',Value : 2},
  ];
  ngOnInit(): void {
  }

  openDialog(row : Product): void {
    var product = new Product();
    product.Id = row.Id;
    product.Name = row.Name; 
    product.Value = row.Value;
    const dialogRef = this.dialog.open(ProductModal, {
      width: '400px',
      data: product,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
    });
  }

}
