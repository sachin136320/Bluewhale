using System;
using aptmgt.entity.intfc;
using System.Collections.Generic;

namespace aptmgt.entity.impl
{
    public class DashboardCard : IDashboardCard
    {
        public DashboardCard(string cardID)
        {
            switch (cardID.ToLower())
            {
                case "primary":
                    _dashboardCardItems.Add("Block/Wings", 6);
                    _dashboardCardItems.Add("Facility Available", 5);
                    _dashboardCardItems.Add("Bookable Facility", 4);
                    break;
                case "owner":
                    _dashboardCardItems.Add("Total No of Flats", 6);
                    _dashboardCardItems.Add("Unoccupied", 5);
                    _dashboardCardItems.Add("Total Rented", 4);
                    _dashboardCardItems.Add("Total Occupied", 4);
                    break;
                case "visitors":
                    _dashboardCardItems.Add("Block/Wings", 6);
                    _dashboardCardItems.Add("Facility Available", 5);
                    _dashboardCardItems.Add("Bookable Facility", 4);
                    break;
                case "assets":
                    _dashboardCardItems.Add("Block/Wings", 6);
                    _dashboardCardItems.Add("Facility Available", 5);
                    _dashboardCardItems.Add("Bookable Facility", 4);
                    break;
                case "parking":
                    _dashboardCardItems.Add("Block/Wings", 6);
                    _dashboardCardItems.Add("Facility Available", 5);
                    _dashboardCardItems.Add("Bookable Facility", 4);
                    break;

                case "facility":
                    _dashboardCardItems.Add("Block/Wings", 6);
                    _dashboardCardItems.Add("Facility Available", 5);
                    _dashboardCardItems.Add("Bookable Facility", 4);
                    break;
                case "complaints":
                    _dashboardCardItems.Add("Block/Wings", 6);
                    _dashboardCardItems.Add("Facility Available", 5);
                    _dashboardCardItems.Add("Bookable Facility", 4);
                    break;
                case "housekeeping":
                    _dashboardCardItems.Add("Block/Wings", 6);
                    _dashboardCardItems.Add("Facility Available", 5);
                    _dashboardCardItems.Add("Bookable Facility", 4);
                    break;
            }
        }

        Dictionary<string, int> _dashboardCardItems = new Dictionary<string, int>();
        public Dictionary<string, int> DashboardCardItems
        {
            get => _dashboardCardItems;
            set => _dashboardCardItems = value;
        }
    }
}
