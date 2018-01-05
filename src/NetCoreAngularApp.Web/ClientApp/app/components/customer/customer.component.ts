import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Customer } from '../../customer';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})

export class CustomerComponent {
    public customer: Customer;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
        var id = this.route.snapshot.paramMap.get('id');
        http.get(baseUrl + 'api/customer/' + id).subscribe(result => {
            this.customer = result.json() as Customer;
        }, error => console.error(error));
    }
}