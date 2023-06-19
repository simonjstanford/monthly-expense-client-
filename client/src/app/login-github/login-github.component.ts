import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OauthServiceService } from '../services/oauth-service.service';

@Component({
  selector: 'app-login-github',
  templateUrl: './login-github.component.html',
  styleUrls: ['./login-github.component.css']
})
export class LoginGithubComponent {
  message = '';

  constructor(private http: HttpClient, private oauthService: OauthServiceService) {
  }

  ngOnInit() {
    const user = this.oauthService.getUser();
  }

  login() {
    //this.http.get('/api/Test').subscribe((resp: any) => this.message = resp.text);
    this.http.get('/api/Test').subscribe((resp: any) => this.message = resp.text);
  }
}
