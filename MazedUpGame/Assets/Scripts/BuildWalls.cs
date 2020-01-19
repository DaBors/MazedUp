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

    public int playerIndex = 1;

    List<GameObject> allMapStructure = new List<GameObject>();
    List<GameObject> allObjects = new List<GameObject>();


    List<GameObject> allFlames = new List<GameObject>();
    private List<Vector3> flamePositions = new List<Vector3>();

    private UInt32 count = 0;

    // Start is called before the first frame update
    void Start()
    {
        buildWalls("Assets/Mazes/maze2.txt");
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 300)
        {
            if(allFlames.Count == 0)
            {
                foreach (Vector3 pos in flamePositions)
                {
                    GameObject flame = Instantiate(myFlame, pos, Quaternion.identity);
                    allFlames.Add(flame);
                }
            }
            else
            {
                foreach (GameObject flame in allFlames)
                {
                    Destroy(flame);
                }
                allFlames.Clear();
            }
            count = 0;
        }
        count++;
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
                                if ((line[i] == 'B') && (playerIndex == 1))
                                {
                                    GameObject newObject = Instantiate(myPlinth, positionForStructure, Quaternion.identity);

                                    Light plinthLight = newObject.GetComponentInChildren<Light>();

                                    plinthLight.color = Color.blue;

                                    allObjects.Add(newObject);

                                    newObject.transform.parent = gameObject.transform;
                                }
                                else if (line[i] == 'R' && (playerIndex == 2))
                                {
                                    GameObject newObject = Instantiate(myPlinth, positionForStructure, Quaternion.identity);

                                    Light plinthLight = newObject.GetComponentInChildren<Light>();

                                    plinthLight.color = Color.red;

                                    allObjects.Add(newObject);

                                    newObject.transform.parent = gameObject.transform;
                                }
	                            else if(line[i] == 'F')
	                            {
	                                allObjects.Add(Instantiate(myFlickeringLight, new Vector3(lineNumber * myWall.transform.localScale.z, 1, i * myWall.transform.localScale.x), Quaternion.identity));
	                            }
                                else if(line[i] == 'T')
                                {
                                    GameObject flame = Instantiate(myFlame, positionForStructure, Quaternion.identity);

                                    allFlames.Add(flame);
                                    flamePositions.Add(positionForStructure);
                                    allObjects.Add(flame);
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
