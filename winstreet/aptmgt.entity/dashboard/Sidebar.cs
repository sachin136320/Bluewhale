using System;
using System.Collections.Generic;

namespace aptmgt.entity.dashboard
{
    public class Sidebar
    {
        public string path { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string component { get; set; }
        public string layout { get; set; }

        public static List<Sidebar> GetAdminSections()
        {
            List<Sidebar> adminSections = new List<Sidebar>();
            
            adminSections.Add(new Sidebar()
            {
                path = "/configurebasicsettings",
                name = "Configure Basic Settings",
                icon = "SettingsTowTone",
                component = "ConfigureBasicSettings",
                layout = "/admin"
            });


            return adminSections;
        }

        public static List<Sidebar> GetGenericSections()
        {
            List<Sidebar> genericSections = new List<Sidebar>();
            
            genericSections.Add(new Sidebar()
            {
                path = "/dashboard",
                name = "Home",
                icon = "HomeOutlined",
                component = "AptDashboard",
                layout = "/admin"
            });

            genericSections.Add(new Sidebar()
            {
                path = "/table",
                name = "Owner's Corner",
                icon = "content_paste",
                component = "OwnersCorner",
                layout = "/admin"
            });

            genericSections.Add(new Sidebar()
            {
                path = "/icons",
                name = "Visitor Management",
                icon = "BubbleChart",
                component = "VisitorDashBoard",
                layout = "/admin"
            });

            genericSections.Add(new Sidebar()
            {
                path = "/maps",
                name = "Parking Management",
                icon = "LocationOn",
                component = "Parking",
                layout = "/admin"
            });

            genericSections.Add(new Sidebar()
            {
                path = "/rtl-page",
                name = "Asset Management",
                icon = "Language",
                component = "AssetManagement",
                layout = "/admin"
            });
            
            return genericSections;
        }

    }
}
