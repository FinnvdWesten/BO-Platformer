using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float waypointMargin = 0.25f;
    private SpriteRenderer spriteRenderer;
    public Transform[] points;

    [SerializeField]private int i;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        Debug.Log(Vector2.Distance(transform.position, points[i].position));
        if (Vector2.Distance(transform.position, points[i].position) < waypointMargin)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        spriteRenderer.flipX = (transform.position.x - points[i].position.x) < 0f;
    }
}
