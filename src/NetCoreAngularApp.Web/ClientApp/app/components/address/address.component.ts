import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Address } from '../../address';

@Component({
    selector: 'address',
    templateUrl: './address.component.html'
})

export class AddressComponent implements OnInit {
    private id: number;
    private address: Address;
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.id = parseInt(route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/address/' + this.id).subscribe(result => {
            this.address = result.json() as Address;
        }, error => console.error(error));
    }

    saveAddress(): void {
        this.http.post(this.baseUrl + 'api/address/', this.address).subscribe(result => {
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