using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerPin : MonoBehaviour
{
    public bool revert = false;

    private int scoreCount = 0;
    private Vector3 middlePivot = new Vector3(0, 0, 0);
    private bool isGameOver = false;

    private SpawnerControl spawnScript;
    private TextMeshProUGUI text;

    [SerializeField] private bool isGoodZone = false;
    [SerializeField] private GameObject redScore;
    // Start is called before the first frame update
    void Start()
    {
        spawnScript = GameObject.Find("Spawner").GetComponent<SpawnerControl>();
        text = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Pincontroller();
    }

    //=================================================================================

    public void Hit(InputAction.CallbackContext context)
    {
        if (context.performed && isGoodZone)
        {
            revert = !revert;
            Destroy(spawnScript.clone);
            scoreCount++;
            text.SetText(scoreCount.ToString());
            spawnScript.cloneCounter--;

        }
        else if (context.performed && !isGoodZone)
        {
            isGameOver = true;
        }
    }

    private void Pincontroller()
    {
        if (!revert && isGameOver == false)
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.back, 90 * Time.deltaTime);
        }
        if (revert && isGameOver == false)
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, 90 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Scoretrig"))
        {
            isGoodZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Scoretrig"))
        {
            isGoodZone = false;
        }
    }
}
