using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseController : MonoBehaviour
{

    public GameObject wristUI;

    public bool activeWristUI = true;
    //InputAction 
    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleGamePause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayWristUI();
            //Time.TimeScale = 0;
        }
    }

    public void DisplayWristUI()
    {
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            Time.timeScale = 1;
        }
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
            Time.timeScale = 0;
        }
    }

    public void SaveGameState()
    {
        Debug.Log("Save Button Pressed");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
