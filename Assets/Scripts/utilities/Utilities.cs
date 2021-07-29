using System;
using System.Collections.Generic;
using UnityEngine;
namespace Utilities
{
    class EnemiesManager
    {
        public static Enemy getEnemy(string enemy)
        {
            string name = enemy.ToLower();
            if (name == "red")
            {
                return new Enemy(100f, Color.red);
            }
            if (name == "green")
            {
                return new Enemy(50f, Color.green);
            }
            if (name == "yellow")
            {
                return new Enemy(25f, Color.yellow);
            }
            else
            {
                return new Enemy(0f, Color.white);
            }
        }
    }
    class Enemy
    {
        float hp;
        Color color;
        public Enemy(float HP, Color new_color)
        {
            hp = HP;
            color = new_color;
        }
        public float getHp()
        {
            return hp;
        }
        public Color getColor()
        {
            return color;
        }
    }
}
