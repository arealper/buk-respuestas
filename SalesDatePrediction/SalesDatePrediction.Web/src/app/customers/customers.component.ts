import { CommonModule } from '@angular/common';
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { SharedMaterialModule } from '../shared/shared-material.module';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CustomerDto } from '../models/CustomerDto';
import { CustomerService } from '../services/customer.service';
import { MatSort } from '@angular/material/sort';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { OrdersViewComponent } from '../orders-view/orders-view.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [
    CommonModule,
    SharedMaterialModule,
    MatDialogModule,
    RouterModule,
    FormsModule
  ],
  providers: [CustomerService],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'actions'];
  dataSource = new MatTableDataSource<CustomerDto>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  searchTerm = '';

  constructor(private customerService: CustomerService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.customerService.getCustomers().subscribe(data => {
      this.dataSource.data = data;
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter() {
    const filterValue = this.searchTerm.trim().toLowerCase();
    this.customerService.getCustomers(filterValue).subscribe((data)=> {
      this.dataSource.data = data;
    });
  }

  viewOrders(customer: CustomerDto) {   
    this.dialog.open(OrdersViewComponent, {
      maxWidth: '70vw',
      maxHeight: '800px',
      data: customer
    });
  }

  addOrder(customer: CustomerDto) {
    // open add order modal
  }
}
