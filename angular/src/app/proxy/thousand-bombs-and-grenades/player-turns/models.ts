import type { AuditedEntityDto } from '@abp/ng.core';
import type { PlayerDto } from '../players/models';
import type { DiceDto, DiceRollDto } from '../dice/models';

export interface PlayerTurnDto extends AuditedEntityDto<string> {
  gameId?: string;
  playerId?: string;
  player: PlayerDto;
  cardName?: string;
  cardDescription?: string;
  cardPoints: number;
  cardCount: number;
  diceRolls: DiceRollDto[];
  pickedDice: DiceDto[];
  points: number;
  skullIslandActive: boolean;
}
