import { Component, OnInit } from '@angular/core';
import { DomSanitizer} from '@angular/platform-browser';

import { TestDataService } from './services/testData.service';
import { Category } from './category.ts';

@Component({
    selector: 'my-content',
    templateUrl: '/partial/contentComponent'
})

export class ContentComponent implements OnInit {
    testData: Category[] = [];

    constructor(
        private _DomSanitizer: DomSanitizer,
        private testDataService: TestDataService
    ) { }

    ngOnInit() {
        this.testDataService.getTestData()
            .subscribe((data: Category[]) => this.testData = data);
    }
}
