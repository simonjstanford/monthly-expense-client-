import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { User } from 'src/app/models/user';
import { OauthServiceService } from 'src/app/services/oauth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
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
