import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Customer } from '../../customer';
import { CustomerStatus } from '../../customerStatus';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})

export class CustomerComponent implements OnInit {
    private id: number;
    private customer: Customer;
    private customerStatuses: CustomerStatus[];
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, private location: Location) {
        this.baseUrl = baseUrl;
        this.id = parseInt(route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/customerstatus/').subscribe(result => {
            this.customerStatuses = result.json() as CustomerStatus[];
        }, error => console.error(error));

        this.http.get(this.baseUrl + 'api/customer/' + this.id).subscribe(result => {
            this.customer = result.json() as Customer;
        }, error => console.error(error));
    }

    saveCustomer(): void {
        this.http.post(this.baseUrl + 'api/customer/', this.customer).subscribe(result => {
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