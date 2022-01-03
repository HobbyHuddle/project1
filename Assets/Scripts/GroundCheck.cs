using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] public LayerMask targetLayer;
    public BoxCollider2D boxCollider;
    [Range(-0.5f, 0.75f)] public float distanceToTarget;
    
    public Vector2 boxCastDirection = Vector2.down;

    public bool IsTouching()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, boxCastDirection, distanceToTarget,targetLayer);
        //Debug.Log("Collision check: " + hit.collider);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        // FIXME: divide by 3 workaround - why isnt the gizmo scaling to the size of the boxCollider?
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.size/3);
    }
}