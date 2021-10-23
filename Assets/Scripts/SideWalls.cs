using UnityEngine;


public class SideWalls : MonoBehaviour
{
    [SerializeField] StringEvent ballOutEvent;

    /*
     * Triggered when collider hits this object
     */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Ball")
        {
            /*
             * Trigger callback with name of wall
             */
            ballOutEvent.Invoke(this.name);
        }
    }
}
