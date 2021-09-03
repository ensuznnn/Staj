using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI arrowCounts;
    public int arrows = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            Collect(other.GetComponent<Collectible>());
        }
    }
    private void Collect(Collectible collectible)
    {
        if (collectible.Collect())
        {
            if(collectible is ArrowCollectible)
            {
                arrows++;
                arrowCounts.text = ("Arrows : "+(arrows)).ToString();
            
            }
        }
    }
}
