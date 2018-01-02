import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})

export class CustomerComponent {
    public customer: Customer;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Customer/').subscribe(result => {
            this.customer = result.json() as Customer;
        }, error => console.error(error));
    }
}

interface Customer {
    customerId: number;
    firstName: string;
    lastName: string;
}
