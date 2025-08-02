import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CustomerDto } from "../models/CustomerDto";
import { OrderDto } from "../models/OrderDto";
import { EmployeeDto } from "../models/EmployeeDto";
import { ProductDto } from "../models/ProductDto";
import { ShipperDto } from "../models/ShipperDto";
import { NewOrderDto } from "../models/NewOrderDto";

@Injectable({ providedIn: 'root' })
export class CustomerService {
  baseUrl: string;
  private headers = {
    headers: {
      'Content-Type': 'application/json'
    }
  };

  constructor(private http: HttpClient) {
    this.baseUrl = `https://localhost:7212`;
  }

  getCustomers(search?: string): Observable<CustomerDto[]> {
    let params = new HttpParams();
    if (search) {
      params = params.set('search', search);
    }

    return this.http.get<CustomerDto[]>(`${this.baseUrl}/api/customers/predictions`, { params });
  }

  getOrdersByCustomer(customerId: number): Observable<OrderDto[]> {
    return this.http.get<OrderDto[]>(`${this.baseUrl}/api/orders/${customerId}`);
  }

  getProducts(): Observable<ProductDto[]> {
    return this.http.get<ProductDto[]>(`${this.baseUrl}/api/products`);
  }

  getShippers(): Observable<ShipperDto[]> {
    return this.http.get<ShipperDto[]>(`${this.baseUrl}/api/shippers`);
  }

  getEmployees(): Observable<EmployeeDto[]> {
    return this.http.get<EmployeeDto[]>(`${this.baseUrl}/api/employees`);
  }

  addOrder(newOrder:NewOrderDto): Observable<number> {
    return this.http.post<number>(`${this.baseUrl}/api/orders`, newOrder, this.headers);
  }
}
