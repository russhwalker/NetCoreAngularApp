import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { OrderItem } from '../../orderItem';
import { Product } from '../../product';

@Component({
    selector: 'order-item-edit',
    templateUrl: './orderitemedit.component.html'
})

export class OrderItemEditComponent implements OnInit {
    public orderItem: OrderItem | undefined;
    private products: Product[] | undefined;
    private baseUrl: string;
    private displayAdd: boolean;

    constructor(private http: Http,
        @Inject('BASE_URL') baseUrl: string,
        route: ActivatedRoute,
        private location: Location) {
        this.baseUrl = baseUrl;
        this.displayAdd = this.orderItem == undefined;
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/product/').subscribe(result => {
            this.products = result.json() as Product[];
        }, error => console.error(error));
    }

    save(): void {
        //this.http.post(this.baseUrl + 'api/orderdetail/', this.orderDetail).subscribe(result => {
        //    this.isNew = false;
        //    var o = result.json() as OrderDetail;
        //    if (this.id === 0) {
        //        this.id = o.order.orderId;
        //        this.location.go('/orderdetail/' + o.order.orderId);
        //    }
        //}, error => console.error(error));
    }

    add(): void {
        this.orderItem = {
            orderItemId: 0,
            orderId: 0,
            productId: 0,
            price: 0
        };
        this.displayAdd = false;
    }

    cancel(): void {
        this.displayAdd = true;
        this.orderItem = undefined;
    }

}