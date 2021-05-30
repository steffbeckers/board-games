
export interface DiceDto {
  facingUp?: string;
  points?: number;
}

export interface DiceRollDto {
  dice: DiceDto[];
  picked: DiceDto[];
}
