import { OAuthService } from 'angular-oauth2-oidc';
import { authConfig } from './auth.config';

export function initializeAuth(oauthService: OAuthService) {

  return async () => {

    oauthService.configure(authConfig);

    oauthService.setupAutomaticSilentRefresh();

    await oauthService.loadDiscoveryDocumentAndTryLogin();

    console.log(
      'Access Token:',
      oauthService.getAccessToken()
    );

    console.log(
      'Authenticated:',
      oauthService.hasValidAccessToken()
    );
  };
}