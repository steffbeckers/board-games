import { PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';

import { GameService } from '../../../../../../../../src/app/proxy/thousand-bombs-and-grenades/games/game.service';
import { GameDto } from '../../../../../../../../src/app/proxy/thousand-bombs-and-grenades/games/models';

@Component({
  selector: 'lib-games-list',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.css']
})
export class GamesListComponent implements OnInit {
    games: PagedResultDto<GameDto>;

    constructor(private gameService: GameService) { }

    ngOnInit(): void {
        this.gameService.getList().subscribe((games) => {
            this.games = games;
        });
    }
}
