import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { CustomersComponent } from './components/customers/customers.component';
import { CustomerComponent } from './components/customer/customer.component';
import { CustomerRowComponent } from './components/customerrow/customerrow.component'
import { AddressComponent } from './components/address/address.component';
import { AddressesComponent } from './components/addresses/addresses.component';
import { OrdersComponent } from './components/orders/orders.component';

var routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'customers', component: CustomersComponent },
    { path: 'customer/:id', component: CustomerComponent },
    { path: 'address/:customerid/:id', component: AddressComponent },
    { path: 'orders', component: OrdersComponent },
    { path: '**', redirectTo: 'home' }
];

@NgModule({
    declarations: [
        AddressComponent,
        AddressesComponent,
        AppComponent,
        CustomerComponent,
        CustomerRowComponent,
        CustomersComponent,
        HomeComponent,
        NavMenuComponent,
        OrdersComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot(routes, { enableTracing: false })
    ],
    exports: [
    ]
})
export class AppModuleShared {
}