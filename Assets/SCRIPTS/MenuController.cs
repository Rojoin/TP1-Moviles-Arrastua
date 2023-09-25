using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public void SetSinglePlayer()
    {
        GameControllerSettings.Instance.setGameMode(GameControllerSettings.GameMode.Single);
    }
    public void SetDoublePlayer()
    {
        GameControllerSettings.Instance.setGameMode(GameControllerSettings.GameMode.Double);
    }
    public void SetEasyDifficulty()
    {
        GameControllerSettings.Instance.setDifficulty(GameControllerSettings.Difficulty.Easy);
    }
    public void SetMediumDifficulty()
    {
        GameControllerSettings.Instance.setDifficulty(GameControllerSettings.Difficulty.Medium);
    } 
    public void SetHardDifficulty()
    {
        GameControllerSettings.Instance.setDifficulty(GameControllerSettings.Difficulty.Hard);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("ESCENAS/conduccion9");
    }
}