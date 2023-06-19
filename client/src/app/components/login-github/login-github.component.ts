import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OauthServiceService } from '../../services/oauth-service.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-login-github',
  templateUrl: './login-github.component.html',
  styleUrls: ['./login-github.component.css']
})
export class LoginGithubComponent {
  message = '';
  user: User | null;

  constructor(private http: HttpClient, private oauthService: OauthServiceService) {
    this.user = null;
  }

  ngOnInit() {
    this.oauthService.currentUserSubject.subscribe((user) => {
      this.user = user;
    });
  }

  login() {
    //this.http.get('/api/Test').subscribe((resp: any) => this.message = resp.text);
    this.http.get('/api/Test').subscribe((resp: any) => this.message = resp.text);
  }
}
