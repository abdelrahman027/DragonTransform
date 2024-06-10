using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTrigger1 : MonoBehaviour
{
    public string tag1;
    [SerializeField] float DecreaseSpeed=4;
    [SerializeField] private bool Die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Movement movementScript = other.gameObject.GetComponent<Movement>();
        if (Die == true && movementScript)
        {
            if (other.gameObject.tag == tag1)
            {

                  other.gameObject.GetComponent<Movement>().decreaseSpeed(DecreaseSpeed);

            }
            else
            {
                if(movementScript)
                {

                    other.gameObject.GetComponent<Movement>().resetHealthAndSpeed();
                }
             
            }
        }
        else
        {
            if (other.gameObject.tag != tag1 && movementScript)
            {
               

                    other.gameObject.GetComponent<Movement>().decreaseSpeed(DecreaseSpeed);

            }
            else
            {


                if (movementScript)
                {

                    other.gameObject.GetComponent<Movement>().resetHealthAndSpeed();
                }
            }

        }


    }
}
