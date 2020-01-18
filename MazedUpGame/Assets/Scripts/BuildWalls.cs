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
    List<GameObject> allPrefabs = new List<GameObject>();

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
                            if(line[i] == '1')
                            {
                                GameObject newBlock = Instantiate(myWall, gameObject.transform.position + new Vector3(i * myWall.transform.localScale.x, (float)myWall.transform.localScale.y / 2, lineNumber * myWall.transform.localScale.z), Quaternion.identity);

                                newBlock.transform.parent = gameObject.transform;

                                allPrefabs.Add(newBlock);
                            }
                            if(line[i] == 'T')
                            {
                                allPrefabs.Add(Instantiate(myFlame, new Vector3(lineNumber * myWall.transform.localScale.z, 0, i * myWall.transform.localScale.x), Quaternion.identity));
                            }
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
