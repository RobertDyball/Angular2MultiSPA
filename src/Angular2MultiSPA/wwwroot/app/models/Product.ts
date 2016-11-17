import { Component } from '@angular/core';

export class Product {
    id: number;
    categoryId: number;
    supplierId: number;
    name: string;
    description: string;
    quantityPerUnit: string;
    unitsInStock: number;
    unitsOnOrder: number;
    reorderLevel: number;
    discontinued: boolean;
    unitPrice: number;
}
