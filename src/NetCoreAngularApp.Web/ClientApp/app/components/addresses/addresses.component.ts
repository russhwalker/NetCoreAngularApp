import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Address } from '../../address';

@Component({
    selector: 'addresses',
    templateUrl: './addresses.component.html'
})

export class AddressesComponent implements OnInit {
    private customerId: number;
    public addresses: Address[];
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.customerId = parseInt(route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/addresses/' + this.customerId).subscribe(result => {
            this.addresses = result.json() as Address[];
        }, error => console.error(error));
    }

}