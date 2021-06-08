import type { AuditedEntityDto } from '@abp/ng.core';

export interface PlayerDto extends AuditedEntityDto<string> {
  name: string;
  points: number;
  sortOrder: number;
  userId?: string;
}
