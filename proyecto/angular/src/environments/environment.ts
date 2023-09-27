import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'proyecto',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44340/',
    redirectUri: baseUrl,
    clientId: 'proyecto_App',
    responseType: 'code',
    scope: 'offline_access proyecto',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44340',
      rootNamespace: 'proyecto',
    },
  },
} as Environment;
