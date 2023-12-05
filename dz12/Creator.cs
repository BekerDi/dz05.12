using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class Creator
    {
        private static Dictionary<int, Building> buildingList = new Dictionary<int, Building>();

        private Creator() { }

        public static Building CreateBuilding(int number, string name)
        {
            Building building = new Building(number, name);
            buildingList.Add(number, building);
            return building;
        }

        public static Building CreateBuildingWithDefaultName(int number)
        {
            return CreateBuilding(number, "Имя");
        }

        public static void RemoveBuilding(int number)
        {
            if (buildingList.ContainsKey(number))
            {
                buildingList.Remove(number);
            }
        }
    }
}



