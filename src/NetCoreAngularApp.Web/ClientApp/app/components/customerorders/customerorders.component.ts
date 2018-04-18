import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Order } from '../../order';

@Component({
    selector: 'customer-orders',
    templateUrl: './customerorders.component.html'
})

export class CustomerOrdersComponent implements OnInit {
    private customerId: number;
    public orders: Order[];
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.customerId = parseInt(route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/orders/' + this.customerId).subscribe(result => {
            this.orders = result.json() as Order[];
        }, error => console.error(error));
    }

}