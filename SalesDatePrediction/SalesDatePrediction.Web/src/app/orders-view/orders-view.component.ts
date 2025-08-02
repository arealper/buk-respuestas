import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { OrderDto } from '../models/OrderDto';
import { CommonModule } from '@angular/common';
import { SharedMaterialModule } from '../shared/shared-material.module';
import { CustomerService } from '../services/customer.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-orders-view',
  standalone: true,
  imports: [
    CommonModule,
    SharedMaterialModule,
    MatDialogModule
  ],
  templateUrl: './orders-view.component.html',
  styleUrl: './orders-view.component.css'
})
export class OrdersViewComponent implements OnInit {
  displayedColumns: string[] = ['orderID', 'requiredDate', 'shippedDate', 'shipName', 'shipAddress', 'shipCity'];
  dataSource = new MatTableDataSource<OrderDto>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private customerService: CustomerService, 
    public dialogRef: MatDialogRef<OrdersViewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: OrderDialogData
  ) { }

  ngOnInit(): void {
    this.customerService.getOrdersByCustomer(this.data.customerId).subscribe({
      next: orders => {
        console.log('ORDERS RECEIVED', orders);
        this.dataSource.data = orders;
      },
      error: err => console.error('Error loading orders', err)
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}

export interface OrderDialogData {
  customerId: number;
  customerName: string;
  orders: OrderDto[];
}
