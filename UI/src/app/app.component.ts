import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'interviewbase';

  constructor(private oauthService: OAuthService) {
    if (!oauthService.hasValidAccessToken() || !oauthService.hasValidIdToken()) {
      this.oauthService.initCodeFlow('/');
    }

  }
}
