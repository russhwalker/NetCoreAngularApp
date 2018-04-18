import { Order } from './order';
import { Customer } from './customer';

export interface OrderDetail {
    order: Order;
    customer: Customer;
}