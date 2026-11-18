using UnityEngine;

public class BrokenPipe : MonoBehaviour
{
    public bool brokenPipe;
    public int pipeId;

    [SerializeField] Sprite[] pipeSprite;
    [SerializeField] SpriteRenderer pipeSpriteSR;

    void Start()
    {
        pipeSpriteSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckBrokenPipe();
    }

    public void IsBroken()
    {
        brokenPipe = Random.Range(0, 2) == 0;
        CheckBrokenPipe();
    }

    void CheckBrokenPipe()
    {
        if(brokenPipe)
        {
            pipeSpriteSR.sprite = pipeSprite[0];
        }

        else
        {
            pipeSpriteSR.sprite = pipeSprite[1];
        }
    }
}
