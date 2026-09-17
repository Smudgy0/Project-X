using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] int selectedLevel = 1;
    
    public void loadGame()
    {
        SceneManager.LoadScene(selectedLevel);
    }
}
