using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    bool firstStepCompleted = false;
    bool secondStepCompleted = false;
    public GameObject[] steps;
    public GameObject[] tabs;

    private void Start()
    {
        CustomEvents.OutputCrafted += ProductCrafted;
        CustomEvents.ProductDelivered = FinishTutorial;
    }

    private void FixedUpdate() 
    {
        if (!firstStepCompleted && CraftManager.current.canCraft)
        {
            Debug.Log("Step 1 done");
            firstStepCompleted = true;
            EnableStep(2);
        }
    }

    void EnableStep(int step)
    {
        switch (step)
        {
            case 2:
                steps[1].transform.parent.gameObject.SetActive(true);
                steps[1].SetActive(true);
                break;
            default:
                break;
        }
    }


    public void DisableAllStepsDescriptions()
    {
        foreach(GameObject step in steps)
        {
            step.SetActive(false);
        }
    }

    public void ChangeCurrentTab(int tabNumber)
    {
        switch (tabNumber)
        {
            case 1:
                if (firstStepCompleted) tabs[1].SetActive(true);
                if (secondStepCompleted) tabs[2].SetActive(true);
                break;
            
            case 2:
                tabs[0].SetActive(true);
                if (secondStepCompleted) tabs[2].SetActive(true);
                break;

            case 3:
                tabs[0].SetActive(true);
                tabs[1].SetActive(true);
                break;

            default:
                break;
        }
    }

    void ProductCrafted()
    {
        secondStepCompleted = true;
        StartCoroutine ("FinalStep");
    }

    IEnumerator FinalStep()
    {
        yield return new WaitForSeconds(1);
        steps[2].transform.parent.gameObject.SetActive(true);
        steps[2].SetActive(true);
        CustomEvents.OutputCrafted = null;
    }

    void FinishTutorial()
    {
        GameManager.instance.saveManager.TutorialCompleted();
        GameManager.instance.ActiveMenu();
    }
}
