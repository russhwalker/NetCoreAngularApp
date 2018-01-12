import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Order } from '../../order';
import { Product } from '../../product';

@Component({
    selector: 'order',
    templateUrl: './order.component.html'
})

export class OrderComponent implements OnInit {
    private id: number;
    private order: Order;
    public products: Product[];
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.id = parseInt(route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/order/' + this.id).subscribe(result => {
            this.order = result.json() as Order;
        }, error => console.error(error));
        this.http.get(this.baseUrl + 'api/products/' + this.id).subscribe(result => {
            this.products = result.json() as Product[];
        }, error => console.error(error));
    }

    saveOrder(): void {
        this.http.post(this.baseUrl + 'api/order/', this.order).subscribe(result => {
            if (result.text() === 'true') {
                //back to customer list
                this.location.back();
            } else {
                alert('error');
            }
        }, error => console.error(error));
    }

    goBack(): void {
        this.location.back();
    }
}