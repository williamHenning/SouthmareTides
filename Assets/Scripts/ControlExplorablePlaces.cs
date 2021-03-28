using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlExplorablePlaces : MonoBehaviour
{
    public GameObject[] explorablePlaces; //the explorable places that the user will hit and explore

    //public List<GameObject> createdPlaces; //the currently created places

    //public float moveSpeed = 50f; //how fast the object will go down the screen

    private float objectChoice = 0f; //which explorable place to go to
    private float numOptions = 2f; //the nuber of explorable places (-1 due to array numbering)

    void Start()
    {
        spawnObjects();
        //StartCoroutine(spawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        //move the currently existing places down the screen
        //moveCurrentObjects();
    }

    /*IEnumerator spawnObject()
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
    */

    //Spawn explorable places in the different spawn sections
    public void spawnObjects()
    {
        //spawn area 1
        spawn(-1100,950,1100,1200);

        //spawn area 2
        spawn(-850,300,-185,800);

        //spawn area 3
        spawn(100,250,600,800);

        //spawn area 4
        spawn(-1210,-1260,-820,-150);

        //spawn area 5
        spawn(-510,-974,-280,-100);

        //spawn area 6
        spawn(300,-1260,715,-100);

        //spawn area 7
        spawn(800,-815,1100,460);

    }

    public void spawn(int minX, int minZ, int maxX, int maxZ)
    {
        //List to hold the objects that have already been spawned in this area to avoid overlap of objects
        List<GameObject> createdPlaces = new List<GameObject>(); //the currently created places

        //Scalar to lower the number of objects that spawn
        int divisionScalar = 90000;

        //Calculate the area of the spawn section
        int spawnArea = (maxX - minX) * (maxZ - minZ);

        //Calculate that max number of objects to spawn in that area
        int maxObjects = spawnArea/divisionScalar;
        
        //Spawn the objects
        for (int i = 0; i < maxObjects; i++) {
            //instantiate the object
            GameObject newExplorable = Instantiate(explorablePlaces[(int)objectChoice]);
            Boolean conflict = false;

            //Setup the transforms position
            do
            {
                conflict = false;

                //setup the x and z position
                float xPos = UnityEngine.Random.Range(minX, maxX);
                float zPos = UnityEngine.Random.Range(minZ, maxZ);
                newExplorable.transform.position = new Vector3(xPos, 12f, zPos);

                //check if this conflicts with another objects position
                for (int j = 0; j < createdPlaces.Count; j++)
                {
                    if (Vector3.Distance(createdPlaces[j].transform.position, newExplorable.transform.position) < 200)
                    {
                        conflict = true;
                    }
                }

            //Keep making new positions until there is no conflict
            } while (conflict);

            //Create a random rotation around the y-axis
            newExplorable.transform.Rotate(0.0f, UnityEngine.Random.Range(0.0f, 360.0f), 0.0f);

            //Add created object to the list of created places for this area
            createdPlaces.Add(newExplorable);

            //update which explorable place will spawn
            objectChoice++;

            //check if the explorable place count is higher than the number of options
            if (objectChoice > numOptions)
            {
                objectChoice = 0;
            }
        }
    }

    /*public void moveCurrentObjects()
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
    }*/
}
