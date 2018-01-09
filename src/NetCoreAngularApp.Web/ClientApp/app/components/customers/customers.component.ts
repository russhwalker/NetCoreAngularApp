import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Customer } from '../../customer';

@Component({
    selector: 'customers',
    templateUrl: './customers.component.html'
})

export class CustomersComponent implements OnInit {
    public customers: Customer[];
    public http: Http;
    public baseUrl: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/Customer/').subscribe(result => {
            this.customers = result.json() as Customer[];
        }, error => console.error(error));
    }

}
