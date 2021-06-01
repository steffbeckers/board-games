import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { GameDto, GameService } from '../../proxy/games';
import { RealtimeGameService } from '../../services/realtime-game.service';

@Component({
  selector: 'lib-game-detail',
  templateUrl: './game-detail.component.html',
  styleUrls: ['./game-detail.component.css']
})
export class GameDetailComponent implements OnInit {
    game: GameDto;

    constructor(private route: ActivatedRoute, private gameService: GameService, private realtimeGameService: RealtimeGameService) {}

    ngOnInit(): void {
        this.route.paramMap.subscribe((routeParams) => {
            const gameId = routeParams.get('id');
            this.getGameDetail(gameId);

            this.realtimeGameService.connect(gameId).then(() => {
                this.realtimeGameService.listenForGameUpdates((game: GameDto) => {
                    console.log(game);
                    this.game = game;
                })
            });
        });
    }

    private getGameDetail(id: string): void {
        this.gameService.get(id).subscribe((game: GameDto) => {
            this.game = game;
        });
    }
}
