import { LazyModuleFactory } from '@abp/ng.core';
import { ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { GameDetailComponent } from './components/game-detail/game-detail.component';
import { GamesListComponent } from './components/games-list/games-list.component';
import { ThousandBombsAndGrenadesComponent } from './components/thousand-bombs-and-grenades.component';
import { RealtimeGameService } from './services/realtime-game.service';
import { ThousandBombsAndGrenadesRoutingModule } from './thousand-bombs-and-grenades-routing.module';

@NgModule({
  declarations: [ThousandBombsAndGrenadesComponent, GamesListComponent, GameDetailComponent],
  imports: [SharedModule, ThousandBombsAndGrenadesRoutingModule]
})
export class ThousandBombsAndGrenadesModule {
  static forChild(): ModuleWithProviders<ThousandBombsAndGrenadesModule> {
    return {
      ngModule: ThousandBombsAndGrenadesModule,
      providers: [RealtimeGameService],
    };
  }

  static forLazy(): NgModuleFactory<ThousandBombsAndGrenadesModule> {
    return new LazyModuleFactory(ThousandBombsAndGrenadesModule.forChild());
  }
}
