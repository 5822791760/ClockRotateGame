using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private PlayerPin playerScript;
    [SerializeField] private AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Mainpin").GetComponent<PlayerPin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isGameOver)
        {
            BGM.Stop();
        }
    }
}
