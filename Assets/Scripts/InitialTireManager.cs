using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InitialTireManager : MonoBehaviour
{
    public int CurrentNumberOfNuts;
    public Vector3 PlacementPosition;

    int TotalNumberOfNuts = 8;
    XRGrabInteractable TireGrabbable;
    Rigidbody TireRigidbody;

    void Start()
    {
        CurrentNumberOfNuts = TotalNumberOfNuts;
        TireGrabbable = GetComponent<XRGrabInteractable>();
        TireRigidbody = GetComponent<Rigidbody>();
        PlacementPosition = GetComponent<Transform>().position;
    }

    void Update()
    {
        if (CurrentNumberOfNuts == 0)
        {
            TireGrabbable.enabled = true;
            TireRigidbody.isKinematic = false;
            TireRigidbody.useGravity = true;
        }
    }
}
