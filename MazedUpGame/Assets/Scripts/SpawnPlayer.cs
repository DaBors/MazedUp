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
        playerCharacterInstance = Instantiate(playerCharacter, gameObject.transform.position + new Vector3(playerStartPositionX, 0, playerStartPositionY), Quaternion.identity);

        playerCharacterInstance.GetComponent<PlayerController>().PlayerIndex = playerIndex;

        mainCamera.GetComponent<CameraSmoothFollow>().Target = playerCharacterInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
