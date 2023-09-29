using System;

public class GameControllerSettings
{
    [Flags]
    public enum Difficulty
    {
        Easy = 1,
        Medium = 2,
        Hard = 4
    }

    [Serializable]
    public enum GameMode
    {
        Single,
        Double
    }

    public Difficulty selectedDifficulty = Difficulty.Easy;
    public GameMode selectedGameMode = GameMode.Single;
    private static GameControllerSettings instance;

    public static GameControllerSettings Instance
    {
        get
        {
            if (instance == null)
                instance = new GameControllerSettings();

            return instance;
        }
    }

    public void setDifficulty(Difficulty newDif)
    {
        selectedDifficulty = newDif;
    }

    public void setGameMode(GameMode newGame)
    {
        selectedGameMode = newGame;
    }

    public bool IsMultiPlayer()
    {
        return selectedGameMode == GameMode.Double;
    }
}