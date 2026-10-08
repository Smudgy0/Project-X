using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public PlayerHealthScript PHS;
    public PlayerMovement PM;

    public GameObject ContinueScreen;

    public int ContinueTimer;
    public TMP_Text ContinueTimerText;

    public TMP_Text PLivesText;

    public Image CharIcon;
    private void Awake()
    {
        PHS = FindAnyObjectByType<PlayerHealthScript>();
        PM = FindAnyObjectByType<PlayerMovement>();
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
        PM.isDead = true;
        if(PHS.PLives == 0) { Lose(); return; }
        ContinueTimer = 10;
        ContinueScreen.SetActive(true);
        InvokeRepeating("Countdown", 1, 1);
    }

    public void Continue()
    {
        PM.isDead = false;
        CancelInvoke();
        ContinueTimer = 10;
        ContinueScreen.SetActive(false);
        PHS.PLives -= 1;
        PHS.playerhealth = PHS.maxPlayerhealth;
        PHS.transform.position = PHS.RespawnPoint.position;
    }

    public void Lose()
    {
        CancelInvoke();
        ContinueTimer = 10;
        ContinueScreen.SetActive(false);
        SceneManager.LoadScene(0);
        PM.isDead = false;
    }

    private void Update()
    {
        ContinueTimerText.text = ContinueTimer.ToString();
        PLivesText.text = "Player Lives: X" + PHS.PLives.ToString();
    }

    public void OnContinue(InputAction.CallbackContext value)
    {
        if (PM.isDead == false) { return; }
        if (value.performed)
        {
            Continue();
        }
    }

    public void ChangeIcon(Sprite InputIcon)
    {
        CharIcon.sprite = InputIcon;
    }
}
