using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishOrder : MonoBehaviour
{
    public GameObject teleporterZone;
    void Start()
    {
        teleporterZone.SetActive(false);
        CustomEvents.OutputCrafted += ProductCrafted;
    }

    // Update is called once per frame
    void ProductCrafted()
    {
        teleporterZone.SetActive(true);
    }
}
