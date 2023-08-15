using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject barnaclePrefab;

    public int number_of_barnacles;
    public float x_min;
    public float x_max;
    public float y_min;
    public float y_max;
    public float z_min;
    public float z_max;
    public List<Vector3> objectPositions = new List<Vector3>();
        
    private float x_spawn;
    private float y_spawn;
    private float z_spawn;
    public float placementRadius = 1.0f;


    void Start()
    {
        for(int i = 0; i < number_of_barnacles; i++)
            {
            x_spawn = Random.Range(x_min,x_max);
            y_spawn = Random.Range(y_min,y_max);
            z_spawn = Random.Range(z_min,z_max);
            Vector3 randomSpawnPosition=new Vector3(x_spawn,y_spawn,z_spawn);
            
            objectPositions.Add(randomSpawnPosition);
            }
    }

    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < number_of_barnacles; i++)
            {
            Ray ray = Camera.main.ScreenPointToRay(objectPositions[i]);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, placementRadius);

                bool canPlace = true;
                foreach (Collider collider in colliders)
                {
                    if (!collider.CompareTag("IgnoreCollisionTag"))
                    {
                        canPlace = false;
                        break;
                    }
                }

                if (canPlace)
                {
                    Instantiate(barnaclePrefab, objectPositions[i], Quaternion.identity);
                }
            }
           // Instantiate(barnaclePrefab,objectPositions[i], Quaternion.identity);

            }
        }
    }
   
}
