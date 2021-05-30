import type { AuditedEntityDto } from '@abp/ng.core';

export interface PlayerDto extends AuditedEntityDto<string> {
  name: string;
}
