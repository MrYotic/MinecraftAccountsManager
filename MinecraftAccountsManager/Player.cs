public sealed record Player
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
    public int Dimension, X, Y, Z, Health, Food;
}