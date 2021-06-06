import type { GameDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AddPlayerDto } from '../players/models';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  apiName = 'Default';

  addPlayer = (id: string, addPlayerDto: AddPlayerDto) =>
    this.restService.request<any, GameDto>({
      method: 'POST',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/players`,
      body: addPlayerDto,
    },
    { apiName: this.apiName });

  create = () =>
    this.restService.request<any, GameDto>({
      method: 'POST',
      url: '/api/games/thousand-bombs-and-grenades/games',
    },
    { apiName: this.apiName });

  drawCard = (id: string) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/draw-card`,
    },
    { apiName: this.apiName });

  end = (id: string) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/end`,
    },
    { apiName: this.apiName });

  endTurn = (id: string) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/end-turn`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}`,
    },
    { apiName: this.apiName });

  getList = () =>
    this.restService.request<any, PagedResultDto<GameDto>>({
      method: 'GET',
      url: '/api/games/thousand-bombs-and-grenades/games',
    },
    { apiName: this.apiName });

  join = (id: string) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/join`,
    },
    { apiName: this.apiName });

  pickDice = (id: string, index: number) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/pick-dice`,
      params: { index },
    },
    { apiName: this.apiName });

  removePlayer = (id: string, playerId: string) =>
    this.restService.request<any, GameDto>({
      method: 'DELETE',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/players/${playerId}`,
    },
    { apiName: this.apiName });

  returnDice = (id: string, index: number) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/return-dice`,
      params: { index },
    },
    { apiName: this.apiName });

  rollDice = (id: string) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/roll-dice`,
    },
    { apiName: this.apiName });

  start = (id: string) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/start`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
