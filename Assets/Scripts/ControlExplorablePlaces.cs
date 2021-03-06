using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlExplorablePlaces : MonoBehaviour
{
    public GameObject[] explorablePlaces; //the explorable places that the user will hit and explore

    public List<GameObject> createdPlaces; //the currently created places

    public float moveSpeed = 50f; //how fast the object will go down the screen

    private float objectChoice = 0f; //which explorable place to go to
    private float numOptions = 2f; //the nuber of explorable places (-1 due to array numbering)

    void Start()
    {
        StartCoroutine(spawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        //move the currently existing places down the screen
        moveCurrentObjects();
    }

    IEnumerator spawnObject()
    {
        while (true)
        {
            //instantiate the object
            GameObject newExplorable = Instantiate(explorablePlaces[(int)objectChoice]);

            //Setup the transforms position
            //x=random[-1000,1000],y=12,z=1200
            float xPos = Random.Range(-1000, 1000);
            newExplorable.transform.position = new Vector3(xPos, 12f, 1200f);

            //Add it to the list of created places
            createdPlaces.Add(newExplorable);

            //update which explorable place will spawn
            objectChoice++;

            //check if the explorable place count is higher than the number of options
            if (objectChoice > numOptions)
            {
                objectChoice = 0;
            }

            yield return new WaitForSeconds(5f);
        }
    }

    public void moveCurrentObjects()
    {
        for (int i = 0; i < createdPlaces.Count; i++)
        {
            createdPlaces[i].transform.position = new Vector3(createdPlaces[i].transform.position.x, createdPlaces[i].transform.position.y, createdPlaces[i].transform.position.z - moveSpeed*Time.deltaTime);

            //if an object went off screen and was deleted remove it from the list
            if (createdPlaces[i].transform.position.z < -1300)
            {
                createdPlaces.RemoveAt(i);
            }
        }
    }
}
