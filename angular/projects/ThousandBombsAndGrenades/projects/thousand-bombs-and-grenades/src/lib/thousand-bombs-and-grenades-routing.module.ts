import { NgModule } from '@angular/core';
import { DynamicLayoutComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { ThousandBombsAndGrenadesComponent } from './components/thousand-bombs-and-grenades.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: DynamicLayoutComponent,
    children: [
      {
        path: '',
        component: ThousandBombsAndGrenadesComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThousandBombsAndGrenadesRoutingModule {}
