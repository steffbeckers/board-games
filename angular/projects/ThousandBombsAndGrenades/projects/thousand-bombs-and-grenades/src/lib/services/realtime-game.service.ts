import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({providedIn: 'root'})
export class RealtimeGameService {
    private connection: signalR.HubConnection;

    constructor() {}

    connect(gameId: string): Promise<void> {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(`https://localhost:44385/api/games/thousand-bombs-and-grenades/hubs/game?gameId=${gameId}`)
            .withAutomaticReconnect()
            .build();
        
        return this.connection.start();
    }

    listenForGameUpdates(cb): void {
        this.connection.on(`GameUpdate`, (game) => {
            cb(game);
        })
    }
}