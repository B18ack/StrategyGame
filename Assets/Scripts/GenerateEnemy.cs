using System.Collections;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public Transform[] points;
    public GameObject[] factories;

    private void Start()
    {
        StartCoroutine(SpawnFactory());
    }

    IEnumerator SpawnFactory()
    {
        for(int i = 0; i < points.Length; i++)
        {
            yield return new WaitForSeconds(10f);
            GameObject randomFactory = factories[Random.Range(0, factories.Length)];
            GameObject spawn = Instantiate(randomFactory);
            Destroy(spawn.GetComponent<PlaceObjects>());
            spawn.transform.position = points[i].position;
            spawn.transform.rotation = Quaternion.Euler(0, 90, 0);


            AutoCarCreate car = spawn.GetComponent<AutoCarCreate>();
            car.enabled = true;
            car.IsEnemy = true;
        }
    }

}
