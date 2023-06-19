import { Component } from '@angular/core';
import { OauthServiceService } from './services/oauth-service.service';
import { User } from './models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'monthly-expenses';
}
