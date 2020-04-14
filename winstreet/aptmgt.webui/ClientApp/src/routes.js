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
import React from "react";
import HomeOutlined from "@material-ui/icons/HomeOutlined";
import BubbleChart from "@material-ui/icons/BubbleChart";
import LocationOn from "@material-ui/icons/LocationOn";
import Notifications from "@material-ui/icons/Notifications";
import SettingsTowTone from "@material-ui/icons/SettingsTwoTone";
import Language from "@material-ui/icons/Language";
// core components/views for Admin layout

import OwnersCorner from "apt.views/owners/OwnersCorner.js";
import AptDashboard from "apt.views/dashboard/AptDashboard.js";
import ConfigureBasicSettings from "apt.views/configuresettings/ConfigureBasicSettings.js";
import VisitorDashBoard from "apt.views/visitors/VisitorDashBoard.js";
import AssetManagement from "apt.views/assets/AssetManagement";
import Parking from "apt.views/parking/Parking.js";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';
  
const dashboardRoutes1 = [
  {
    path: "/dashboard",
    name: "Home",
    icon: "HomeOutlined",
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
    path: "/icons",
    name: "Visitor Management",
    icon: "BubbleChart",
    component: VisitorDashBoard, //Icons,
    layout: "/admin"
  },
  {
    path: "/maps",
    name: "Parking Management",
    icon: "LocationOn",
    component: Parking, //Maps,
    layout: "/admin"
  },
  {
    path: "/rtl-page",
    name: "Asset Management",
    icon: "Language",
    component: AssetManagement, //RTLPage,
    layout: "/admin", // "/rtl"
  },
  {
    path: "/configurebasicsettings",
    name: "Configure Basic Settings",
    icon: "SettingsTowTone",
    component: ConfigureBasicSettings,
    layout: "/admin"
  }
];

function functionReponse() {
  //const sections = await loadData(); 
  const Components = {
    AptDashboard: AptDashboard,
    OwnersCorner: OwnersCorner,
    VisitorDashBoard: VisitorDashBoard,
    Parking: Parking,
    AssetManagement: AssetManagement,
    ConfigureBasicSettings: ConfigureBasicSettings
  };

  const token = authService.getAccessToken();

  API.get('/SideBar', {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  }).then(({ data }) => {
    data.map((prop, key) => {
      prop.component = Components[prop.component];
    });
    console.log(data);
    return data;
  });
}
 
const dash = functionReponse();

export default dashboardRoutes1;

/*
  {
    path: "/typography",
    name: "Housekeeping",
    icon: LibraryBooks,
    component: HouseKeeping, //Typography, //HouseKeeping,
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
      path: "/user",
      name: "Facility Booking",
      icon: Person,
      component: FacilityBooking, //UserProfile,
      layout: "/admin"
  },
*/