using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using ThousandBombsAndGrenades.Cards;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Players;
using Xunit;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurn_Tests : ThousandBombsAndGrenadesDomainTestBase, IDisposable
    {
        private readonly Game _game;

        public PlayerTurn_Tests()
        {
            _game = new Game(Guid.NewGuid());
            _game.AddPlayer(new Player(Guid.NewGuid(), "Player 1"));
            _game.AddPlayer(new Player(Guid.NewGuid(), "Player 2"));
            _game.Start();
        }

        [Fact]
        public void Should_Draw_A_Card()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;

            playerTurn.Card.ShouldBeNull();
            playerTurn.DrawCard();
            playerTurn.Card.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Roll_Dice()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.LastDiceRoll.ShouldBeNull();
            playerTurn.RollDice();
            playerTurn.LastDiceRoll.ShouldNotBeNull();
            (playerTurn.LastDiceRoll.Dice.Count + playerTurn.LastDiceRoll.Picked.Count).ShouldBe(GameConsts.DiceCount);
        }

        [Fact]
        public void Should_Roll_Dice_Multiple_Times()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.RollDice();

            if (playerTurn.LastDiceRoll.Dice.Count > 0)
            {
                playerTurn.RollDice();
                playerTurn.DiceRolls.Count.ShouldBe(2);
            }
            else
            {
                playerTurn.DiceRolls.Count.ShouldBe(1);
            }
        }

        [Fact]
        public void Should_Calculate_Points_Of_2_Golden_Coin_Dice()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(200);
        }

        [Fact]
        public void Should_Calculate_Points_Of_2_Golden_Coin_Dice_And_3_Diamond_Dice()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(600);
        }

        [Fact]
        public void Should_Calculate_Points_Of_2_Golden_Coin_Dice_And_5_Diamond_Dice()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(1200);
        }

        [Fact]
        public void Should_Calculate_Points_Of_3_Golden_Coin_Dice()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(400);
        }

        [Fact]
        public void Should_Calculate_Points_Of_4_Diamond_Dice()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(600);
        }

        [Fact]
        public void Should_Calculate_Points_When_Pirate_Card_Is_Drawn()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Pirate };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(1200);
        }

        [Fact]
        public void Should_Calculate_Points_Dice_That_Add_Up_To_Full_Treasure_Chest()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Monkey
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Monkey
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Monkey
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.GoldenCoin,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(1200);
        }

        [Fact]
        public void Should_End_After_No_Skull_Side_Dice_Are_Rolled_When_Skull_Island_Is_Active()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card() { Name = CardConsts.Skull, Count = 2 };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.GoldenCoin,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Skull
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Skull
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Skull
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Skull
                }
            });

            playerTurn.SkullIslandActive = true;

            playerTurn.RollDice();

            DiceRoll lastDiceRoll = playerTurn.LastDiceRoll;

            bool lastDiceRollContainsSkullDice = lastDiceRoll.Picked.FirstOrDefault(x => x.FacingUp.Name == DiceSideConsts.Skull) != null;

            if (lastDiceRollContainsSkullDice)
            {
                playerTurn.HasEnded().ShouldBeFalse();
            }
            else
            {
                playerTurn.HasEnded().ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_Calculate_Points_When_Pirate_Ship_Card_Is_Active_And_Swords_Were_Rolled()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card()
            {
                Name = CardConsts.PirateShip,
                DisplayName = "Pirate ship 3 swords",
                Points = 500,
                Count = 3
            };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Swords
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Swords
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Swords
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Swords
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Swords
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Swords
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(700);
        }

        [Fact]
        public void Should_Calculate_Points_When_Pirate_Ship_Card_Is_Active_And_Swords_Were_Not_Rolled()
        {
            PlayerTurn playerTurn = _game.CurrentPlayerTurn;
            playerTurn.Card = new Card()
            {
                Name = CardConsts.PirateShip,
                DisplayName = "Pirate ship 3 swords",
                Points = 500,
                Count = 3
            };

            playerTurn.DiceRolls.Add(new DiceRoll()
            {
                Dice = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Monkey
                        }
                    }
                },
                Picked = new List<Dice.Dice>()
                {
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    },
                    new Dice.Dice()
                    {
                        FacingUp = new DiceSide()
                        {
                            Name = DiceSideConsts.Diamond,
                            Points = 100
                        }
                    }
                }
            });

            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });
            playerTurn.PickedDice.Add(new Dice.Dice()
            {
                FacingUp = new DiceSide()
                {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                }
            });

            playerTurn.CalculatePoints().ShouldBe(-500);
        }
    }
}
