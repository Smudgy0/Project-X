using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public PlayerHealthScript PHS;

    public GameObject ContinueScreen;

    public int ContinueTimer;
    public TMP_Text ContinueTimerText;

    public TMP_Text PLivesText;

    private void Awake()
    {
        PHS = FindAnyObjectByType<PlayerHealthScript>();
    }

    public void Countdown()
    {
        ContinueTimer -= 1;
        if(ContinueTimer == 0)
        {
            Lose();
        }
    }

    public void OpenDeathScreenUi()
    {
        if(PHS.PLives == 0) { Lose(); return; }
        ContinueTimer = 10;
        ContinueScreen.SetActive(true);
        InvokeRepeating("Countdown", 1, 1);
    }

    public void Continue()
    {
        ContinueScreen.SetActive(false);
        PHS.PLives -= 1;
        PHS.IsDead = false;
        PHS.playerhealth = PHS.maxPlayerhealth;
        PHS.transform.position = PHS.RespawnPoint.position;
    }

    public void Lose()
    {
        ContinueScreen.SetActive(false);
        PHS.IsDead = false;
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        ContinueTimerText.text = ContinueTimer.ToString();
        PLivesText.text = "Player Lives: X" + PHS.PLives.ToString();
    }

    public void OnContinue(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Continue();
        }
    }
}
