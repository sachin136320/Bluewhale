/*!

=========================================================
* Material Dashboard React - v1.8.0
=========================================================

* Product Page: https://www.creative-tim.com/product/material-dashboard-react
* Copyright 2019 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/material-dashboard-react/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/

//Get list of material ui icon from here
//https://takeai.silverpigeon.jp/icon-list-material-ui-30-nov-2018/

// @material-ui/icons
import HomeOutlined from "@material-ui/icons/HomeOutlined";
import Person from "@material-ui/icons/Person";
import LibraryBooks from "@material-ui/icons/LibraryBooks";
import BubbleChart from "@material-ui/icons/BubbleChart";
import LocationOn from "@material-ui/icons/LocationOn";
import Notifications from "@material-ui/icons/Notifications";
import SettingsTowTone from "@material-ui/icons/SettingsTwoTone";
import Language from "@material-ui/icons/Language";
// core components/views for Admin layout
import DashboardPage from "views/Dashboard/Dashboard.js";
import UserProfile from "views/UserProfile/UserProfile.js";
import TableList from "views/TableList/TableList.js";
import Typography from "views/Typography/Typography.js";
import Icons from "views/Icons/Icons.js";
import Maps from "views/Maps/Maps.js";
import NotificationsPage from "views/Notifications/Notifications.js";
import UpgradeToPro from "views/UpgradeToPro/UpgradeToPro.js";
// core components/views for RTL layout
import RTLPage from "views/RTLPage/RTLPage.js";

import OwnersCorner from "apt.views/owners/OwnersCorner.js";
import HouseKeeping from "apt.views/housekeeping/Housekeeping.js";
import AptDashboard from "apt.views/dashboard/AptDashboard.js";

const dashboardRoutes = [
  {
    path: "/dashboard",
    name: "Home", 
    icon: HomeOutlined,
    component: AptDashboard, //AptDashboard, //DashboardPage
    layout: "/admin"
  },
  {
    path: "/table",
    name: "Owner's Corner", 
    icon: "content_paste",
    component: OwnersCorner, //TableList, //OwnersCorner,
    layout: "/admin"
  },
  {
    path: "/typography",
    name: "Housekeeping", 
    icon: LibraryBooks,
    component: HouseKeeping, //Typography, //HouseKeeping,
    layout: "/admin"
  },
  {
    path: "/icons",
    name: "Visitor Management", 
    icon: BubbleChart,
    component: Icons,
    layout: "/admin"
  },
  {
    path: "/maps",
    name: "Parking Management", 
    icon: LocationOn,
    component: Maps,
    layout: "/admin"
  },
  {
    path: "/rtl-page",
    name: "Asset Management", 
    icon: Language,
    component: RTLPage,
    layout: "/rtl"
  },
  {
    path: "/user",
    name: "Facility Booking", 
    icon: Person,
    component: UserProfile,
    layout: "/admin"
  },
  {
    path: "/notifications",
    name: "Notifications", 
    icon: Notifications,
    component: NotificationsPage,
    layout: "/admin"
  },
  {
    path: "/upgrade-to-pro",
    name: "Configure Basic Settings", 
    icon: SettingsTowTone,
    component: UpgradeToPro,
    layout: "/admin"
  }
];

export default dashboardRoutes;
