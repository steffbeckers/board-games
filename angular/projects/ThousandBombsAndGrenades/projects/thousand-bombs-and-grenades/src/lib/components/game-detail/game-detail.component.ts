import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { GameDto, GameService } from '../../proxy/games';

@Component({
  selector: 'lib-game-detail',
  templateUrl: './game-detail.component.html',
  styleUrls: ['./game-detail.component.css']
})
export class GameDetailComponent implements OnInit {
    game: GameDto;

    constructor(private route: ActivatedRoute, private gameService: GameService) {}

    ngOnInit(): void {
        this.route.paramMap.subscribe((routeParams) => {
            const gameId = routeParams.get('id');
            this.getGameDetail(gameId);
        });
    }

    private getGameDetail(id: string): void {
        this.gameService.get(id).subscribe((game: GameDto) => {
            this.game = game;
        });
    }
}
