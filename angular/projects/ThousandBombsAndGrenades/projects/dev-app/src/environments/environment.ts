import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'ThousandBombsAndGrenades',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44335',
    redirectUri: baseUrl,
    clientId: 'ThousandBombsAndGrenades_App',
    responseType: 'code',
    scope: 'offline_access ThousandBombsAndGrenades role email openid profile',
  },
  apis: {
    default: {
      url: 'https://localhost:44335',
      rootNamespace: 'ThousandBombsAndGrenades',
    },
    ThousandBombsAndGrenades: {
      url: 'https://localhost:44386',
      rootNamespace: 'ThousandBombsAndGrenades',
    },
  },
} as Environment;
