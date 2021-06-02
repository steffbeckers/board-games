import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GameDetailComponent } from './components/game-detail/game-detail.component';
import { GamesListComponent } from './components/games-list/games-list.component';
import { ThousandBombsAndGrenadesComponent } from './components/thousand-bombs-and-grenades.component';

const routes: Routes = [
    {
        path: '',
        component: ThousandBombsAndGrenadesComponent,
        children: [
            {
                path: ':id',
                component: GameDetailComponent
            },
            {
                path: '',
                component: GamesListComponent
            }
        ],
    },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThousandBombsAndGrenadesRoutingModule {}
