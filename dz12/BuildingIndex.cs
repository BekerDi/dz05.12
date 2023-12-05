using bank;
using System;
using System.Linq;

public class BuildingIndex
{
    private Building[] _buildings;

    public BuildingIndex(int capacity)
    {
        _buildings = new Building[capacity];
        for (int i = 0; i < capacity; i++)
        {
            _buildings[i] = new Building();
        }
    }

    // Индексатор для доступа к зданию по номеру
    public Building this[int buildingNumber]
    {
        get
        {
            return _buildings.FirstOrDefault(b => b.BuildingNumber == buildingNumber);
        }
    }
}

