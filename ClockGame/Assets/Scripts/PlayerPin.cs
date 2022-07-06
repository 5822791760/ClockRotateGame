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
    public bool isGameOver = false;
    private float speed = 60;

    private SpawnerControl spawnScript;
    private TextMeshProUGUI text;

    [SerializeField] private bool isGoodZone = false;
    [SerializeField] private GameObject redScore;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource gamerOverSound;
    // Start is called before the first frame update
    void Start()
    {
        spawnScript = GameObject.Find("Spawner").GetComponent<SpawnerControl>();
        text = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Pincontroller();
    }

    //=================================================================================

    public void Hit(InputAction.CallbackContext context)
    {
        if (context.performed && isGoodZone)
        {
            hitSound.Play();
            revert = !revert;
            Destroy(spawnScript.clone);
            scoreCount++;
            text.SetText(scoreCount.ToString());
            spawnScript.cloneCounter--;
            speed += 5;

        }
        else if (context.performed && !isGoodZone)
        {
            isGameOver = true;
            gamerOverSound.Play();
        }
    }

    private void Pincontroller()
    {
        if (!revert && isGameOver == false)
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.back, speed * Time.deltaTime);
        }
        if (revert && isGameOver == false)
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
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
