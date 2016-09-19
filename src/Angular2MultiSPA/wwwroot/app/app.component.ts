import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    templateUrl: '/partial/appComponent'
})

export class AppComponent {
    testData: string[] = ['now with', 'hard-coded', 'string array', 'data values'];
}
