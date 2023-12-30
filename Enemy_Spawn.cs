using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    int count = 0;
    int round = 0;
    float spawnRate = 0.0f;
    public GameObject Enemy;
    public List<GameObject> Enemies;
    float shipR1 = 70;
    float shipR2 = 80;
    int side = 0;
    GameObject tempEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<GameObject>();
        foreach( var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            var enemyScript = enemy.AddComponent<EnemyScript>();
            enemyScript.Enemy_Spawn = this;
            Enemies.Add(enemy);
        }
    }

    void jump()
    {
        transform.position += transform.up * 10 * Time.deltaTime;
    }

    void spawn()
    {
        side = Random.Range(1, 5);
        if (side == 1)
            Enemies.Add(Instantiate(Enemy, new Vector3(Random.Range(-shipR1, shipR1), 0, shipR2), Quaternion.identity));
        if (side == 2)
            Enemies.Add(Instantiate(Enemy, new Vector3(Random.Range(-shipR1, shipR1), 0, -shipR2), Quaternion.identity));
        if (side == 3)
            Enemies.Add(Instantiate(Enemy, new Vector3(shipR1, 0, Random.Range(-shipR1, shipR1)), Quaternion.identity));
        if (side == 4)
           Enemies.Add(Instantiate(Enemy, new Vector3(-shipR1, 0, Random.Range(-shipR1, shipR1)), Quaternion.identity));

       
        jump();
        

        
        count += 1;
        
            
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            round += 1;
            print(round);
            if (round == 1)
                spawnRate = 5.0f;
            if (round == 2)
                spawnRate = 2.0f;
            CancelInvoke();
            InvokeRepeating("spawn", 5.0f, spawnRate);

        }


        
            
    }
}
