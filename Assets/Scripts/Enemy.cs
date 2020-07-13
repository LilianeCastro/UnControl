﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _Player;
    private GameController _GameController;

    public string nameGameObjectPlayerToFollow;
    public string tagToCompare;

    public float speed;

    void Start()
    {
        _Player = GameObject.Find(nameGameObjectPlayerToFollow).GetComponent<Player>();
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        if(this.tag=="purifier")
        {
            speed = _GameController.getSpeedPurifier();
        }
        else
        {
            speed = _GameController.getSpeedCorrupter();
        }
    }

    void Update()
    {
        if(_Player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _Player.transform.position, speed * Time.deltaTime);
            transform.up = _Player.transform.position - transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag(tagToCompare))
        {
            _GameController.setStatusEndGame();
        }

        if(other.CompareTag("shot"))
        {
            _Player.destroyedTheEnemyCalled(this.tag);
            Destroy(this.gameObject);
        }

    }
}
