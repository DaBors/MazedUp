using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

//[ExecuteInEditMode]
public class BuildWalls : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myWall;
    public GameObject myFlame;
    public GameObject myFlickeringLight;
    public GameObject myPlinth;
    public GameObject winPoint;

    public int playerIndex = 1;

    List<GameObject> allMapStructure = new List<GameObject>();
    List<GameObject> allObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        buildWalls("Assets/Mazes/maze2.txt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private bool buildWalls(string fileName)
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            uint lineNumber = 0;

            StreamReader theReader = new StreamReader(fileName, Encoding.Default);

            using (theReader)
            {
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();
                    
                    if (line != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            GameObject structureToInstantiate = myWall;

                            Vector3 positionForStructure = gameObject.transform.position + new Vector3(i * myWall.transform.localScale.x * 4, 0, lineNumber * myWall.transform.localScale.z * 4);

                            if(line[i] != '1')
                            {
                                if (line[i] == 'B')
                                {
                                    GameObject newObject = null;

                                    if (playerIndex == 1)
                                    {
                                        newObject = Instantiate(myPlinth, positionForStructure, Quaternion.identity);

                                        Light plinthLight = newObject.GetComponentInChildren<Light>();

                                        plinthLight.color = Color.blue;
                                    }
                                    else
                                    {
                                        newObject = Instantiate(winPoint, positionForStructure, Quaternion.identity);
                                    }

                                    allObjects.Add(newObject);

                                    newObject.transform.parent = gameObject.transform;
                                }
                                else if (line[i] == 'R')
                                {
                                    GameObject newObject = null;

                                    if (playerIndex == 2)
                                    {
                                        newObject = Instantiate(myPlinth, positionForStructure, Quaternion.identity);

                                        Light plinthLight = newObject.GetComponentInChildren<Light>();

                                        plinthLight.color = Color.red;
                                    }
                                    else
                                    {
                                        newObject = Instantiate(winPoint, positionForStructure, Quaternion.identity);
                                    }

                                    allObjects.Add(newObject);

                                    newObject.transform.parent = gameObject.transform;
                                }
	                            else if(line[i] == 'F')
	                            {
	                                allObjects.Add(Instantiate(myFlickeringLight, new Vector3(lineNumber * myWall.transform.localScale.z, 1, i * myWall.transform.localScale.x), Quaternion.identity));
	                            }

                                structureToInstantiate = null;
                            }

                            GameObject newStructure = null;

                            if (structureToInstantiate != null)
                            {
                                newStructure = Instantiate(structureToInstantiate, positionForStructure, Quaternion.identity);
                            }
                            else
                            {
                                newStructure = new GameObject();

                                newStructure.transform.position = positionForStructure;
                            }
                            
                            newStructure.transform.parent = gameObject.transform;

                            allMapStructure.Add(newStructure);
                            //else if(line[i] == 'T')
                            //{
                            //    allPrefabs.Add(Instantiate(myFlame, new Vector3(lineNumber * myWall.transform.localScale.z, 0, i * myWall.transform.localScale.x), Quaternion.identity));
                            //}
                        }
                    }

                    lineNumber++;
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return false;
        }
    }
}
