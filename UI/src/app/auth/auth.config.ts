import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
  issuer: 'https://login.microsoftonline.com/0415f878-83ff-48ad-9cd3-8b5cbced9dd9/v2.0',
  redirectUri: window.location.origin,
  postLogoutRedirectUri: window.location.origin,
  clientId: '12051bef-1587-4a2f-bb4d-b6fab29b6b4f',
  responseType: 'code',
  scope: 'openid profile email offline_access api://877c115d-4c2d-4f6a-860c-ccc3d9aabc52/api_test_scope',
  showDebugInformation: true,
  requireHttps: 'remoteOnly',
  oidc: true,
  requestAccessToken: true,
  disablePKCE: false,
  clearHashAfterLogin: true,
  customQueryParams: {
    prompt: 'select_account',
  },
  strictDiscoveryDocumentValidation: false,
};


