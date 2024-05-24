using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    
    public Sprite DrunkSprite;
    
    public Sprite SoberSprite;

    public UI UI;

    private bool isDrunk = false;

    private bool isPlastered = false;

    private int randomMoveCountdown = 0;

    private int lastRandomDirection = 1;

    // Update is called once per frame
    void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    public void MoveManually(Vector2 direction)
    {
        if (isPlastered)
            return;
        Move(direction);
    }
    private void MoveRandomly()
    {
        int direction = lastRandomDirection;
            
        if (randomMoveCountdown == 0)
        {
            direction = Random.Range(1, 5);
            randomMoveCountdown = Random.Range(30, 60);
            lastRandomDirection = direction;
        }
        
        switch (direction)
        {
            case 1: 
                Move(new Vector2(1, 0));
                break;
            case 2: 
                Move(new Vector2(-1, 0));
                break;
            case 3: 
                Move(new Vector2(0, 1));
                break;
            case 4: 
                Move(new Vector2(0, -1));
                break;
        }

        randomMoveCountdown = randomMoveCountdown - 1;
    }

    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkeness(direction);
        
        FaceCorrectDirection(direction);
        
        float xAmount = direction.x * GameParameters.CorgiMoveSpeed;
        float yAmount = direction.y * GameParameters.CorgiMoveSpeed;
        
        CorgiSpriteRenderer.transform.Translate(xAmount, yAmount, 0f);

        KeepOnScreen();
    }

    private Vector2 ApplyDrunkeness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction = direction * -1;
        }
        return direction;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Beer")
        {
            GetDrunk();
        }
        if (other.tag == "Bone")
        {
            ScoreKeeper.Add(1);
            UI.ShowScore();
        }
        if (other.tag == "Pill")
        {
            SoberUp();
        }

        if (other.tag == "Moonshine")
        {
            GetPlastered();
        }
        Destroy(other.gameObject);
    }

    private void GetPlastered()
    {
        isPlastered = true;
        Inebriate();
    }

    private void Inebriate()
    {
        ChangeToDrunkSprite();
        StartSoberingUp();
    }

    private void GetDrunk()
    {
        isDrunk = true;
        Inebriate();
        // reverse controls
    }

    private void StartSoberingUp()
    {
        StartCoroutine(WaitToSoberUp());
    }

    IEnumerator WaitToSoberUp()
    {
        yield return new WaitForSeconds(GameParameters.SecondsDrunk);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;
        isPlastered = false;
        ChangeToSoberSprite();
    }

    private void ChangeToDrunkSprite()
    {
        CorgiSpriteRenderer.sprite = DrunkSprite;
    }
    
    private void ChangeToSoberSprite()
    {
        CorgiSpriteRenderer.sprite = SoberSprite;
    }

    private void KeepOnScreen()
    {
        CorgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            CorgiSpriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            CorgiSpriteRenderer.flipX = true;
        }
    }
}
