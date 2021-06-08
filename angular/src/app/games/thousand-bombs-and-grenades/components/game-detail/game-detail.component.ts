import { ConfigStateService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    myTurn: boolean;

    constructor(
        private config: ConfigStateService,
        private router: Router, private route: ActivatedRoute, private gameService: GameService, private realtimeGameService: RealtimeGameService) {}

    ngOnInit(): void {
        this.route.paramMap.subscribe((routeParams) => {
            const gameId = routeParams.get('id');
            this.getGameDetail(gameId);
        });
    }

    private getGameDetail(id: string): void {
        this.gameService.get(id).subscribe(
            (game: GameDto) => {
                this.game = game;
                this.setMyTurn();

                this.realtimeGameService.connect(this.game.id).then(() => {
                    this.realtimeGameService.listenForGameUpdates((game: GameDto) => {
                        this.game = game;
                        this.setMyTurn();
                    })
                });
            },
            () => {
                this.router.navigateByUrl("/1000-bombs-and-grenades");
            }
        );
    }

    private setMyTurn(): void {
        this.myTurn = this.game.currentPlayerTurn?.player.userId === this.config.getOne("currentUser").id;
    }

    join(): void {
        this.gameService.join(this.game.id).subscribe();
    }
    
    addPlayer(): void {
        if (!this.playerName) return;
        this.gameService.addPlayer(this.game.id, { name: this.playerName }).subscribe(() => {
            this.playerName = null;
        })
    }

    removePlayer(id: string): void {
        this.gameService.removePlayer(this.game.id, id).subscribe();
    }

    start(): void {
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
    
    endTurn(): void {
        this.gameService.endTurn(this.game.id).subscribe();
    }

    end(): void {
        this.gameService.end(this.game.id).subscribe();
    }
}
