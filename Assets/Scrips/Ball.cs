using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    private int count;
    public GameObject pared;

    Vector3 initialPotition;
    Vector3 initialCam;
    void Start()
    {
        initialPotition = new Vector3(0, 1, -3.5f);
        initialCam= new Vector3(1, 11, -8.4f);
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float MoveH = Input.GetAxis("Horizontal");
        float MoveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveH, 0, MoveV);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FalseWall"))
        {
            other.gameObject.SetActive(false);
        }
        else if(other.gameObject.CompareTag("PickUps"))
            {
            other.gameObject.SetActive(false);
            count++;
            //Revisar, no funciona la pocición inicial de la cam y de la bola
            NextLvl();
        }
        else
        {
            resetScene();
        }
    }
    private void NextLvl()
    {
        if (count==3)
        {
            pared.SetActive(false);
        }
    }
    private void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("First Map").buildIndex);
    }
}