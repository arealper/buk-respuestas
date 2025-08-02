import { NewOrderItemDto } from "./NewOrderItemDto";

export interface NewOrderDto {
  customerID: string;
  employeeID: number;
  shipperID: number;
  shipName: string;
  shipAddress: string;
  shipCity: string;
  orderDate: string;        
  requiredDate: string;     
  shippedDate: string;      
  freight: number;
  shipCountry: string;

  product: NewOrderItemDto;
}
