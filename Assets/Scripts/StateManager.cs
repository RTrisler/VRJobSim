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

    // state variables
    public bool IsOnPlatform = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        // if no nuts removed and player steps on platform TODOTODOTODO
        if (TireLeft_Manager.CurrentNumberOfNuts == 5 )
        {
            UIManager.Step1Off();
            UIManager.Step2On();
        }
    }

    public void ApproachedPlatform()
    {
        IsOnPlatform = true;
    }
}
