using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{
    public Transform Player;
    int MaxDist = 10;
    int MinDist = 5;
    float _speed = 3.5f;
    float attack_rate = 5f;
    float next_attack = 0f;
    int attacking = 0;
    int rage = 0;
    float rage_end = 0f;
    float rage_length = 2f;
    
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    

    void Attack()
    {
        attacking = 1;
        

    }

    void jump()
    {
        transform.position += transform.up * 7* Time.deltaTime;
    }

    void fall()
    {
        transform.position += transform.up * -5 * Time.deltaTime;
    }



    void follow()
    {
       
  
            transform.LookAt(Player);
        
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * _speed * Time.deltaTime ;


            
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist && Time.time > next_attack )
            {
                
                Attack();
                print("attack");
                next_attack = Time.time + attack_rate;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(attacking == 0)
        {
            if (transform.position.y > -1)
            {
                if (transform.position.y < 1)
                    follow();
            }
            if (transform.position.y < 0)
                jump();
            if (transform.position.y > 0)
                fall();

        }

        if (attacking == 1)
        {
            if (transform.position.y < 5)
                jump();
            if (transform.position.y > 0)
                fall();
            if (transform.position.y > 4)
            {
                rage = 1;
                attacking = 0;
            }
        

        }
        if(rage == 1)
        {
            rage_end =Time.time + rage_length;
            _speed = 7f;
            if(Time.time > rage_end)
            {
                _speed =3.5f;
                rage = 0;
            }
        }


    }
}
