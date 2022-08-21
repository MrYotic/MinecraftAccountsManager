using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftAccountsManager;
public class Player
{
    public Player(int dimension, int x, int y, int z, int health, int food)
    {
        Dimension = dimension;
        X = x;
        Y = y;
        Z = z;
        Health = health;
        Food = food;
    }
    public int Dimension { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int Health { get; set; }
    public int Food { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if(obj is not Player)
            return false;
        Player p = (Player)obj;
        if (Dimension != p.Dimension || X != p.X || Y != p.Y || Z != p.Z || Health != p.Health || Food != p.Food)
            return false;
        return true;
    }
}