import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, FormsModule } from '@angular/forms';
import { SharedMaterialModule } from '../shared/shared-material.module';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmployeeDto } from '../models/EmployeeDto';
import { ProductDto } from '../models/ProductDto';
import { ShipperDto } from '../models/ShipperDto';
import { RouterModule } from '@angular/router';
import { CustomerService } from '../services/customer.service';
import { forkJoin } from 'rxjs';
import { NewOrderDto } from '../models/NewOrderDto';

@Component({
  selector: 'app-new-order',
  standalone: true,
  imports: [CommonModule,
    SharedMaterialModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule],
  templateUrl: './new-order.component.html',
  styleUrl: './new-order.component.css'
})
export class NewOrderComponent implements OnInit {
  customerId: number = -1;
  customerName: string = '';
  orderForm: FormGroup;
  employees: EmployeeDto[] = [];
  shippers: ShipperDto[] = [];
  products: ProductDto[] = [];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar,
    private customerService: CustomerService) {
    this.orderForm = this.fb.group({
      employeeID: [null, [Validators.required, Validators.min(1)]],
      shipperID: [null, [Validators.required, Validators.min(1)]],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      orderDate: ['', Validators.required],
      requiredDate: ['', Validators.required],
      shippedDate: ['', Validators.required],
      freight: [null, [Validators.required, Validators.min(0),
        Validators.max(1000000), 
        Validators.pattern(/^\d+(\.\d{1,2})?$/)]],
      shipCountry: ['', Validators.required],
      productGroup: this.fb.group({
        productID: [null, [Validators.required, Validators.min(1)]],
        unitPrice: [null, [Validators.required, Validators.min(0.01)]],
        qty: [null, [Validators.required, Validators.min(0),
          Validators.max(9999)]],
        discount: [0, [Validators.required, Validators.min(0), Validators.max(1), Validators.pattern(/^([0](\.\d{1,2})?|1(\.0{1,2})?)$/)]]
      })
    });
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('customerId');
    this.customerId = id ? Number(id) : 0;
    this.customerName = this.route.snapshot.paramMap.get('customerName') ?? '';

    forkJoin({
      shippers: this.customerService.getShippers(),
      products: this.customerService.getProducts(),
      employees: this.customerService.getEmployees()
    }).subscribe({
      next: ({ shippers, products, employees }) => {
        this.shippers = shippers;
        this.products = products;
        this.employees = employees;
      },
      error: err => console.error(err)
    });
  }

  get productGroup(): FormGroup {
    return this.orderForm.get('productGroup') as FormGroup;
  }

  onSubmit() {
    if (this.orderForm.invalid) {
      this.orderForm.markAllAsTouched();
    }
    else {
      const formValue = this.orderForm.value;

      const newOrder: NewOrderDto = {
        customerID: this.customerId.toString(),
        employeeID: formValue.employeeID,
        shipperID: formValue.shipperID,
        shipName: formValue.shipName,
        shipAddress: formValue.shipAddress,
        shipCity: formValue.shipCity,
        orderDate: formValue.orderDate,      
        requiredDate: formValue.requiredDate,
        shippedDate: formValue.shippedDate,
        freight: formValue.freight,
        shipCountry: formValue.shipCountry,
        product: {
          productID: formValue.productGroup.productID,
          unitPrice: formValue.productGroup.unitPrice,
          qty: formValue.productGroup.qty,
          discount: formValue.productGroup.discount
        }
      };
      this.customerService.addOrder(newOrder).subscribe({
        next: (data) => {
          this.router.navigate(['/']);
          this.snackBar.open(`New order(${data}) for ${this.customerName} was Created`, 'Close', {
            duration: 3000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: ['snack-success']
          });
        },
        error: (err) => console.error(err)
      });
    }
  }
}
