import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GamesListComponent } from './components/games-list/games-list.component';
import { ThousandBombsAndGrenadesComponent } from './components/thousand-bombs-and-grenades.component';

const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: ThousandBombsAndGrenadesComponent,
        children: [
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
