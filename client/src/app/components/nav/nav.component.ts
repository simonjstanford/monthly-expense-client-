import { Component } from '@angular/core';
import { User } from 'src/app/models/user';
import { OauthServiceService } from 'src/app/services/oauth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  user: User | null;

  constructor(private oauthService: OauthServiceService) {
    this.user = null;
  }

  ngOnInit() {
    this.oauthService.getUser().subscribe((user) => {
      console.log("Logged in! " + user);
      this.user = user;
    });
  }
}
