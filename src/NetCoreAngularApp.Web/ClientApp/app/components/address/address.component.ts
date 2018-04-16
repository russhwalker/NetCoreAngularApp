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
    private customerId: number;
    private address: Address;
    private baseUrl: string;
    private isEditMode: boolean;
    private isNew: boolean;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.customerId = parseInt(route.snapshot.paramMap.get('customerid') || '0');
        this.id = parseInt(route.snapshot.paramMap.get('id') || '0');
        this.isEditMode = false;
        this.isNew = this.id === 0;
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/address/' + this.id).subscribe(result => {
            this.address = result.json() as Address;
            if (this.address.customerId === 0) {
                this.address.customerId = this.customerId;
                this.edit();
            }
        }, error => console.error(error));
    }

    edit(): void {
        this.isEditMode = true;
    }

    cancelEdit(): void {
        this.isEditMode = false;
    }

    save(): void {
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