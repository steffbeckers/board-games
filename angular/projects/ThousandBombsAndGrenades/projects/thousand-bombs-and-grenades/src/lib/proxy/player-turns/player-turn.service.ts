import type { PlayerTurnDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PlayerTurnService {
  apiName = 'Default';

  drawCard = (id: string) =>
    this.restService.request<any, PlayerTurnDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/player-turns/${id}/draw-card`,
    },
    { apiName: this.apiName });

  end = (id: string) =>
    this.restService.request<any, PlayerTurnDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/player-turns/${id}/end`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, PlayerTurnDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/player-turns/${id}`,
    },
    { apiName: this.apiName });

  pickDice = (id: string, index: number) =>
    this.restService.request<any, PlayerTurnDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/player-turns/${id}/pick-dice`,
      params: { index },
    },
    { apiName: this.apiName });

  returnDice = (id: string, index: number) =>
    this.restService.request<any, PlayerTurnDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/player-turns/${id}/return-dice`,
      params: { index },
    },
    { apiName: this.apiName });

  rollDice = (id: string) =>
    this.restService.request<any, PlayerTurnDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/player-turns/${id}/roll-dice`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
