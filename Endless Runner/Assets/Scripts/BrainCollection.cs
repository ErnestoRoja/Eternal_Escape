using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrainCollection : MonoBehaviour
{
    private int Brain = 0;
    public TextMeshProUGUI brainText;
    public SpawnManager spawnManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Brain")
        {
            Brain++;
            brainText.text = Brain.ToString();
            Debug.Log(Brain);
            Destroy(other.gameObject);
        }
    }
}
