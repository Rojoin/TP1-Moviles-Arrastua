using UnityEngine;

public class DeactivateOnDifficulty : MonoBehaviour
{
    
    public GameControllerSettings.Difficulty deactivateOnThisDifficulty;

    private void Awake()
    {
        Debug.Log(GameControllerSettings.Instance.selectedDifficulty);
        if ((GameControllerSettings.Instance.selectedDifficulty & deactivateOnThisDifficulty) == GameControllerSettings.Instance.selectedDifficulty)
        {
            this.gameObject.SetActive(false);
        }
    }
}