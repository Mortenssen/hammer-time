using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverProduct : MonoBehaviour
{
    public ParticleSystem particle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Product")
        {
            if (CustomEvents.ProductDelivered != null) CustomEvents.ProductDelivered();
            StartCoroutine(ParticleTransporter(other.gameObject));
        }
    }

    IEnumerator ParticleTransporter(GameObject item)
    {
        for (int i = 0; i < 4; i++)
        {
            particle.Emit(1);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(item);
    }
}
