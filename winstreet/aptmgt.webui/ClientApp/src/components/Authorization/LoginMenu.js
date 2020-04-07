import React, { Component, Fragment } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';
import Divider from "@material-ui/core/Divider";
import MenuItem from "@material-ui/core/MenuItem";
import styles from "assets/jss/material-dashboard-react/components/headerLinksStyle.js";
import { makeStyles } from "@material-ui/core/styles";



export class LoginMenu extends Component {
    constructor(props) {
        super(props);

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
            return this.anonymousView(registerPath, loginPath);
        } else {
            const profilePath = `${ApplicationPaths.Profile}`;
            const logoutPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
            return this.authenticatedView1(userName, profilePath, logoutPath);
        }
    }

    authenticatedView(userName, profilePath, logoutPath) {
        return (<Fragment>
            <NavItem>
                <NavLink tag={Link} className="text-dark" to={profilePath}>{userName}</NavLink>
            </NavItem>
            <Divider light />
            <NavItem>
                {console.log(logoutPath)}
                <NavLink tag={Link} className="text-dark" to={logoutPath}>Logout</NavLink>
            </NavItem>
        </Fragment>);

    }

    authenticatedView1(userName, profilePath, logoutPath) { 
        return (<Fragment>
            <MenuItem>
                <NavLink tag={Link} className="text-dark" to={profilePath}>{userName}</NavLink>
            </MenuItem>
            <Divider light />
            <MenuItem >
                {console.log(logoutPath)}
                <NavLink tag={Link} className="text-dark" to={logoutPath}>Logout</NavLink>
            </MenuItem>
        </Fragment>);

    }

    anonymousView(registerPath, loginPath) {
        return (<Fragment>
            <NavItem>
                <NavLink tag={Link} className="text-dark" to={registerPath}>Register</NavLink>
            </NavItem>
            <Divider light />
            <NavItem>
                <NavLink tag={Link} className="text-dark" to={loginPath}>Login1</NavLink>
            </NavItem>
        </Fragment>);
    }
}
