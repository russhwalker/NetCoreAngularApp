import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Customer } from '../../customer';
import { CustomerStatus } from '../../customerStatus';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})

export class CustomerComponent {
    public customer: Customer;
    public customerStatuses: CustomerStatus[];
    public http: Http;
    public baseUrl: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
        this.http = http;
        this.baseUrl = baseUrl;
        var id = this.route.snapshot.paramMap.get('id');

        this.http.get(baseUrl + 'api/customer/' + id).subscribe(result => {
            this.customer = result.json() as Customer;
        }, error => console.error(error));

        this.http.get(baseUrl + 'api/customerstatus/').subscribe(result => {
            this.customerStatuses = result.json() as CustomerStatus[];
        }, error => console.error(error));

    }

    saveCustomer() {

        this.http.post(this.baseUrl + 'api/customer/', null).subscribe(result => {
            //todod result?
        }, error => console.error(error));

    }

}