using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject Step1,Step2,Step3,Step4,Step5,Step6;

    // Start is called before the first frame update
    void Start()
    {
        Step1 = GameObject.Find("Step1"); Step1.SetActive(true);
        Step2 = GameObject.Find("Step2"); Step2.SetActive(false);
        Step3 = GameObject.Find("Step3"); Step3.SetActive(false);
        Step4 = GameObject.Find("Step4"); Step4.SetActive(false);
        Step5 = GameObject.Find("Step5"); Step5.SetActive(false);
        Step6 = GameObject.Find("Step6"); Step6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Step1On()
    {
        Debug.Log("Step 1 Selected");
        Step1.SetActive(true);
    }
    public void Step2On()
    {
        Debug.Log("Step 2 Selected");
        Step2.SetActive(true);
    }
    public void Step3On()
    {
        Debug.Log("Step 3 Selected");
        Step3.SetActive(true);
    }
    public void Step4On()
    {
        Debug.Log("Step 4 Selected");
        Step4.SetActive(true);
    }
    public void Step5On()
    {
        Debug.Log("Step 5 Selected");
        Step5.SetActive(true);
    }
    public void Step6On()
    {
        Debug.Log("Step 6 Selected");
        Step6.SetActive(true);
    }

    public void Step1Off()
    {
        Debug.Log("Step 1 Off");
        Step1.SetActive(false);
    }
    public void Step2Off()
    {
        Debug.Log("Step 2 Off");
        Step2.SetActive(false);
    }
    public void Step3Off()
    {
        Debug.Log("Step 3 Off");
        Step3.SetActive(false);
    }
    public void Step4Off()
    {
        Debug.Log("Step 4 Off");
        Step4.SetActive(false);
    }
    public void Step5Off()
    {
        Debug.Log("Step 5 Off");
        Step5.SetActive(false);
    }
    public void Step6Off()
    {
        Debug.Log("Step 6 Off");
        Step6.SetActive(false);
    }
}
