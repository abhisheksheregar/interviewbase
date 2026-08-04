import { APP_INITIALIZER, ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { OAuthService, provideOAuthClient } from 'angular-oauth2-oidc';

import { routes } from './app.routes';
import { authInterceptor } from './auth/auth.interceptor';
import { initializeAuth } from './auth/auth.initializer';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideAnimationsAsync(),
    provideHttpClient(withInterceptors([authInterceptor])),
    provideOAuthClient(),
     {
      provide: APP_INITIALIZER,
      useFactory: initializeAuth,
      deps: [OAuthService],
      multi: true
    }
  ],
};
