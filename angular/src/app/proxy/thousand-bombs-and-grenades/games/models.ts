import type { FullAuditedEntityDto } from '@abp/ng.core';
import type { PlayerTurnDto } from '../player-turns/models';
import type { PlayerDto } from '../players/models';

export interface GameDto extends FullAuditedEntityDto<string> {
  startDate?: string;
  endDate?: string;
  currentPlayerTurn: PlayerTurnDto;
  players: PlayerDto[];
  playerTurns: PlayerTurnDto[];
}
