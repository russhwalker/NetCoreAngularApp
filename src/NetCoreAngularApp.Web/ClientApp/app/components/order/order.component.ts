import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Order } from '../../order';
import { OrderDetail } from '../../orderDetail';

@Component({
    selector: 'order',
    templateUrl: './order.component.html'
})

export class OrderComponent implements OnInit {
    private id: number;
    public order: Order;
    public orderDetail: OrderDetail;
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.id = parseInt(route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/orderdetail/' + this.id).subscribe(result => {
            this.orderDetail = result.json() as OrderDetail;
            this.order = this.orderDetail.order;
        }, error => console.error(error));
    }

    test(): void {
        alert('got here');
        var asdf = this.orderDetail;
    }

}