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
                return new Enemy(100f, Color.red, 2.0f);
            }
            if (name == "green")
            {
                return new Enemy(50f, Color.green, 1.0f);
            }
            if (name == "yellow")
            {
                return new Enemy(25f, Color.yellow, 1.5f);
            }
            else
            {
                return new Enemy(0f, Color.white, 0.0f);
            }
        }
    }
    class Enemy
    {
        float hp;
        Color color;
        float speed_factor;
        public Enemy(float HP, Color new_color, float factor)
        {
            hp = HP;
            color = new_color;
            speed_factor = factor;
        }
        public float getHp()
        {
            return hp;
        }
        public Color getColor()
        {
            return color;
        }
        public float getSpeedFactor(){
            return speed_factor;
        }
    }
    class Levels{
// string[] enemies = {
//         "red", "red", "red", "red",
//         "yellow", "yellow", "yellow",
//         "green", "green", "green", "green",
//         "green"
//     };
            private static Dictionary<int, (string,float)[] > levels = new Dictionary<int, (string,float)[] >(){
                {1, new (string,float)[]{("red", 5.0f), ("red", 5.85f), ("red", 6.88f), ("red", 7.82f),
                ("red", 8.87f), ("red", 9.90f), ("yellow", 13.38f), ("green", 13.67f), ("yellow", 14.29f), 
                ("green", 14.57f), ("yellow", 15.17f), ("green", 15.47f), ("red", 16.16f), ("red", 16.67f),
                ("red", 16.92f), ("green", 17.72f), ("green", 18.02f), ("yellow", 18.65f), ("yellow", 18.85f), 
                ("green", 19.52f), ("green", 19.84f), ("green", 20.14f), ("green", 20.42f)}}
            };
            //levels associated with list of spawn times for certain balloons
            public static Dictionary<int, (string,float)[]> getLevels(){
                return levels;
            }
    }
}
