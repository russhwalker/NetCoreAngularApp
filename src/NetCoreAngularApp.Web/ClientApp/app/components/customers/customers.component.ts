import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'customers',
    templateUrl: './customers.component.html'
})

export class CustomersComponent {
    public customers: Customer[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Customers').subscribe(result => {
            this.customers = result.json() as Customer[];
        }, error => console.error(error));
    }
}

interface Customer {
    customerId: number;
    firstName: string;
    lastName: string;
}
