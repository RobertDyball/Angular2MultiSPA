import { Component, OnInit } from '@angular/core';
import { DomSanitizer} from '@angular/platform-browser';

import { CategoryService } from './services/Category.service';
import { ProductService } from './services/Product.service';
import { Category } from './models/Category.ts';
import { Product } from './models/Product.ts';

@Component({
    selector: 'my-content',
    templateUrl: '/partial/contentComponent'
})

export class ContentComponent implements OnInit {
    categories: Category[] = [];
    products: Product[] = [];
    selectedCategory: Category = null;

    constructor(
        private _DomSanitizer: DomSanitizer,
        private productService: ProductService,
        private categoryService: CategoryService
    ) { }

    ngOnInit() {
        this.categoryService.getCategories()
            .subscribe((data: Category[]) => this.categories = data);
        this.presetToFirstItem();
    }

    presetToFirstItem(): void {
        if (this.selectedCategory === null) {
            this.selectedCategory = this.categories.length > 0 ? this.categories[0] : null;
        }
    }

    selectCategory(category: Category): void {
        this.selectedCategory = category;
        this.products = [];
        this.productService.getProducts(this.selectedCategory.id)
            .subscribe((data: Product[]) => this.products = data);
    }

    getClass(category: Category): string {
        this.presetToFirstItem();
        return (this.selectedCategory != null && (this.selectedCategory.id === category.id)) ? "active" : "";
    }
}
