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

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Brain")
        {
            Brain++;
            audioManager.PlaySFX(audioManager.collect);
            brainText.text = Brain.ToString();
            Instantiate(brainCollectParticle, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            
        }
    }
}
