import { Component } from '@angular/core';

export class Order {
    id: number;
    customerId: number;
    orderDate: Date;
    shippedDate: Date;
    shipVia: number;
    freight: number;
    shipName: string;
    shipAddress: string;
    shipCity: string;
    shipRegion: string;
    shipPostalCode: string;
    shipCountry: string;
}
