using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    [SerializeField] private GameObject redScore;
    public GameObject clone;
    public int cloneCounter = 0;
    private PlayerPin playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Mainpin").GetComponent<PlayerPin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cloneCounter == 0 && playerScript.revert == false)
        {
            clone = Instantiate(redScore, redScore.transform.position, redScore.transform.rotation * Quaternion.Euler(0, 0, Random.Range(225, 316)));
            cloneCounter++;
        }
        if (cloneCounter == 0 && playerScript.revert == true)
        {
            clone = Instantiate(redScore, redScore.transform.position, redScore.transform.rotation * Quaternion.Euler(0, 0, Random.Range(45, 136)));
            cloneCounter++;
        }
    }
}
