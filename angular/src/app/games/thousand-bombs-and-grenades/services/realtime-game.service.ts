import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

@Injectable()
export class RealtimeGameService {
    private connection: signalR.HubConnection;

    constructor() {}

    connect(gameId: string): Promise<void> {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(`${environment.apis.default.url}/api/games/thousand-bombs-and-grenades/hubs/game?gameId=${gameId}`)
            .withAutomaticReconnect()
            .build();
        
        return this.connection.start();
    }

    listenForGameUpdates(cb): void {
        this.connection.on(`GameUpdate`, (game) => {
            cb(game);
        })
    }

    stopListeningForGameUpdates(): void {
        this.connection.off("GameUpdate");
    }
}