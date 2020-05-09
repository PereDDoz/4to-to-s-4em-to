using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public float fMovingSpeed;
    Vector3 pos;
    public TMP_Text display;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
        }
        else
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector2(0, 0), fMovingSpeed);
        }
        if (cardGameObject.transform.position.x > 2)
        {
            cardSpriteRenderer.color = Color.green;
            if (!Input.GetMouseButton(0))
            {

            }
        }
        else if (cardGameObject.transform.position.x < -2)
        {
            cardSpriteRenderer.color = Color.red;
            if (!Input.GetMouseButton(0))
            {

            }
        }
        else
        {
           cardSpriteRenderer.color = Color.white; 
        }
    }
}
