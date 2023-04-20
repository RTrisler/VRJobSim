using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    // References to initial tire game objects
    GameObject TireLeft_Initial;
    GameObject TireRight_Initial;
    GameObject ReplacementTire_1;
    GameObject ReplacementTire_2;
    GameObject ImpactWrench;

    GameObject TeleportPlatform;

    // References to tire manager scripts
    InitialTireManager TireLeft_Manager;
    InitialTireManager TireRight_Manager;
    ReplacementTireManager ReplacementTire1_Manager;
    ReplacementTireManager ReplacementTire2_Manager;
    UIManager UIManager;

    public enum StepState {
        Step1,
        Step2,
        Step3,
        Step4,
        Step5,
        Step6,
        ERROR
    }
    public StepState CurrentState;

    // state variables
    public bool IsOnPlatform = false;
    public bool IsAffixedToSpoke = false;
    public bool IsTireLeftDrained = false;
    public bool IsFastened = false;

    void Start()
    {
        // Stash internal game object references
        TireLeft_Initial = GameObject.FindGameObjectWithTag("TireLeft");
        TireRight_Initial = GameObject.FindGameObjectWithTag("TireRight");
        ReplacementTire_1 = GameObject.Find("ReplacementTire1");
        ReplacementTire_2 = GameObject.Find("ReplacementTire2");
        ImpactWrench = GameObject.Find("ImpactWrench");
        UIManager = gameObject.GetComponent<UIManager>();
        TeleportPlatform = GameObject.Find("TeleportPlatform");
        // Stash internal tire manager references
        TireLeft_Manager = TireLeft_Initial.GetComponent<InitialTireManager>();
        TireRight_Manager = TireRight_Initial.GetComponent<InitialTireManager>();
        ReplacementTire1_Manager = ReplacementTire_1.GetComponent<ReplacementTireManager>();
        ReplacementTire2_Manager = ReplacementTire_2.GetComponent<ReplacementTireManager>();
        CurrentState = StepState.Step1;
    }

    // Update is called once per frame
    void Update()
    {
        // if you are on platform
        if (IsOnPlatform == true)
        {
            // if no nuts removed and player steps on platform TODOTODOTODO
            // Approach with wrench -> remove nuts from tire
            if (TireLeft_Manager.CurrentNumberOfNuts == 5 && CurrentState == StepState.Step1)// && TireRight_Manager.CurrentNumberOfNuts != 0)
            {
                UIManager.Step1Off();
                UIManager.Step2On();
                CurrentState = StepState.Step2;
            }
        }

        // Remove nuts from tire -> put replacement on
        if (IsTireLeftDrained && CurrentState == StepState.Step2)
        {
            Debug.Log("HIT STEP2->STEP3 CONDITIONAL");
            UIManager.Step2Off();
            UIManager.Step3On();
            CurrentState = StepState.Step3;
        }

        if (IsAffixedToSpoke && CurrentState == StepState.Step3)
        {
            UIManager.Step3Off();
            UIManager.Step4On();
            CurrentState = StepState.Step4;
        }

        if (IsFastened && CurrentState == StepState.Step4)
        {
            UIManager.Step4Off();
            UIManager.Step5On();
            CurrentState = StepState.Step5;
        }
        Debug.Log("Current state: " + CurrentState);
    }



    public void ApproachedPlatform()
    {
        IsOnPlatform = true;
    }
}
