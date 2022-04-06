/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: March 16, 2022
 * 
 * Last Edited by: Cristian misla
 * Last Edited: 4/6/2022
 * 
 * Description: Enemy controller
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase] //forces selection of parent object
public class Enemy : MonoBehaviour
{
    /*** VARIABLES ***/

    [Header("Enemy Settings")]
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;

    private BoundsCheck bndCheck; //reference to bounds check component
    
    //method that acts as a field (property)
    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }

    /*** MEHTODS ***/

    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }//end Awake()


    // Update is called once per frame
    void Update()
    {
        //Call the Move Method

        Move();

        //Check if bounds check exists and the object is off the bottom of the screne
        if(bndCheck != null && bndCheck.offDown)
        {
              Destroy(gameObject); //destory the object

        }//end if(bndCheck != null && !bndCheck.offDown)


    }//end Update()

    
    //Virtual methods can be overridden by child instances
    public virtual void Move()
    {
        Vector3 temPos = pos; //temporary position
        temPos.y -= speed * Time.deltaTime; //temporary y position, moving down
        pos = temPos; //position is equal to temporary position

    } // end Move()
    private void OnCollisionEnter(Collision col)
    {
        GameObject otherGo = col.gameObject;
        if (otherGo.tag == "ProjectileHero")
        {
            
            Debug.Log("Enemy hit by projectile " + otherGo.name);
            Destroy(otherGo);
            Hero.SHIP.AddToScore(score);
            Destroy(gameObject);

        }
        else
        {
            Debug.Log("Enemy hit by non-projectile " + otherGo.name);
        }
    }

}
