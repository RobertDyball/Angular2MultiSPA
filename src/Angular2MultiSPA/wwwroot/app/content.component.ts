import { Component, OnInit } from '@angular/core';

import { TestDataService } from './services/testData.service';

@Component({
    selector: 'my-content',
    templateUrl: '/partial/contentComponent'
})

export class ContentComponent implements OnInit {
    testData: string[] = [];

    constructor(private testDataService: TestDataService) { }

    ngOnInit() {
        this.testDataService.getTestData()
            .subscribe((data: string[]) => this.testData = data);
    }
}
