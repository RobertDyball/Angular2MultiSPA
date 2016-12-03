import { Component, OnInit } from '@angular/core';
import { DomSanitizer} from '@angular/platform-browser';

import { SampleDataService } from './services/SampleData.service';
import { SampleData } from './models/SampleData.ts';

@Component({
    selector: 'my-content',
    templateUrl: '/partial/documentationComponent'
})

export class DocumentationComponent implements OnInit {
    sampleData: SampleData = null;

    constructor(
        private _DomSanitizer: DomSanitizer,
        private sampleDataService: SampleDataService
    ) { }

    ngOnInit() {
        this.sampleDataService.getSampleData()
            .subscribe((data: SampleData) => this.sampleData = data);
    }
}
