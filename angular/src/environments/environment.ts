import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'BoardGames',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44385',
    redirectUri: baseUrl,
    clientId: 'BoardGames_App',
    responseType: 'code',
    scope: 'offline_access openid profile role email phone BoardGames',
  },
  apis: {
    default: {
      url: 'https://localhost:44385',
      rootNamespace: 'BoardGames',
    },
  },
} as Environment;
