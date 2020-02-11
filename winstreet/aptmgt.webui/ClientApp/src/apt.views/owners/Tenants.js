import React, { useContext, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardIcon from "components/Card/CardIcon.js";
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";

import ChartistGraph from "react-chartist";

import Icon from "@material-ui/core/Icon";
import Danger from "components/Typography/Danger.js";
import Store from "@material-ui/icons/Store";
import Warning from "@material-ui/icons/Warning";
import DateRange from "@material-ui/icons/DateRange";
import LocalOffer from "@material-ui/icons/LocalOffer";
import Table from "components/Table/Table.js";
import Update from "@material-ui/icons/Update";
import Accessibility from "@material-ui/icons/Accessibility";
import { UserContext } from "store/UserContext";

import API from "apt.utils/API.js"; 
import authService from 'components/Authorization/AuthorizeService.js';

import {
  dailySalesChart,
  emailsSubscriptionChart,
  completedTasksChart
} from "variables/charts.js";

import {
  successColor,
  whiteColor,
  grayColor,
  hexToRgb,
  blackColor
} from "assets/jss/material-dashboard-react.js";

const styles = {
  cardCategory: {
    color: grayColor[0],
    margin: "0",
    fontSize: "14px",
    marginTop: "0",
    paddingTop: "10px",
    marginBottom: "0"
  },
  cardTitle: {
    color: grayColor[2],
    marginTop: "0px",
    minHeight: "auto",
    fontWeight: "300",
    fontFamily: "'Roboto', 'Helvetica', 'Arial', sans-serif",
    marginBottom: "3px",
    textDecoration: "none",
    "& small": {
      color: grayColor[1],
      fontWeight: "400",
      lineHeight: "1"
    }
  },
  cardCategoryWhite: {
    "&,& a,& a:hover,& a:focus": {
      color: "rgba(255,255,255,.62)",
      margin: "0",
      fontSize: "14px",
      marginTop: "0",
      marginBottom: "0"
    },
    "& a,& a:hover,& a:focus": {
      color: "#FFFFFF"
    }
  },
  cardTitleWhite: {
    color: "#FFFFFF",
    marginTop: "0px",
    minHeight: "auto",
    fontWeight: "300",
    fontFamily: "'Roboto', 'Helvetica', 'Arial', sans-serif",
    marginBottom: "3px",
    textDecoration: "none",
    "& small": {
      color: "#777",
      fontSize: "65%",
      fontWeight: "400",
      lineHeight: "1"
    }
  }, container: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  textField: {
    marginLeft: 1,
    marginRight: 1,
    width: 200,
  },
};

const useStyles = makeStyles(styles);

export default function Tenants() {
  const classes = useStyles();
  const [communityid, setCommunityID] = useContext(UserContext);

  const [tenantcompliant, setTenantCompliant] = React.useState('');
  const [tenantnoncompliant, setTenantNonCompliant] = React.useState('');
  const [agreementsubmitted, setAgreementSubmitted] = React.useState('');
  const [agreementnotsubmitted, setAgreementNotSubmitted] = React.useState('');
  const [expiringrentagreement, setExpiringRentAgreement] = React.useState('');
 
  
  useEffect(() => {
    // Create an scoped async function in the hook
    async function loadMetrics() {
      const token = await authService.getAccessToken();
      await API.get('/TenantMetrics', { 
        params: {
          commID: communityid
        },
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
      }).then(({ data }) => {  
        console.log(data.agreementCopyNotSubmitted);
        setTenantCompliant(data.tenantCompliant);
        setTenantNonCompliant(data.tenantNonCompliant);
        setAgreementSubmitted(data.agreementCopySubmitted);
        setAgreementNotSubmitted(data.agreementCopyNotSubmitted);
        setExpiringRentAgreement(data.expiringRentAgreement); 
      });
    }
    if (!communityid) {
      alert("Please select communty ID.")
    } else {
      loadMetrics();
    }
    // Execute the created function directly 
  }, []);

  return (
    <GridContainer>
      <GridItem xs={12} sm={8} md={4}>
        <Card chart>
          <CardHeader color="info" stats icon>
            <ChartistGraph
              className="ct-chart"
              data={emailsSubscriptionChart.data}
              type="Bar"
              options={emailsSubscriptionChart.options}
              responsiveOptions={emailsSubscriptionChart.responsiveOptions}
              listener={emailsSubscriptionChart.animation}
            />
            <CardIcon color="info">
              <Icon>content_copy</Icon>
            </CardIcon>
            <p className={classes.cardCategory}>Police Verification</p>
            <h3 className={classes.cardTitle}>
              {tenantcompliant}/{tenantnoncompliant} <small>compliant/non-complaint</small>
            </h3>
          </CardHeader>
          <CardBody>
            <Table
              tableData={[
                ["Police Verification Compliant Status", tenantcompliant],
                ["Police Verification Non-compliant Status", tenantnoncompliant]
              ]}
            />
          </CardBody>
        </Card>
      </GridItem>
      <GridItem xs={12} sm={8} md={4}>
        <Card>
          <CardHeader color="success" stats icon>
            <CardIcon color="success">
              <Store />
            </CardIcon>
            <p className={classes.cardCategory}>{agreementsubmitted} Agreement Copy Submitted</p>
            <h3 className={classes.cardTitle}>{agreementnotsubmitted} pending</h3>
          </CardHeader>
          <CardBody>
            <Table
              tableData={[
                ["Agreement Copy Submitted", agreementsubmitted],
                ["Agreement Copy Not Submitted", agreementnotsubmitted]
              ]}
            />
          </CardBody>
        </Card>
      </GridItem>
      <GridItem xs={12} sm={8} md={4}>
        <Card>
          <CardHeader color="danger" stats icon>
            <CardIcon color="danger">
              <Icon>info_outline</Icon>
            </CardIcon>
            <p className={classes.cardCategory}>Alerts</p>
            <h3 className={classes.cardTitle}>{expiringrentagreement}</h3>
          </CardHeader>
          <CardBody>
            <Table
              tableData={[
                ["Expiring rent agreement in next 30 days", expiringrentagreement],
              ]}
            />
          </CardBody>
        </Card>
      </GridItem>

    </GridContainer>
  );
}