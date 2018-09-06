import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { OrderItemView } from '../../orderItemView';

@Component({
    selector: 'order-items',
    templateUrl: './orderitems.component.html'
})

export class OrderItemsComponent implements OnInit {
    public orderItems: OrderItemView[] | undefined;
    //public orderItem: OrderItem | undefined;
    private baseUrl: string;
    private id: number;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.id = parseInt(route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/orderitems/' + this.id).subscribe(result => {
            this.orderItems = result.json() as OrderItemView[];
        }, error => console.error(error));
    }

}