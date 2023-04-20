using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseController : MonoBehaviour
{

    public GameObject wristUI;

    StateManager stateManager;
    UIManager uiM;

    public bool activeWristUI = true;
    //InputAction 
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("StateController").GetComponent<StateManager>();
        uiM = GameObject.Find("StateController").GetComponent<UIManager>();
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
        Debug.Log(ConvertToString(stateManager.CurrentState));
        // Save stuff from state manager
        PlayerPrefs.SetString("CurrentState", ConvertToString(stateManager.CurrentState));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGameState()
    {
        // get some player prefs
        string state = PlayerPrefs.GetString("CurrentState");
        stateManager.CurrentState = ConvertStringToState(state);

        switch(stateManager.CurrentState)
        {
            case StateManager.StepState.Step1:
                uiM.Step1On();
                uiM.Step2Off();
                uiM.Step3Off();
                uiM.Step4Off();
                uiM.Step5Off();
                break;
            case StateManager.StepState.Step2:
                uiM.Step1Off();
                uiM.Step2On();
                uiM.Step3Off();
                uiM.Step4Off();
                uiM.Step5Off();
                break;
            case StateManager.StepState.Step3:
                uiM.Step1Off();
                uiM.Step2Off();
                uiM.Step3On();
                uiM.Step4Off();
                uiM.Step5Off();
                break;
            case StateManager.StepState.Step4:
                uiM.Step1Off();
                uiM.Step2Off();
                uiM.Step3Off();
                uiM.Step4On();
                uiM.Step5Off();
                break;
            case StateManager.StepState.Step5:
                uiM.Step1Off();
                uiM.Step2Off();
                uiM.Step3Off();
                uiM.Step4Off();
                uiM.Step5On();
                break;
            default:
                break;
        }

    }

    string ConvertToString(StateManager.StepState state)
    {
        switch(state)
        {
            case StateManager.StepState.Step1:
                return "Step1";
                break;
            case StateManager.StepState.Step2:
                return "Step2";
                break;
            case StateManager.StepState.Step3:
                return "Step3";
                break;
            case StateManager.StepState.Step4:
                return "Step4";
                break;
            case StateManager.StepState.Step5:
                return "Step5";
                break;
            default:
                return "ERROR";
                break;
        }
    }

    StateManager.StepState ConvertStringToState(string state)
    {
        switch (state)
        {
            case "Step1":
                return StateManager.StepState.Step1;
                break;
            case "Step2":
                return StateManager.StepState.Step2;
                break;
            case "Step3":
                return StateManager.StepState.Step3;
                break;
            case "Step4":
                return StateManager.StepState.Step4;
                break;
            case "Step5":
                return StateManager.StepState.Step5;
                break;
            default:
            return StateManager.StepState.ERROR;
                break;
        }

    }
}
