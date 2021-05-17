using System;
using System.Collections.Generic;
using System.Linq;
using ThousandBombsAndGrenades.Deck;
using ThousandBombsAndGrenades.GamePlayers;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.Games
{
    public class Game : FullAuditedAggregateRoot<Guid>
    {
        public virtual DateTime? StartDate { get; private set; }
        public virtual DateTime? EndDate { get; private set; }
        public virtual ICollection<GamePlayer> Players { get; private set; }
        public virtual Guid? TurnOfPlayerId { get; private set; }
        public virtual DeckOfCards DeckOfCards { get; set; }

        private Game()
        {
        }

        public Game(Guid id)
        {
            Id = id;
            this.Players = new List<GamePlayer>();
            this.DeckOfCards = new DeckOfCards();
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
            this.StartDate = DateTime.Now;

            // Select first player
            this.TurnOfPlayerId = Players.OrderBy(x => x.SortOrder).First().PlayerId;
        }

        /// <summary>
        /// To end the game.
        /// </summary>
        public void End()
        {
            this.EndDate = DateTime.Now;
            this.TurnOfPlayerId = null;
        }

        /// <summary>
        /// To add a player to the game.
        /// </summary>
        /// <param name="playerId">The player's ID</param>
        public void AddPlayer(Guid playerId)
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
            if (Players.Any(x => x.PlayerId == playerId))
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
            Players.Add(new GamePlayer()
            {
                GameId = Id,
                PlayerId = playerId,
                SortOrder = Players.Count + 1
            });
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
            GamePlayer gamePlayer = Players.FirstOrDefault(x => x.PlayerId == playerId);
            if (gamePlayer != null)
            {
                Players.Remove(gamePlayer);
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
