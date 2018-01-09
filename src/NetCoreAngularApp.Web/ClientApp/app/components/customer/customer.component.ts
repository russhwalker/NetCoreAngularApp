import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Customer } from '../../customer';
import { CustomerStatus } from '../../customerStatus';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})

export class CustomerComponent implements OnInit {
    public id: number;
    public customer: Customer;
    public customerStatuses: CustomerStatus[];
    public http: Http;
    public baseUrl: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.id = parseInt(this.route.snapshot.paramMap.get('id') || '0');
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/customerstatus/').subscribe(result => {
            this.customerStatuses = result.json() as CustomerStatus[];
        }, error => console.error(error));

        this.http.get(this.baseUrl + 'api/customer/' + this.id).subscribe(result => {
            this.customer = result.json() as Customer;
        }, error => console.error(error));
    }

    saveCustomer() {

        this.http.post(this.baseUrl + 'api/customer/', this.customer).subscribe(result => {
            //todo result?

        }, error => console.error(error));

    }

}