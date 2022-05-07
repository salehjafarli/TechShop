import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Category } from 'src/app/core/Models/Category';
import { ProductService } from 'src/app/core/services/product.service';
import { Product } from '../../core/Models/Product';
import { ProductModal } from './productModal.component';

@Component({
  selector: 'app-product',
  template: `
  <h1 style="font-size: 40px;">Products</h1>
  <button class="createBtn" style="margin: 10px 0 10px 0;" mat-raised-button (click)="openDialog()">Create</button>
  <table mat-table [dataSource]="ELEMENT_DATA" class="mat-elevation-z8">
 
    <ng-container matColumnDef="id">
      <th mat-header-cell *matHeaderCellDef> Id </th>
      <td mat-cell *matCellDef="let element"> {{element.id}} </td>
    </ng-container>

    <ng-container matColumnDef="no">
      <th mat-header-cell *matHeaderCellDef> No </th>
      <td mat-cell *matCellDef="let element"> {{element.no}} </td>
    </ng-container>
  
    <ng-container matColumnDef="name">
      <th mat-header-cell *matHeaderCellDef> Name </th>
      <td mat-cell *matCellDef="let element"> {{element.name}} </td>
    </ng-container>

    <ng-container matColumnDef="value">
      <th mat-header-cell *matHeaderCellDef> Value </th>
      <td mat-cell *matCellDef="let element"> {{element.value}} </td>
    </ng-container>
    <ng-container matColumnDef="category">
      <th mat-header-cell *matHeaderCellDef> Category </th>
      <td mat-cell *matCellDef="let element"> {{element.category.name}} </td>
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
  providers : [ProductService]
})
export class ProductComponent implements OnInit {

  constructor(public dialog: MatDialog, public productService : ProductService) {}
  displayedColumns: string[] = [ 'no', 'name', 'value', 'category'];
  ELEMENT_DATA: Product[] = [
    {no: 0, id: 0, name: 'examp1',value : 2, category : new Category()},
    {no: 1, id: 1, name: 'examp2',value : 3, category : new Category()},
  ];
  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(){
    var response = this.productService.getAll();
    response.subscribe(x => 
    {
      let i : number = 0;
      x.data.forEach(p => {
        p.no = ++i;
      });
      this.ELEMENT_DATA = x.data;
    }); 
  }

  openDialog(row? : Product): void {
    var product = new Product();
    let isCreate = true;
    if(row){
      isCreate = false;
      product.id = row.id;
      product.name = row.name; 
      product.value = row.value;
      product.category = row.category;
    }
    const dialogRef = this.dialog.open(ProductModal, {
      width: '400px',
      data: {product : product , isCreate : isCreate},
    });

    dialogRef.afterClosed().subscribe(result => {
      this.loadProducts();
    });
  }
}
