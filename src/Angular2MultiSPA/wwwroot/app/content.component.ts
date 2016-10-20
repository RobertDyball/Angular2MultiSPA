import { Component, OnInit } from '@angular/core';
import { DomSanitizer} from '@angular/platform-browser';

import { CategoryService } from './services/Category.service';
import { Category } from './category.ts';

@Component({
    selector: 'my-content',
    templateUrl: '/partial/contentComponent'
})

export class ContentComponent implements OnInit {
    categories: Category[] = [];

    constructor(
        private _DomSanitizer: DomSanitizer,
        private categoryService: CategoryService
    ) { }

    ngOnInit() {
        this.categoryService.getCategories()
            .subscribe((data: Category[]) => this.categories = data);
    }
}
