import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';

  constructor(private httpclient: HttpClient) {
    this.httpclient.get('/api/policy').subscribe(s => { console.log(s) });
  }

}
