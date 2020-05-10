using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{   //GameObjects
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    //Tweaking variables
    public float fMovingSpeed;
    public float fSideMargin;
    public float fSideTregger;
    public float divideValue;
    float alphaText;
    public Color textColor;
    Vector3 pos;
    //UI
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    //Card variables 
    private string leftQoute;
    private string rightQoute;
    public Card currentCard;
    public Card testCard;
    void Start()
    {
        LoadCard(testCard);
    }

    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        if (cardGameObject.transform.position.x < 0)
        {
            actionQuote.text = leftQoute;
        }
        else
        {
            actionQuote.text =rightQoute;
        }
    }
    void Update()
    {
        //Dialogue text  
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x)- fSideMargin) / divideValue, 1);
        if (cardGameObject.transform.position.x > fSideTregger)
        {
         
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                NewCard();
            }
        }
        else if(cardGameObject.transform.position.x > fSideMargin)
        {
            
        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            textColor.a = 0;
           
        }
        else if (cardGameObject.transform.position.x > fSideTregger)
        {
            
        }
        else
        {
            UpdateDialogue();
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                NewCard();
            }
        }
        UpdateDialogue();

        //Movement
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
        }
        else
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector2(0, 0), fMovingSpeed);
        }
        //if (cardGameObject.transform.position.x > fSideMargin)
        //{
           
        //    dialogue.text = rightQoute;
        //    if (!Input.GetMouseButton(0) && cardGameObject.transform.position.x > fSideMargin)
        //    {
        //        currentCard.Right();
        //    }
        //}
        //else if (cardGameObject.transform.position.x < -fSideMargin)
        //{
        //    dialogue.text = leftQoute; 
             
        //    if (!Input.GetMouseButton(0) && cardGameObject.transform.position.x > fSideMargin)
        //    {
        //        currentCard.Left();
        //    }
        //}
        //else
        //{
        //   cardSpriteRenderer.color = Color.white; 
        //}

        display.text = "" + textColor.a;
    }
    public void LoadCard(Card card)
    {
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQoute = card.leftQuote;
        rightQoute = card.rightQuote;
        currentCard = card;
        characterDialogue.text = card.dialogue;
    }
    public void NewCard()
    {
        int rollDice = Random.Range(0, resourceManager.cards.Length);
        LoadCard(resourceManager.cards[rollDice]);
    }
}
