import React, { Component, Fragment } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from './AuthorizeService';
import { ApplicationPaths, QueryParameterNames } from './ApiAuthorizationConstants';
import styles from "assets/jss/material-dashboard-react/components/headerLinksStyle.js";

import { makeStyles } from "@material-ui/core/styles";
import MenuItem from "@material-ui/core/MenuItem";



export class LoginMenu1 extends Component {
    constructor(props) {
        super(props);

        this.classes = makeStyles(styles);

        this.state = {
            isAuthenticated: false,
            userName: null
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            userName: user && user.name
        });
    }

    render() {
        const { isAuthenticated, userName } = this.state;
        if (!isAuthenticated) {
            const registerPath = `${ApplicationPaths.Register}`;
            const loginPath = `${ApplicationPaths.Login}`;
            return this.anonymousView(registerPath, loginPath, this.classes);
        } else {
            const profilePath = `${ApplicationPaths.Profile}`;
            const redirectUrl = `${ApplicationPaths.LogOut}?${QueryParameterNames.ReturnUrl}=${encodeURI("/admin")}`
        
            const logoutPath = { pathname: ApplicationPaths.LogOut, state: { local: true } };
            return this.authenticatedView(userName, profilePath, logoutPath, this.classes);
        }
    }

    authenticatedView(userName, profilePath, logoutPath, classes) {
        return (<Fragment>
            <NavLink tag={Link} className="text-dark" to={logoutPath}>Logout</NavLink>
        </Fragment>);

    }

    anonymousView(registerPath, loginPath, classes) {
        return (<Fragment>
            <NavLink tag={Link} className="text-dark" to={loginPath}>Logout anonymousView</NavLink>
        </Fragment>);
    }
}
