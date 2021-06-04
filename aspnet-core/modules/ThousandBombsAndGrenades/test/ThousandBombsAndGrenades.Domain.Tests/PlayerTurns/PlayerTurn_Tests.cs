using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using ThousandBombsAndGrenades.Cards;
using ThousandBombsAndGrenades.Deck;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Dice.Sides;
using ThousandBombsAndGrenades.Games;
using Xunit;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurn_Tests : ThousandBombsAndGrenadesDomainTestBase
    {
        [Fact]
        public void Should_Calculate_Points_Of_2_Golden_Coin_Dice()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new Card() { Name = CardConsts.Skull };

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
        public void Should_Calculate_Points_Of_2_Golden_Coin_Dice_And_3_Diamond_Dice()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new Card() { Name = CardConsts.Skull };

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
        public void Should_Calculate_Points_Of_2_Golden_Coin_Dice_And_5_Diamond_Dice()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new Card() { Name = CardConsts.Skull };

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
        public void Should_Calculate_Points_Of_3_Golden_Coin_Dice()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new Card() { Name = CardConsts.Skull };

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
        public void Should_Calculate_Points_Of_4_Diamond_Dice()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new Card() { Name = CardConsts.Skull };

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

        [Fact]
        public void Should_Calculate_Points_When_Pirate_Card_Is_Drawn()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new Card() { Name = CardConsts.Pirate };

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

            playerTurn.CalculatePoints().ShouldBe(1200);
        }

        [Fact]
        public void Should_Calculate_Points_Dice_That_Add_Up_To_Full_Treasure_Chest()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Picked = new List<Dice.Dice>()
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
                FacingUp = new MonkeySide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new MonkeySide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new MonkeySide()
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
                FacingUp = new GoldenCoinSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new GoldenCoinSide()
            });

            playerTurn.CalculatePoints().ShouldBe(1200);
        }

        [Fact]
        public void Should_End_After_No_Skull_Side_Dice_Are_Rolled_When_Skull_Island_Is_Active()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new DeckOfCards()
            };

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();

            playerTurn.Card = new Card() { Name = CardConsts.Skull, Count = 2 };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
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
                        FacingUp = new SkullSide()
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new SkullSide()
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new SkullSide()
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new SkullSide()
            });

            playerTurn.SkullIslandActive = true;

            playerTurn.RollDice();

            DiceRoll lastDiceRoll = playerTurn.LastDiceRoll;

            bool lastDiceRollContainsSkullDice = lastDiceRoll.Picked.FirstOrDefault(x => x.FacingUp.GetType() == typeof(SkullSide)) != null;

            if (lastDiceRollContainsSkullDice)
            {
                playerTurn.HasEnded().ShouldBeFalse();
            }
            else
            {
                playerTurn.HasEnded().ShouldBeTrue();
            }
        }
    }
}
