using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] MinigameN02 minigameN02;
    
    [Header("Camera")]
    [SerializeField] Camera camera02;
    [Header("Sprite Render")]
    [SerializeField] private SpriteRenderer wireEnd;
    [SerializeField] private SpriteRenderer light;

    private WireID wireId;
    private Collider2D col;
    
    private bool isConnected;

    Vector3 startPoint;
    Vector3 startPosition;
    
    void Start()
    {
        col = GetComponent<Collider2D>();
        startPoint = transform.parent.position;
        startPosition = transform.position;

        isConnected = true;

        wireId = GetComponent<WireID>();
    }

    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = camera02.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
       
        foreach (Collider2D collider in colliders)
        {
            WireID otherWireId = collider.GetComponent<WireID>();

            if (collider.gameObject != gameObject)
            {
                UpdateWire(collider.transform.position);

                if(wireId.wireIdnumber == otherWireId.wireIdnumber)
                {
                    Debug.Log("FIOS CONECTADOS");

                    light.color = Color.green;

                    if (!isConnected)
                    {
                        isConnected = true;
                       
                        minigameN02.AddConnectedWire();
                    }
                }
  
                return;
            }
        }

        UpdateWire(newPosition);
    }

    private void OnMouseUp()
    {
        if (!isConnected)
        {
            UpdateWire(startPosition);
        }
    }

    private void UpdateWire(Vector3 newPosition)
    {
        transform.position = newPosition;

        Vector3 direction = newPosition - startPoint;
        transform.right = direction;

        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }

    public void ResetWire()
    {
        isConnected = false;
        transform.position = startPosition;
        light.color = Color.white;
        UpdateWire(startPosition);
    }
}
