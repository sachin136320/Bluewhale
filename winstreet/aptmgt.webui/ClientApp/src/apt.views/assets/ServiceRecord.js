import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import MaterialTable from "material-table"; 

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

const TableData = [
  { title: 'Name', field: 'name', editable: 'onUpdate' },
  { title: 'Surname', field: 'surname', editable: 'never' },
  { title: 'Flat', field: 'flatNumber', type: 'text' },
  {
    title: 'Block',
    field: 'block',
    lookup: { 34: 'İstanbul', 63: 'Şanlıurfa' },
  },
];
const data = [
  { name: 'Mehmet', surname: 'Baran', flatNumber: 'D', block: 63 },
  { name: 'Zerya Betül', surname: 'Baran', flatNumber: 'D', block: 34 },
];
const useStyles = makeStyles(styles);

export default function ServiceRecord() {
  const classes = useStyles();
  return (
    <GridContainer>
      <GridItem xs={12} sm={12} md={12}>
        <Card>
          <MaterialTable
            title="hj"
            columns={TableData}
            data={data}
            options={{
              selection: true,
              filtering: true
            }}
            actions={[
              {
                tooltip: 'Procured',
                icon: 'delete',
                onClick: (evt, data) => alert('You want to delete ' + data.length + ' rows')
              },
              {
                tooltip: 'Not Procured',
                icon: 'delete',
                onClick: (evt, data) => alert('You want to delete ' + data.length + ' rows')
              },
              {
                tooltip: 'Approved',
                icon: 'delete',
                onClick: (evt, data) => alert('You want to delete ' + data.length + ' rows')
              },
              {
                tooltip: 'Reject',
                icon: 'delete',
                onClick: (evt, data) => alert('You want to delete ' + data.length + ' rows')
              }
            ]}
            editable={{
              onRowUpdate: (newData, oldData) =>
                new Promise((resolve, reject) => {
                  setTimeout(() => {
                    {
                      const data = this.state.data;
                      const index = data.indexOf(oldData);
                      data[index] = newData;
                      this.setState({ data }, () => resolve());
                    }
                    resolve()
                  }, 1000)
                }),
              onRowDelete: oldData =>
                new Promise((resolve, reject) => {
                  setTimeout(() => {
                    {
                      let data = this.state.data;
                      const index = data.indexOf(oldData);
                      data.splice(index, 1);
                      this.setState({ data }, () => resolve());
                    }
                    resolve()
                  }, 1000)
                }),
            }}
          />
        </Card>
      </GridItem>
    </GridContainer>
  );
}