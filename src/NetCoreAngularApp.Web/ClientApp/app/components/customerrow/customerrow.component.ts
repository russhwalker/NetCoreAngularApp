import { Component, Input } from '@angular/core';
import { Customer } from '../../customer';

@Component({
    selector: '[customer-row]',
    templateUrl: './customerRow.component.html'
})

export class CustomerRowComponent {
    @Input() customer: Customer | undefined;
}