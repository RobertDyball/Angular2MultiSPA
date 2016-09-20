import { Component, OnInit } from '@angular/core';

import { TestDataService } from './services/testData.service';

@Component({
    selector: 'my-app',
    templateUrl: '/partial/appComponent'
})

export class AppComponent implements OnInit {
    testData: string[] = [];

    constructor(private testDataService: TestDataService) { }

    ngOnInit() {
        this.testDataService.getTestData()
            .subscribe((data: string[]) => this.testData = data);
    }
}
