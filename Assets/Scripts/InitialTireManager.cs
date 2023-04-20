using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InitialTireManager : MonoBehaviour
{
    public int CurrentNumberOfNuts;
    public Vector3 PlacementPosition;

    int TotalNumberOfNuts = 5;
    XRGrabInteractable TireGrabbable;
    Rigidbody TireRigidbody;

    StateManager StateManager;



    void Start()
    {
        CurrentNumberOfNuts = TotalNumberOfNuts;
        TireGrabbable = GetComponent<XRGrabInteractable>();
        TireRigidbody = GetComponent<Rigidbody>();
        PlacementPosition = GetComponent<Transform>().position;

        StateManager = GameObject.Find("StateController").GetComponent<StateManager>();
        // Set initial state
        /*TireGrabbable.enabled = false;
        TireRigidbody.isKinematic = true;
        TireRigidbody.useGravity = false;*/
    }

    void Update()
    {
        if (CurrentNumberOfNuts == 0)
        {
            if (gameObject.tag == "TireLeft")
            {
                StateManager.IsTireLeftDrained = true;
            }
            Debug.Log("NUTS DRAINED");
            TireGrabbable.enabled = true;
            TireRigidbody.isKinematic = false;
            TireRigidbody.useGravity = true;
        }
    }
}
