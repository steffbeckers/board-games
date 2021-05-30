import type { FullAuditedEntityDto } from '@abp/ng.core';
import type { PlayerDto } from '../players/models';
import type { PlayerTurnDto } from '../player-turns/models';

export interface GameDto extends FullAuditedEntityDto<string> {
  startDate?: string;
  endDate?: string;
  players: PlayerDto[];
  playerTurns: PlayerTurnDto[];
}
