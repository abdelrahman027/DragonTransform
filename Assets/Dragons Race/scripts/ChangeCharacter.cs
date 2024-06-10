using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public int DragonNum;
    [SerializeField] ParticleSystem TransformEffect;
    [SerializeField] AudioSource TransformSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeDragons()
    {
        GameObject[] playerDragons = GameObject.FindGameObjectWithTag("player")
            .GetComponent<DragonsManager>().Dragons;

        int ActiveDragon = 0;

        for (int i = 0; i < playerDragons.Length; i++)
        {
            if (playerDragons[i].activeSelf==true)
            {
                ActiveDragon = i;
                break;
            }

        }
        if (ActiveDragon != DragonNum)
        {

            playerDragons[DragonNum].transform.position = playerDragons[ActiveDragon].transform.position;

            playerDragons[ActiveDragon].SetActive(false);
            playerDragons[DragonNum].SetActive(true);

            #region reset Dragon speed
            Movement movementScript = playerDragons[DragonNum].GetComponent<Movement>();
            movementScript.resetHealthAndSpeed();
            #endregion


            #region particles & sound effect

            TransformEffect.Play();

            Vector3 effectPosition = new Vector3(playerDragons[ActiveDragon].transform.position.x, TransformEffect.transform.position.y, playerDragons[ActiveDragon].transform.position.z);
            TransformEffect.transform.position = effectPosition;
            TransformSound.Play();
            TransformSound.transform.position = playerDragons[ActiveDragon].transform.position;


            #endregion
        }
    }
}
