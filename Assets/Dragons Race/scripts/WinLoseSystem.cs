using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseSystem : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] int Rank=0;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Movement>())
        {
            other.gameObject.GetComponent<Animator>().enabled = false;
            other.gameObject.GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Rank++;
            print(other.transform.parent.tag);
            if (other.transform.parent.tag=="player")
            {
                print("Player seen");
                if (Rank==1)
                {
                    print("player win");
                    winPanel.SetActive(true);
                } 
            }
            else
            {
                print("player lose");

                losePanel.SetActive(true);
            }

        }
    }
}
