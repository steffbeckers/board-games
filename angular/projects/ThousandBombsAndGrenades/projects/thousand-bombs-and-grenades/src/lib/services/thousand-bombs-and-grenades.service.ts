import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class ThousandBombsAndGrenadesService {
  apiName = 'ThousandBombsAndGrenades';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/ThousandBombsAndGrenades/sample' },
      { apiName: this.apiName }
    );
  }
}
