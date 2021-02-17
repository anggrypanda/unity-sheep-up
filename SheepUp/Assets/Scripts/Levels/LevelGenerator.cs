using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startPlatform, platform, endPlatform;

    private float platformWidth = 0.5f, platformHeight = 0.2f;

    [SerializeField]
    private int spawnCounter = 100;
    private int beginCounter = 0;

    private Vector3 lastPosition;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();

    [SerializeField]
    private GameObject player;

    void Awake()
    {
        InstantiateLevel();
    }

    void InstantiateLevel()
    {
        for(int i = beginCounter; i < spawnCounter; i++)
        {
            GameObject newPlatform;

            if (i == 0)
            {
                newPlatform = Instantiate(startPlatform);
            }
            else if(i == spawnCounter - 1)
            {
                newPlatform = Instantiate(endPlatform);
                newPlatform.tag = "EndPlatform";
            }
            else
            {
                newPlatform = Instantiate(platform);
            }

            newPlatform.transform.parent = transform;
            spawnedPlatforms.Add(newPlatform);

            if(i == 0)
            {
                lastPosition = newPlatform.transform.position;

                Vector3 temp = lastPosition;
                temp.y += 0.1f;
                Instantiate(player, temp, Quaternion.identity);

                continue;
            }

            int left = Random.Range(0, 2);

            if(left == 0)
            {
                newPlatform.transform.position = new Vector3(lastPosition.x - platformWidth, 
                                                            lastPosition.y + platformHeight, 
                                                            lastPosition.z);
            }
            else
            {
                newPlatform.transform.position = new Vector3(lastPosition.x, 
                                                            lastPosition.y + platformHeight, 
                                                            lastPosition.z + platformWidth);
            }

            lastPosition = newPlatform.transform.position;

            if(i < 25)
            {
                float endPosition = newPlatform.transform.position.y;

                newPlatform.transform.position = new Vector3(newPlatform.transform.position.x,
                                                            newPlatform.transform.position.y - platformHeight * 3f,
                                                            newPlatform.transform.position.z);

                newPlatform.transform.DOLocalMoveY(endPosition, 0.3f).SetDelay(i * 0.1f);
            }
        }
    }
}
