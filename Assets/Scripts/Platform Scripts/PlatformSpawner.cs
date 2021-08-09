using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platform_Spawn_Timer = 1.8f;

    private float current_Platform_Spawn_Timer;
    private int platform_Spawn_Count;

    public float min_X = -2f, max_X = 2f; // граница движения платформ по X (вправо и влево)


    // Start is called before the first frame update
    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime; 
        // если надо ускорить скорость появление то Time.deltaTime * 2f к примеру
        // если замедлить появление платформ то Time.deltatime / 2f к примеру

        if(current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;



            if(platform_Spawn_Count < 2)
            {
                // create regular platform
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            } 


            // MOVING PLATFORM
            else if (platform_Spawn_Count == 2)
            {


                if(Random.Range(0, 2) > 0)
                {
                    // random create new platform or
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }


                else
                {
                    // or create moving platform
                    newPlatform = Instantiate(
                        movingPlatforms[Random.Range(0, movingPlatforms.Length)],
                        temp, Quaternion.identity);
                }
            }

            // SPIKE PLATFORM
            else if(platform_Spawn_Count == 3)
            {


                if (Random.Range(0, 2) > 0)
                {
                    // random create new platform or
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }


                else
                {
                    // or create spike platform
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }


            //BREAKABLE PLATFORM
            else if (platform_Spawn_Count == 4)
            {


                if (Random.Range(0, 2) > 0)
                {
                    // random create new platform or
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }


                else
                {
                    // or create breake platform
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }

                platform_Spawn_Count = 0; // это важно сделать, чтобы мы смогли вернуться в ту через всю итерацию 
                //если это не сделать то после окончания всех if появление платформ закончится
            }

            if (newPlatform)
            newPlatform.transform.parent = transform; // платформы которые рандомно будут поялвляться в сцене 
            //они будут становиться дочерними объектами Platform Spawner 

            current_Platform_Spawn_Timer = 0f; // чтобы все это условие повторялось и проверялось постоянно
            // если не обнулить не сделать оно перестанет создавать платформы

        } // spawn platform
    }
}
