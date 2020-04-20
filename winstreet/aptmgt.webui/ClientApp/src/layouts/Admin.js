import React, { Component, useState } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
// creates a beautiful scrollbar
import PerfectScrollbar from "perfect-scrollbar";
import "perfect-scrollbar/css/perfect-scrollbar.css";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
// core components
import Navbar from "components/Navbars/Navbar.js";
import Footer from "components/Footer/Footer.js";
import Sidebar from "components/Sidebar/Sidebar.js";
import FixedPlugin from "components/FixedPlugin/FixedPlugin.js";

import {cube} from "routes1.js";
//import routes from "routes.js";

import styles from "assets/jss/material-dashboard-react/layouts/adminStyle.js";
import { UserContext } from "store/UserContext";

import bgImage from "assets/img/sidebar-2.jpg";
import logo from "assets/img/reactlogo.png";


import OwnersCorner from "apt.views/owners/OwnersCorner.js";
import AptDashboard from "apt.views/dashboard/AptDashboard.js";
import ConfigureBasicSettings from "apt.views/configuresettings/ConfigureBasicSettings.js";
import VisitorDashBoard from "apt.views/visitors/VisitorDashBoard.js";
import AssetManagement from "apt.views/assets/AssetManagement";
import Parking from "apt.views/parking/Parking.js";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';

let ps;

const Components = {
  AptDashboard: AptDashboard,
  OwnersCorner: OwnersCorner,
  VisitorDashBoard: VisitorDashBoard,
  Parking: Parking,
  AssetManagement: AssetManagement,
  ConfigureBasicSettings: ConfigureBasicSettings
}; 

const useStyles = makeStyles(styles);
const cube1 = cube();

export default function Admin({ ...rest }) {

  const [communityid, setCommunityID] = useState('silvanus');

  // styles
  const classes = useStyles();
  //console.log(classes);
  // ref to help us initialize PerfectScrollbar on windows devices
  const mainPanel = React.createRef();
  // states and functions
  const [image, setImage] = React.useState(bgImage);
  const [color, setColor] = React.useState("blue");
  const [fixedClasses, setFixedClasses] = React.useState("dropdown show");
  const [mobileOpen, setMobileOpen] = React.useState(false);
  const [routes, setRoute] = React.useState([]);

  Promise.resolve(cube1).then(function(value) {
    console.log(value); // "Success"
    setRoute(value);
  }, function(value) {
    // not called
  }); 

  //functionReponse(); 
  const switchRoutes = (  
    <Switch>
       {routes.map((prop, key) => {
         if (prop.layout === "/admin") {
           //console.log(prop); 
           return (
             <Route
               path={prop.layout + prop.path}
               component={prop.component}
               key={key}
             />
           );
         }
         return null;
       })}
       <Redirect from="/admin" to="/admin/dashboard" />
     </Switch>
     );
   //};
  const handleImageClick = image => {
    setImage(image);
  };
  const handleColorClick = color => {
    setColor(color);
  };
  const handleFixedClick = () => {
    if (fixedClasses === "dropdown") {
      setFixedClasses("dropdown show");
    } else {
      setFixedClasses("dropdown");
    }
  };
  const handleDrawerToggle = () => {
    setMobileOpen(!mobileOpen);
  };
  const getRoute = () => {
    return window.location.pathname !== "/admin/maps";
  };
  const resizeFunction = () => {
    if (window.innerWidth >= 960) {
      setMobileOpen(false);
    }
  };
 
  async function functionReponse() {
    const token = await authService.getAccessToken();
    await API.get('/SideBar', {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    }).then(({ data }) => {
      data.map((prop, key) => {
        prop.component = Components[prop.component];
      });
      console.log(data);
      setRoute(data); 
    });
  }

  // initialize and destroy the PerfectScrollbar plugin
  React.useEffect(() => { 
    //functionReponse(); 
    if (navigator.platform.indexOf("Win") > -1) { 
      ps = new PerfectScrollbar(mainPanel.current, {
        suppressScrollX: true,
        suppressScrollY: false
      });
      document.body.style.overflow = "hidden";
    }
    window.addEventListener("resize", resizeFunction);
    // Specify how to clean up after this effect:
    return function cleanup() {
      if (navigator.platform.indexOf("Win") > -1) {
        ps.destroy();
      }
      window.removeEventListener("resize", resizeFunction);
    };
  }, [mainPanel]);

  return (
    <UserContext.Provider value={{ communityid, setCommunityID }}>
      <div className={classes.wrapper}>
        <Sidebar
          routes={routes}
          logoText={"winsgate"}
          logo={logo}
          image={image}
          handleDrawerToggle={handleDrawerToggle}
          open={mobileOpen}
          color={color}
          {...rest}
        />
        <div className={classes.mainPanel} ref={mainPanel}>
          <Navbar
            routes={routes}
            handleDrawerToggle={handleDrawerToggle}
            {...rest}
          />
          {/* On the /maps route we want the map to be on full screen - 
        this is not possible if the content and conatiner classes are 
        present because they have some paddings which would make the map smaller */}
          {getRoute() ? (
            <div className={classes.content}>
              <div className={classes.container}>{switchRoutes}</div>
            </div>
          ) : (
              <div className={classes.map}>{switchRoutes}</div>
            )}
          {getRoute() ? <Footer /> : null}
          {/*
        <FixedPlugin
          handleImageClick={handleImageClick}
          handleColorClick={handleColorClick}
          bgColor={color}
          bgImage={image}
          handleFixedClick={handleFixedClick}
          fixedClasses={fixedClasses}
        />
        */}
        </div>
      </div>
    </UserContext.Provider>
  );
}
