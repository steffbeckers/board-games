import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';

import { GameDetailComponent } from './components/game-detail/game-detail.component';
import { GamesListComponent } from './components/games-list/games-list.component';
import { ThousandBombsAndGrenadesComponent } from './components/thousand-bombs-and-grenades.component';
import { ThousandBombsAndGrenadesRoutingModule } from './thousand-bombs-and-grenades-routing.module';

@NgModule({
  declarations: [ThousandBombsAndGrenadesComponent, GamesListComponent, GameDetailComponent],
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
