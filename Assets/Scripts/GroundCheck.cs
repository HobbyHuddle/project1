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
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.size);
    }
}