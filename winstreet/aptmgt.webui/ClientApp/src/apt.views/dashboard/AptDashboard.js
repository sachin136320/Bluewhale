import React, { useState, useEffect } from "react";
// @material-ui/core
import { makeStyles, responsiveFontSizes } from "@material-ui/core/styles";
// @material-ui/icons 
import AccessTime from "@material-ui/icons/AccessTime";
import BugReport from "@material-ui/icons/BugReport";
import Code from "@material-ui/icons/Code";
import Cloud from "@material-ui/icons/Cloud";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Table from "components/Table/Table.js";
import Tasks from "components/Tasks/Tasks.js";
import CustomTabs from "components/CustomTabs/CustomTabs.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";

import { bugs, website, server } from "variables/general.js";

import styles from "assets/jss/material-dashboard-react/views/dashboardStyle.js";
import API from "apt.utils/API.js";
import axios from "axios";

import authService from 'components/Authorization/AuthorizeService.js';

const useStyles = makeStyles(styles);


export default function AptDashboard() {
  const classes = useStyles();

  const [primaryCard, setPrimaryCard] = useState([]);
  const [ownerCard, setOwnerCard] = useState([]);
  const [visitorsCard, setVisitorsCard] = useState([]);
  const [assetsCard, setAssetsCard] = useState([]);
  const [parkingCard, setParkingCard] = useState([]);
  const [facilityCard, setFacilityCard] = useState([]);

  useEffect(() => {

    // Create an scoped async function in the hook
    async function loadData() {
      const token = await authService.getAccessToken();
      //console.log(token);

      await API.get('/DashboardCard', {
        params: {
          cardID: 'primary'
        },
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
      }).then(({ data }) => {
        setPrimaryCard(prepareArray(data.dashboardCardItems));
      });


      await API.get('/DashboardCard', {
        params: {
          cardID: 'owner'
        },
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
      }).then(({ data }) => {
        setOwnerCard(prepareArray(data.dashboardCardItems));
      });
  
  
      await API.get('/DashboardCard', {
        params: {
          cardID: 'visitors'
        },
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
      }).then(({ data }) => {
        setVisitorsCard(prepareArray(data.dashboardCardItems));
      });
  
      await API.get('/DashboardCard', {
        params: {
          cardID: 'assets'
        },
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
      }).then(({ data }) => {
        setAssetsCard(prepareArray(data.dashboardCardItems));
      });
  
      await API.get('/DashboardCard', {
        params: {
          cardID: 'parking'
        },
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
      }).then(({ data }) => {
        setParkingCard(prepareArray(data.dashboardCardItems));
      });
  
      await API.get('/DashboardCard', {
        params: {
          cardID: 'facility'
        },
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
      }).then(({ data }) => {
        setFacilityCard(prepareArray(data.dashboardCardItems));
      });

    }

    // Execute the created function directly
    loadData();

    console.log("crosseD");


    /*
        API.get('/DashboardCard', {
          params: {
            cardID: 'primary'
          },
          headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
          setPrimaryCard(prepareArray(data.dashboardCardItems));
        });
    
        */
  }, []);


  const prepareArray = (data) => {
    const dataRows = [];
    for (var key in data) {
      dataRows.push([key, data[key].toString()]);
    }
    return dataRows;
  };


  return (
    <div>
      <GridContainer>
        <GridItem xs={12} sm={12} md={4}>
          <Card chart>
            <CardHeader color="info">
              <p className={classes.cardTitleBlack}>HiLife Whistling Winds</p>
            </CardHeader>
            <CardBody>
              <Table
                tableData={
                  primaryCard
                }
              />
            </CardBody>
            <CardFooter chart>
              <div className={classes.stats}>
                <AccessTime /> updated 4 minutes ago
              </div>
            </CardFooter>
          </Card>
        </GridItem>
        <GridItem xs={12} sm={12} md={4}>
          <Card chart>
            <CardHeader color="warning">
              <p className={classes.cardTitleBlack}>Owners</p>
            </CardHeader>
            <CardBody>
              <Table
                tableData={ownerCard}
              />
            </CardBody>
            <CardFooter chart>
              <div className={classes.stats}>
                <AccessTime /> updated 7 minutes ago
              </div>
            </CardFooter>
          </Card>
        </GridItem>
        <GridItem xs={12} sm={12} md={4}>
          <Card chart>
            <CardHeader color="danger">
              <p className={classes.cardTitleBlack}>Visitors in Society</p>
            </CardHeader>
            <CardBody>
              <Table
                tableData={[
                  ["Current Checked in Visitors", "6"],
                  ["Resident Visitors", "4"],
                  ["Non Resident Visitors", "1"],
                  ["Delivery Visitors", "0"]
                ]}
              />
            </CardBody>
            <CardFooter chart>
              <div className={classes.stats}>
                <AccessTime /> updated 1 minutes ago
              </div>
            </CardFooter>
          </Card>
        </GridItem>
      </GridContainer>
      <GridContainer>
        <GridItem xs={12} sm={12} md={4}>
          <Card chart>
            <CardHeader color="success">
              <p className={classes.cardTitleBlack}>Parking</p>
            </CardHeader>
            <CardBody>
              <Table
                tableData={[
                  ["Total vehicles in society", "7"],
                  ["Assigned parking slots", "3"],
                  ["Unassigned parking slots", "323"],
                  ["Assigned and Occupied", "2"],
                  ["Assigned but oncccupied", "3"]
                ]}
              />
            </CardBody>
            <CardFooter chart>
              <div className={classes.stats}>
                <AccessTime /> updated 4 minutes ago
              </div>
            </CardFooter>
          </Card>
        </GridItem>
        <GridItem xs={12} sm={12} md={4}>
          <Card chart>
            <CardHeader color="warning">
              <p className={classes.cardTitleBlack}>Assets</p>
            </CardHeader>
            <CardBody>
              <Table
                tableData={[
                  ["Total Assets", "7"],
                  ["Upcoming assets for service", "0"],
                  ["Overdue assets for service", "4"]
                ]}
              />
            </CardBody>
            <CardFooter chart>
              <div className={classes.stats}>
                <AccessTime /> campaign sent 2 days ago
              </div>
            </CardFooter>
          </Card>
        </GridItem>
        <GridItem xs={12} sm={12} md={4}>
          <Card chart>
            <CardHeader color="danger">
              <p className={classes.cardTitleBlack}>Facility Booking Status</p>
            </CardHeader>
            <CardBody>
              <Table
                tableData={[
                  ["Bookable Facility", "4"],
                  ["Facility Booked for next 7 days", "0"],
                  ["Booking pending approvals", "0"]
                ]}
              />
            </CardBody>
            <CardFooter chart>
              <div className={classes.stats}>
                <AccessTime /> campaign sent 2 days ago
              </div>
            </CardFooter>
          </Card>
        </GridItem>
      </GridContainer>
      <GridContainer>
        <GridItem xs={12} sm={12} md={12}>
          <CustomTabs
            title="Complaints Helpdesk:"
            headerColor="primary"
            tabs={[
              {
                tabName: "New Tickets",
                tabIcon: BugReport,
                tabContent: (
                  <Tasks
                    checkedIndexes={[0, 3]}
                    tasksIndexes={[0, 1, 2, 3]}
                    tasks={bugs}
                  />
                )
              },
              {
                tabName: "Open Tickets",
                tabIcon: Code,
                tabContent: (
                  <Tasks
                    checkedIndexes={[0]}
                    tasksIndexes={[0, 1]}
                    tasks={website}
                  />
                )
              },
              {
                tabName: "Closed Tickets",
                tabIcon: Cloud,
                tabContent: (
                  <Tasks
                    checkedIndexes={[1]}
                    tasksIndexes={[0, 1, 2]}
                    tasks={server}
                  />
                )
              }
            ]}
          />
        </GridItem>

      </GridContainer>
      <GridContainer>
        <GridItem xs={12} sm={12} md={12}>
          <Card>
            <CardHeader color="warning">
              <h4 className={classes.cardTitleWhite}>Housing Keeping Status</h4>
              <p className={classes.cardCategoryWhite}>
                Current housekeeping items
              </p>
            </CardHeader>
            <CardBody>
              <Table
                tableHeaderColor="warning"
                tableHead={["ID", "Item", "Status", "Priority"]}
                tableData={[
                  ["1", "Daily clening", "InProgress", "High"]
                ]}
              />
            </CardBody>
          </Card>
        </GridItem>
      </GridContainer>
    </div>
  );
}
