using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Deck;
using ThousandBombsAndGrenades.Deck.Cards;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Dice.Sides;
using ThousandBombsAndGrenades.Games;
using Xunit;
using Shouldly;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurn_Tests : ThousandBombsAndGrenadesDomainTestBase
    {
        [Fact]
        public async Task Should_Calculate_Points_Of_2_Golden_Coin_Dice()
        {
            Game game = new Game()
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new SkullCard();

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });

            playerTurn.CalculatePoints().ShouldBe(200);
        }

        [Fact]
        public async Task Should_Calculate_Points_Of_2_Golden_Coin_Dice_And_3_Diamond_Dice()
        {
            Game game = new Game()
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new SkullCard();

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });

            playerTurn.CalculatePoints().ShouldBe(600);
        }

        [Fact]
        public async Task Should_Calculate_Points_Of_2_Golden_Coin_Dice_And_5_Diamond_Dice()
        {
            Game game = new Game()
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new SkullCard();

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });

            playerTurn.CalculatePoints().ShouldBe(1200);
        }

        [Fact]
        public async Task Should_Calculate_Points_Of_3_Golden_Coin_Dice()
        {
            Game game = new Game()
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new SkullCard();

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new GoldenCoinSide()
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });

            playerTurn.CalculatePoints().ShouldBe(400);
        }

        [Fact]
        public async Task Should_Calculate_Points_Of_4_Diamond_Dice()
        {
            Game game = new Game()
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new SkullCard();

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new MonkeySide()
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiamondSide()
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiamondSide()
            });

            playerTurn.CalculatePoints().ShouldBe(600);
        }
    }
}
