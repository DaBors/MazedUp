using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class BuildWalls : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    List<GameObject> allPrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        buildWalls("Assets/Mazes/maze1.txt");
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
                                allPrefabs.Add(Instantiate(myPrefab, new Vector3(i, 0, lineNumber), Quaternion.identity));
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
