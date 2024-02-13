using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUpdater : MonoBehaviour
{

    private GameObject player;
    public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        int distance = Mathf.RoundToInt(player.transform.position.z / 2);
        score.SetText("Score: " + distance.ToString());

    }
}
