using System;
using System.Collections.Generic;
using System.Linq;
using ThousandBombsAndGrenades.Deck;
using ThousandBombsAndGrenades.Players;
using ThousandBombsAndGrenades.PlayerTurns;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.Games
{
    public class Game : FullAuditedAggregateRoot<Guid>
    {
        public virtual DateTime? StartDate { get; private set; }
        public virtual DateTime? EndDate { get; private set; }

        public virtual DeckOfCards DeckOfCards { get; set; }

        public virtual List<Player> Players { get; private set; }
        public virtual List<PlayerTurn> PlayerTurns { get; private set; }

        private Game()
        {
        }

        public Game(Guid id)
        {
            Id = id;
            DeckOfCards = new DeckOfCards();
            Players = new List<Player>();
            PlayerTurns = new List<PlayerTurn>();
        }

        /// <summary>
        /// To start the game.
        /// </summary>
        public void Start()
        {
            // A game can't start without players
            if (!Players.Any())
            {
                throw new GameCantStartWithoutPlayersException();
            }

            // A game must be played with at least x players
            if (Players.Count < GameConsts.MinPlayerCount)
            {
                throw new GameCantStartWithoutNumberOfPlayersException(GameConsts.MinPlayerCount);
            }

            // A game can only be played with max of x players
            if (Players.Count > GameConsts.MaxPlayerCount)
            {
                throw new GameCantStartWithMoreThanXPlayersException(GameConsts.MaxPlayerCount);
            }

            // Update the start date
            StartDate = DateTime.Now;

            // Select first player
            NextPlayerTurn();
        }

        public void NextPlayerTurn()
        {
            PlayerTurn playerTurn = new PlayerTurn();
            playerTurn.GameId = Id;
            playerTurn.Game = this;

            // First player's turn
            if (!PlayerTurns.Any())
            {
                Player firstPlayer = Players.OrderBy(x => x.SortOrder).First();
                playerTurn.PlayerId = firstPlayer.Id;
                playerTurn.Player = firstPlayer;
            }
            else
            {
                PlayerTurn lastTurn = PlayerTurns.Last();
                Player player = Players.OrderBy(x => x.SortOrder).First(x => x.Id == lastTurn.PlayerId);
                int playerIndex = Players.IndexOf(player);
                playerIndex++;
                if (playerIndex >= Players.Count)
                {
                    playerIndex = 0;
                }

                playerTurn.PlayerId = Players[playerIndex].Id;
                playerTurn.Player = Players[playerIndex];
            }

            PlayerTurns.Add(playerTurn);
        }

        public void PlayersTurnEnded()
        {
            NextPlayerTurn();
        }

        /// <summary>
        /// To end the game.
        /// </summary>
        public void End()
        {
            this.EndDate = DateTime.Now;
        }

        /// <summary>
        /// To add a player to the game.
        /// </summary>
        /// <param name="name">The player's name</param>
        public void AddPlayer(string name)
        {
            // We can't add players when the game is already finished
            if (IsFinished())
            {
                throw new GameIsFinishedException();
            }

            // We can't add players when the game is already started
            if (HasStarted())
            {
                throw new GameHasAlreadyStartedException();
            }

            // Check if player is already added to the game
            if (Players.Any(x => x.Name.ToLower() == name.ToLower()))
            {
                // If the player is already added, we don't need to add him again
                return;
            }

            // Maximum number of players
            if (Players.Count >= GameConsts.MaxPlayerCount)
            {
                throw new GameMaxPlayerCountReachedException(GameConsts.MaxPlayerCount);
            }

            // Add the player to the game
            Players.Add(new Player(Guid.NewGuid(), name));
        }

        /// <summary>
        /// Removes a player from the game.
        /// </summary>
        /// <param name="playerId">The player's ID</param>
        public void RemovePlayer(Guid playerId)
        {
            // We can't add players when the game is already finished
            if (IsFinished())
            {
                throw new GameIsFinishedException();
            }

            // We can't add players when the game is already started
            if (HasStarted())
            {
                throw new GameHasAlreadyStartedException();
            }

            // Remove the player from the game
            Player player = Players.FirstOrDefault(x => x.Id == playerId);
            if (player != null)
            {
                Players.Remove(player);
            }
        }

        public bool HasStarted()
        {
            return StartDate.HasValue;
        }

        public bool IsFinished()
        {
            return EndDate.HasValue;
        }
    }
}
