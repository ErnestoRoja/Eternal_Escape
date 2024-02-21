using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrainCollection : MonoBehaviour
{
    private int Brain = 0;
    public TextMeshProUGUI brainText;
    public SpawnManager spawnManager;

    public ParticleSystem brainCollectParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Brain")
        {
            Brain++;
            brainText.text = Brain.ToString();
            Instantiate(brainCollectParticle, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            
        }
    }
}
