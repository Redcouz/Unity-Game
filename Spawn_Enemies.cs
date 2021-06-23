using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemies : MonoBehaviour
{
    private float time;
    public float waitTime;
    public GameObject Enemy;
    public List<GameObject> EnemiesInGame = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        time = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesInGame.Count <= 5)
        {
            waitTime = Random.Range(3, 10);
            if (time <= 0)
            {
                EnemiesInGame.Add(Instantiate(Enemy, gameObject.transform.position, Quaternion.Euler(0, 0, 0)));
                time = waitTime;
            }
            time -= Time.deltaTime;
        }
       
    }
}
