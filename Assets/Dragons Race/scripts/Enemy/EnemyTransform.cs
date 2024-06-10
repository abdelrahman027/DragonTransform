using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransform : MonoBehaviour
{
    [SerializeField] int DragonNumber;
    [SerializeField] float maxTransformTime=3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    GameObject OldDragon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Movement>())
        {

            OldDragon = other.gameObject;

            Invoke("changeDragon",Random.Range(0,maxTransformTime));

            gameObject.GetComponent<Collider>().enabled = false;


        }
    }

    public void changeDragon()
    {
        GameObject ActiveDragon = OldDragon.transform.parent.GetChild(DragonNumber).gameObject;
        ActiveDragon.transform.position = OldDragon.transform.position;
        ActiveDragon.SetActive(true);
        ActiveDragon.GetComponent<Movement>().resetHealthAndSpeed();
        OldDragon.SetActive(false);
        GameObject vfx = ActiveDragon.GetComponent<Movement>().Dead_Vfx.gameObject;
        vfx.transform.position = ActiveDragon.transform.position;
        vfx.GetComponent<ParticleSystem>().Play();
    }
}
