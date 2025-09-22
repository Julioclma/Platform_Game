using System.Threading.Tasks;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float FallingTime;
    private TargetJoint2D TargetJoint2D;
    private BoxCollider2D BoxCollider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TargetJoint2D = GetComponent<TargetJoint2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();

    }
    void DropPlatform()
    {
        TargetJoint2D.enabled = false;
        BoxCollider2D.isTrigger = true;
    }

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.tag == "Player")
        {
            Invoke("DropPlatform", FallingTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}
