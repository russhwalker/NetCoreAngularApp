import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Order } from '../../order';

@Component({
    selector: 'orders',
    templateUrl: './orders.component.html'
})

export class OrdersComponent implements OnInit {
    public orders: Order[] | undefined;
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/orders/').subscribe(result => {
            this.orders = result.json() as Order[];
        }, error => console.error(error));
    }

}