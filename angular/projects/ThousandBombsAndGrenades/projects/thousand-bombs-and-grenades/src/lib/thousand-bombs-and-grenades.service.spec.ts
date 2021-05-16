import { TestBed } from '@angular/core/testing';

import { ThousandBombsAndGrenadesService } from './thousand-bombs-and-grenades.service';

describe('ThousandBombsAndGrenadesService', () => {
  let service: ThousandBombsAndGrenadesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ThousandBombsAndGrenadesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
