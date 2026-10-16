using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSender : MonoBehaviour
{
    public int SceneToSendTo;
    public void SendToScene()
    {
        SceneManager.LoadScene(SceneToSendTo);
    }
}
