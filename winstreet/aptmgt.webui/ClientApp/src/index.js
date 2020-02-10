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
import React from "react";
import ReactDOM from "react-dom";
import { createBrowserHistory } from "history";
import { Router, Route, Switch, Redirect } from "react-router-dom";
import AuthorizeRoute from './components/Authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/Authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/Authorization/ApiAuthorizationConstants';

//import 'bootstrap/dist/css/bootstrap.css'; 
import { BrowserRouter } from 'react-router-dom';
import App from 'App.js';

// core components
import Admin from "layouts/Admin.js";
import RTL from "layouts/RTL.js";

import { Layout } from "apt.utils/Layout.js";
import { Home } from 'apt.utils/Home.js';

import "assets/css/material-dashboard-react.css?v=1.8.0";

import { FetchData } from 'apt.utils/FetchData.js';
import { Counter } from 'apt.utils/Counter.js'; 

//const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');


const hist = createBrowserHistory();

ReactDOM.render(
  <Router history={hist}>
    <Switch>
      <AuthorizeRoute path="/admin" component={Admin} />
      <AuthorizeRoute exact path='/' component={Admin} />
      <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
    </Switch>
  </Router>,
  rootElement);


/*
ReactDOM.render(
  <Router history={hist} basename={"https://localhost:5001"}>
    <App />
  </Router>,
  rootElement);
*/

/*ReactDOM.render(
  <Router history={hist}>
    <Switch>
      <Route path="/admin" component={Admin} />
      <Route path="/rtl" component={RTL} />
      <Redirect from="/" to="/admin/dashboard" />
    </Switch>
  </Router>,
  document.getElementById("root")
);
*/