using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReplacementTireManager : MonoBehaviour
{
    public int CurrentNumberOfNutsFastened;

    [SerializeField]
    Transform LeftTirePlacementTransform;
    [SerializeField]
    Transform RightTirePlacementTransform;
    int TotalNumberOfNuts = 5;
    bool IsFastened = false;
    XRGrabInteractable TireGrabbable;
    Rigidbody TireRigidbody;
    Vector3 LeftTirePlacementPosition;
    Quaternion LeftTirePlacementRotation;
    Vector3 RightTirePlacementPosition;
    Quaternion RightTirePlacementRotation;

    StateManager StateManager;



    void Start()
    {
        CurrentNumberOfNutsFastened = 0;
        TireRigidbody = GetComponent<Rigidbody>();
        TireGrabbable = GetComponent<XRGrabInteractable>();
        LeftTirePlacementPosition = LeftTirePlacementTransform.position;
        LeftTirePlacementRotation = LeftTirePlacementTransform.rotation;
        RightTirePlacementPosition = RightTirePlacementTransform.position;
        RightTirePlacementRotation = RightTirePlacementTransform.rotation;

        StateManager = GameObject.Find("StateController").GetComponent<StateManager>();
    }

    void OnTriggerEnter(Collider collider)
    {
        // Affix tire to spoke
        if (collider.gameObject.tag == "Spoke")
        {
            Debug.Log(gameObject.name + " came into contact with " + collider.gameObject.name);
            TireGrabbable.enabled = false;
            // Set tire transform centered on the spoke, disable gravity, enable isKinematic
            TireRigidbody.useGravity = false;
            TireRigidbody.isKinematic = true;
            if (collider.gameObject.name == "SpokeLeft")
            {
                gameObject.transform.position = LeftTirePlacementPosition;
                gameObject.transform.rotation = LeftTirePlacementRotation;
                StateManager.IsAffixedToSpoke = true;
            }
            else if (collider.gameObject.name == "SpokeRight")
            {
                gameObject.transform.position = RightTirePlacementPosition;
                gameObject.transform.rotation = RightTirePlacementRotation;
                StateManager.IsAffixedToSpoke = true;
            }
        }
    }

    void Update()
    {
        if (CurrentNumberOfNutsFastened == TotalNumberOfNuts)
        {
            IsFastened = true;
            StateManager.IsFastened = true;
            Debug.Log("Tire '" + gameObject.name + "' is fastened");
        }
    }

    public void PickUpReplacementTire()
    {
        // freeze shit / fuck w position/ whatever
        Debug.Log("Replacement tire picked up");
    }
}
