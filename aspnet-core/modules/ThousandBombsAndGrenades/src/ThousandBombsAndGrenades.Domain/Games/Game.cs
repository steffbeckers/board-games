using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThousandBombsAndGrenades.Deck;
using ThousandBombsAndGrenades.Players;
using ThousandBombsAndGrenades.PlayerTurns;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.Games
{
    public class Game : FullAuditedAggregateRoot<Guid>
    {
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        // TODO: Private games
        public bool Private { get; private set; }

        public DeckOfCards DeckOfCards { get; set; }
        public PlayerTurn CurrentPlayerTurn
        {
            get
            {
                return PlayerTurns?.OrderByDescending(x => x.CreationTime).FirstOrDefault();
            }
        }

        public ICollection<Player> Players { get; private set; }
        public ICollection<PlayerTurn> PlayerTurns { get; private set; }

        public Game(Guid id)
        {
            Id = id;
            DeckOfCards = new DeckOfCards();
            Players = new Collection<Player>();
            PlayerTurns = new Collection<PlayerTurn>();
        }

        private Game() { }

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
            GiveTurnToNextPlayer();
        }

        public void GiveTurnToNextPlayer()
        {
            PlayerTurn playerTurn = new PlayerTurn(Guid.NewGuid(), Id);
            playerTurn.Game = this;

            if (!PlayerTurns.Any())
            {
                // First player's turn
                Player firstPlayer = Players.OrderBy(x => x.SortOrder).First();
                playerTurn.PlayerId = firstPlayer.Id;
                playerTurn.Player = firstPlayer;
            }
            else
            {
                // Next player's turn
                int currentPlayersIndex = Players.OrderBy(x => x.SortOrder).ToList().IndexOf(Players.Where(x => x.Id == CurrentPlayerTurn.PlayerId).First());
                int nextPlayerIndex = currentPlayersIndex + 1;
                if (nextPlayerIndex >= Players.Count)
                {
                    nextPlayerIndex = 0;
                }

                Player nextPlayer = Players.OrderBy(x => x.SortOrder).ElementAt(nextPlayerIndex);
                playerTurn.PlayerId = nextPlayer.Id;
                playerTurn.Player = nextPlayer;
            }

            PlayerTurns.Add(playerTurn);
        }

        public void PlayersTurnEnded()
        {
            PlayerTurn playerTurn = CurrentPlayerTurn;
            Player player = CurrentPlayerTurn.Player;

            if (playerTurn.SkullIslandActive)
            {
                // Subtract other player's points
                foreach (Player otherPlayer in Players.Where(x => x.Id != player.Id))
                {
                    otherPlayer.Points -= playerTurn.Points;
                }
            }
            else
            {
                // Add points to player
                player.Points += CurrentPlayerTurn.Points;
            }

            GiveTurnToNextPlayer();
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
        /// <param name="player">The player</param>
        public void AddPlayer(Player player)
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
            if (Players.Any(x => x.Name.ToLower() == player.Name.ToLower()))
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
            Players.Add(player);

            CalculatePlayersSortOrders();
        }

        /// <summary>
        /// Removes a player from the game.
        /// </summary>
        /// <param name="player">The player</param>
        public void RemovePlayer(Player player)
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
            Players.Remove(player);

            CalculatePlayersSortOrders();
        }

        private void CalculatePlayersSortOrders()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                Players.ElementAt(i).SortOrder = i + 1;
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
