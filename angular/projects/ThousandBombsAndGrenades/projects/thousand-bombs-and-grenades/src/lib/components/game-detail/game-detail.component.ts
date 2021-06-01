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
    playerName: string;

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

    startGame(): void {
        this.gameService.start(this.game.id).subscribe();
    }

    endGame(): void {
        this.gameService.end(this.game.id).subscribe();
    }

    addPlayer(): void {
        this.gameService.addPlayer(this.game.id, { name: this.playerName }).subscribe(() => {
            this.playerName = null;
        })
    }

    // drawCard(): void {
    //     let playerTurn = this.lastPlayerTurn();
    //     if (!playerTurn) return;

    //     this.playerTurnService.drawCard(playerTurn.id).subscribe();
    // }

    private getGameDetail(id: string): void {
        this.gameService.get(id).subscribe((game: GameDto) => {
            this.game = game;
        });
    }

    // private lastPlayerTurn(): PlayerTurnDto {
    //     return this.game.playerTurns[this.game.playerTurns.length - 1];
    // }
}
