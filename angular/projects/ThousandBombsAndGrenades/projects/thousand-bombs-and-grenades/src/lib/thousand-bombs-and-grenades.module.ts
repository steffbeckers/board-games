import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ThousandBombsAndGrenadesComponent } from './components/thousand-bombs-and-grenades.component';
import { ThousandBombsAndGrenadesRoutingModule } from './thousand-bombs-and-grenades-routing.module';

@NgModule({
  declarations: [ThousandBombsAndGrenadesComponent],
  imports: [CoreModule, ThemeSharedModule, ThousandBombsAndGrenadesRoutingModule],
  exports: [ThousandBombsAndGrenadesComponent],
})
export class ThousandBombsAndGrenadesModule {
  static forChild(): ModuleWithProviders<ThousandBombsAndGrenadesModule> {
    return {
      ngModule: ThousandBombsAndGrenadesModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ThousandBombsAndGrenadesModule> {
    return new LazyModuleFactory(ThousandBombsAndGrenadesModule.forChild());
  }
}
