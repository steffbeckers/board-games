import { PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { GameDto, GameService } from '../../proxy/games';

@Component({
  selector: 'lib-games-list',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.css']
})
export class GamesListComponent implements OnInit {
    games: PagedResultDto<GameDto>;

    constructor(private gameService: GameService, private router: Router, private route: ActivatedRoute) { }

    ngOnInit(): void {
        this.getGamesList();
    }

    getGamesList(): void {
        this.gameService.getList().subscribe((games: PagedResultDto<GameDto>) => {
            this.games = games;
        });
    }

    startNewGame(): void {
        this.gameService.create().subscribe((game: GameDto) => {
            this.router.navigate([game.id], { relativeTo: this.route })
        })
    }
}
