import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { GameDto } from '../../games/models';
import type { PlayerDto } from '../../players/models';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  apiName = 'Default';

  addPlayer = (id: string, playerDto: PlayerDto) =>
    this.restService.request<any, GameDto>({
      method: 'POST',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/players`,
      body: playerDto,
    },
    { apiName: this.apiName });

  create = () =>
    this.restService.request<any, GameDto>({
      method: 'POST',
      url: '/api/games/thousand-bombs-and-grenades/games',
    },
    { apiName: this.apiName });

  end = (id: string) =>
    this.restService.request<any, GameDto>({
      method: 'GET',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/end`,
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

  removePlayer = (id: string, playerId: string) =>
    this.restService.request<any, GameDto>({
      method: 'DELETE',
      url: `/api/games/thousand-bombs-and-grenades/games/${id}/players/${playerId}`,
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
