import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { OrderDetail } from '../../orderDetail';

@Component({
    selector: 'order',
    templateUrl: './order.component.html'
})

export class OrderComponent implements OnInit {
    private id: number;
    public orderDetail: OrderDetail | undefined;
    private baseUrl: string;
    private isNew: boolean;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.id = parseInt(route.snapshot.paramMap.get('id') || '0');
        this.isNew = this.id === 0;
    }

    save(): void {
        this.http.post(this.baseUrl + 'api/orderdetail/', this.orderDetail).subscribe(result => {
            this.isNew = false;
            var o = result.json() as OrderDetail;
            if (this.id === 0) {
                this.id = o.order.orderId;
                this.location.go('/orderdetail/' + o.order.orderId);
            }
        }, error => console.error(error));
    }

    goBack(): void {
        this.location.back();
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/orderdetail/' + this.id).subscribe(result => {
            this.orderDetail = result.json() as OrderDetail;
        }, error => console.error(error));
    }

}