﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Actor", menuName = "Create Actor")]
public class SOActorModel : ScriptableObject
{
    public string actorName;
    public AttackType attackType;
    public string description;
    public int health;
    public int speed;
    public int hitPower;
    public GameObject actor;
    public GameObject actorBullets;
}
