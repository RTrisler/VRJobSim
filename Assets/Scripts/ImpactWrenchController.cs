using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ImpactWrenchController : MonoBehaviour
{
    public InitialTireManager TireLeft_Initial;
    public InitialTireManager TireRight_Initial;
    public ReplacementTireManager ReplacementTire_1;
    public ReplacementTireManager ReplacementTire_2;

    public Quaternion WrenchRotation;
    public Transform Hand;

    bool IsInContactWithNut = false;
    GameObject CurrentNut;

    bool IsGrabbed;

    void Start()
    {
        IsGrabbed = false;
    }

    void Update()
    {
        if (IsGrabbed)
        {
            gameObject.transform.rotation = WrenchRotation;
            gameObject.transform.position = new Vector3(Hand.position.x, Hand.position.y + 0.1f, Hand.position.z + 0.2f);
        }
    }



    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Nut")
        {
            CurrentNut = collider.gameObject;
            IsInContactWithNut = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (IsInContactWithNut)
        {
            IsInContactWithNut = false;
        }
    }

    // Use impact wrench by pressing trigger while holding impact wrench
    public void EngageImpactWrench()
    {
        Debug.Log("Trigger Clicked");
        Debug.Log(IsInContactWithNut);
        if (IsInContactWithNut)
        {
            if (IsInitialTire())
            {
                RemoveNut();
            }
            else if (IsReplacementTire())
            {
                FastenNut();
            }
        }
    }

    // Use impact wrench by pressing trigger while holding impact wrench
    public void GrabWrench()
    {
        Debug.Log("Wrench Grabbed");
        IsGrabbed = true;
    }

    public void DropWrench()
    {
        Debug.Log("Wrench dropped");
        IsGrabbed = false;
    }


    // Disengage impact wrench by releasing trigger - probably don't need
    public void DisengageImpactWrench()
    {
    }

    void RemoveNut()
    {
        CurrentNut.transform.Translate(0,50,0); // Preferably we run an animation on this to unscrew it
        if (CurrentNut.transform.parent.tag == "TireLeft")
        {
            TireLeft_Initial.CurrentNumberOfNuts -= 1;
        }
        else if (CurrentNut.transform.parent.tag == "TireRight")
        {
            TireRight_Initial.CurrentNumberOfNuts -= 1;
        }
        Debug.Log("You have removed a nut.");
    }

    void FastenNut()
    {
        if (CurrentNut.transform.parent.tag == "TireReplacement1")
        {
            ReplacementTire_1.CurrentNumberOfNutsFastened += 1;
        }
        else if (CurrentNut.transform.parent.tag == "TireReplacement2")
        {
            ReplacementTire_2.CurrentNumberOfNutsFastened += 1;
        }
        Debug.Log("You have fastened a nut.");
    }

    bool IsInitialTire()
    {
        if (CurrentNut.transform.parent.tag == "TireLeft" || 
            CurrentNut.transform.parent.tag == "TireRight")
        {
            return true;
        }
        return false;
    }

    bool IsReplacementTire()
    {
        if (CurrentNut.transform.parent.tag == "TireReplacement1" || 
            CurrentNut.transform.parent.tag == "TireReplacement2")
        {
            return true;
        }
        return false;
    }
}