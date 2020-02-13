//import React from 'react';
//import { Route } from 'react-router';
//import Layout from './components/Layout';
//import Home from './components/Home';
//import Counter from './components/Counter';
//import FetchData from './components/FetchData';

//export default () => (
//  <Layout>
//    <Route exact path='/' component={Home} />
//    <Route path='/counter' component={Counter} />
//    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
//  </Layout>
//);
import React, { Component } from 'react';
//import { Route } from 'react-router';
import { Router, Route, Switch, Redirect } from "react-router-dom";

import { Layout } from "apt.utils/Layout.js";
import { Home } from 'apt.utils/Home.js';
import { FetchData } from 'apt.utils/FetchData.js';
import { Counter } from 'apt.utils/Counter.js';
import AuthorizeRoute from 'components/Authorization/AuthorizeRoute.js';
import ApiAuthorizationRoutes from 'components/Authorization/ApiAuthorizationRoutes.js';
import { ApplicationPaths } from 'components/Authorization/ApiAuthorizationConstants.js';

import { Provider } from "react-redux";
import { createStore } from "redux";
import Admin from "layouts/Admin.js";

import 'custom.css';
import SignIn from "apt.views/sessionmanagement/SignIn";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return ( 
      <Layout>
        <Switch> 
          <AuthorizeRoute path="/admin" component={Admin} />
          <Route exact path='/' component={Home} />
          <Route exact path='/SignIn' component={SignIn} />
          <Route path='/counter' component={Counter} />
          <AuthorizeRoute path='/fetch-data' component={FetchData} />
          <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
        </Switch>
      </Layout> 
    );
  }
}
