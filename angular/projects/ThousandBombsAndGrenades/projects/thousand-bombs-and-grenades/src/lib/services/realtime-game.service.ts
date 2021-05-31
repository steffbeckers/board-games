import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({providedIn: 'root'})
export class RealtimeGameService {
    connection: signalR.HubConnection;

    constructor() {}

    connect(): Promise<void> {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:44385/api/games/thousand-bombs-and-grenades/hubs/game")
            .withAutomaticReconnect()
            .build();
        
        return this.connection.start();
    }

    listenForGameUpdates(gameId, cb): void {
        // TODO: Use gameId
        this.connection.on(`GameUpdate`, (game) => {
            cb(game);
        })
    }
}