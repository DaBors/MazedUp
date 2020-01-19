using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public int playerIndex = 1;

    public int playerStartPositionX;

    public int playerStartPositionY;

    public GameObject playerCharacter;

    public GameObject mainCamera;

    GameObject playerCharacterInstance;
    // Start is called before the first frame update
    void Start()
    {
        Camera playerCamera = gameObject.GetComponentInChildren<Camera>();

        if(playerIndex == 1)
        {
            playerCamera.rect = new Rect(0, 0, 0.5f, 1);
        }
        else
        {
            playerCamera.rect = new Rect(0.5F, 0, 0.5f, 1);
        }

        playerCharacterInstance = Instantiate(playerCharacter, gameObject.transform.position + new Vector3(playerStartPositionX, 0, playerStartPositionY), Quaternion.identity);

        playerCharacterInstance.GetComponent<PlayerController>().PlayerIndex = playerIndex;

        playerCharacterInstance.transform.parent = gameObject.transform;

        mainCamera.GetComponent<CameraSmoothFollow>().Target = playerCharacterInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
