using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float constSpeed;
    [SerializeField] float CurrentSpeed;
    [SerializeField] float Health = 3;
    public ParticleSystem Dead_Vfx;
    [SerializeField] GameObject footer;
    public AudioSource Dead_Sfx;
    [SerializeField] GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(new Vector3(gameObject.transform.position.x
                                    ,gameObject.transform.position.y,
                                     gameObject.transform.position.z- CurrentSpeed * Time.deltaTime));

        if (CurrentSpeed < constSpeed)
        {

            if (Health > 0)
            {

            Health -= Time.deltaTime;
            }
            else
            {
                print("Dead");
                Dead_Vfx.Play();
                Dead_Sfx.Play();
                Dead_Vfx.transform.position = transform.position;
                if (gameObject.transform.parent.tag =="player")
                {
                footer.SetActive(false);

                losePanel.gameObject.SetActive(true);
                }
                gameObject.SetActive(false);
            }
        }
    }
    public void decreaseSpeed(float dividedBy)
    {
        CurrentSpeed = CurrentSpeed / dividedBy;
    }
    public void resetHealthAndSpeed()
    {
        Health = 3;
        CurrentSpeed = constSpeed;
    }
    public void ChangeSpeed(float speedValue)
    {
        CurrentSpeed = speedValue;
    }
}