using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgorundMove : MonoBehaviour
{
    private BoxCollider2D bxcol;
    private Vector3 startingPos;
    private PlayerPin playerScript;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Mainpin").GetComponent<PlayerPin>();
        bxcol = GetComponent<BoxCollider2D>();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x <= startingPos.x - bxcol.size.x / 2)
            {
                transform.position = startingPos;
            }
        }

    }
}
