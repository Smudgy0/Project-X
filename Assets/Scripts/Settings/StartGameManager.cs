using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] int selectedLevel = 1;
    
    public void LoadGame()
    {
        SceneManager.LoadScene(selectedLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
