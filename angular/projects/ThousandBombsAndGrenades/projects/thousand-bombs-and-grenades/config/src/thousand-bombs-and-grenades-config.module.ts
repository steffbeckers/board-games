import { ModuleWithProviders, NgModule } from '@angular/core';
import { THOUSAND_BOMBS_AND_GRENADES_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ThousandBombsAndGrenadesConfigModule {
  static forRoot(): ModuleWithProviders<ThousandBombsAndGrenadesConfigModule> {
    return {
      ngModule: ThousandBombsAndGrenadesConfigModule,
      providers: [THOUSAND_BOMBS_AND_GRENADES_ROUTE_PROVIDERS],
    };
  }
}
