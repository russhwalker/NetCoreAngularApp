import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Product } from '../../product';

@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})

export class ProductComponent implements OnInit {
    private id: number;
    private product: Product;
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.id = parseInt(route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/product/' + this.id).subscribe(result => {
            this.product = result.json() as Product;
        }, error => console.error(error));
    }

    saveProduct(): void {
        this.http.post(this.baseUrl + 'api/product/', this.product).subscribe(result => {
            if (result.text() === 'true') {
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