using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    public Transform Player;
    public Enemy_Spawn Enemy_Spawn;
    GameObject target = null;
    int lockon = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject FindClosest(List<GameObject> enemies, Transform player)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = player.position;
        foreach( GameObject enemy in enemies)
        {
            Vector3 directionToTarget = enemy.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = enemy;
            }
        }
        return bestTarget;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton11))
            print("yep");
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            lockon = lockon *-1;
            target = FindClosest(Enemy_Spawn.Enemies, Player) ;
            
        }

        if(lockon == 1)
            {
                Player.LookAt(target.transform);
                Player.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
    }
}
