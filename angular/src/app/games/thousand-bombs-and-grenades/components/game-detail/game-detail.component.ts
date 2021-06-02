import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GameDto, GameService } from 'src/app/proxy/thousand-bombs-and-grenades/games';

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

    private getGameDetail(id: string): void {
        this.gameService.get(id).subscribe((game: GameDto) => {
            this.game = game;
        });
    }
    
    addPlayer(): void {
        this.gameService.addPlayer(this.game.id, { name: this.playerName }).subscribe(() => {
            this.playerName = null;
        })
    }

    startGame(): void {
        this.gameService.start(this.game.id).subscribe();
    }

    drawCard(): void {
        this.gameService.drawCard(this.game.id).subscribe();
    }

    rollDice(): void {
        this.gameService.rollDice(this.game.id).subscribe();
    }

    pickDice(index: number): void {
        this.gameService.pickDice(this.game.id, index).subscribe();
    }

    returnDice(index: number): void {
        this.gameService.returnDice(this.game.id, index).subscribe();
    }

    endGame(): void {
        this.gameService.end(this.game.id).subscribe();
    }
}
