import React, { useState, useEffect, useContext } from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import { UserContext } from "store/UserContext";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';
import Card from "components/Card/Card.js";
import ServiceHistory from "./ServiceHistory";

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

const columns = [
  { title: 'Asset Name', field: 'assetname', type: 'string' },
  { title: 'Serviceable', field: 'serviceable', type: 'boolean' },
  { title: 'Service Frequency', field: 'servicefrequency', type: 'string' },
  { title: 'Last Service Date', field: 'lastservicedate', type: 'date' },
  { title: 'Last Service Notes', field: 'lastservicenotes', type: 'string' },
  { title: 'Next Service Date', field: 'nextservicedate', type: 'date' }
]

export default function ServiceRecord() {

  const classes = useStyles();
  const { communityid, setCommunityID } = useContext(UserContext);

  const [assetservicedata, setAssetServiceData] = useState([]); 

  useEffect(() => {
    async function loadOpenRequest(commid) {
        const token = await authService.getAccessToken();
        await API.get('/Asset/GetServiceDetails', {
            params: {
                communityID: commid
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {   
              console.log(value);
                let obj = {
                    assetname: value.name,
                    serviceable: value.requireServiceFlag,
                    servicefrequency: value.serviceFrequencyinDays,
                    lastservicedate: value.lastServiceDoneDate,
                    lastservicenotes: value.lastServiceNotes,
                    nextservicedate: value.nextServiceDate,
                    servicedetailid: value.serviceDetailID,
                    assetid: value.assetid
                };
                dataRows.push(obj);
            });
            setAssetServiceData(dataRows);
        });
    }

    //Execute the created function directly
    if (!communityid) {
        alert("Please select community ID.")
    } else {
        loadOpenRequest(communityid);
    }

}, []);


const updateServiceDetail = async (newData, oldData) => { 

  const requestBody = JSON.stringify({ 
    RequireServiceFlag: newData.serviceable,
    ServiceFrequencyinDays: newData.servicefrequency,
    LastServiceDoneDate: newData.lastservicedate,
    LastServiceNotes: newData.lastservicenotes,
    NextServiceDate: newData.nextservicedate,
    ServiceDetailID: newData.servicedetailid,
    assetId: newData.assetid 
  });
 
  const token = await authService.getAccessToken();
  const config = {
      headers: {
          authorization: `Bearer ${token}`,
          'Content-Type': 'application/json',
      }
  };

  await API.post('/Asset/UpdateServiceDetails', requestBody, config)
      .then(communityData => { 
          let tempData = assetservicedata;
          const index = tempData.indexOf(oldData);
          tempData[index] = newData;
          const dataRows = [];
          tempData.map(function (value, key) {
              let obj = {
                assetname: value.name,
                serviceable: value.requireServiceFlag,
                servicefrequency: value.serviceFrequencyinDays,
                lastservicedate: value.lastServiceDoneDate,
                lastservicenotes: value.lastServiceNotes,
                nextservicedate: value.nextServiceDate,
                servicedetailid: value.serviceDetailID,
                assetid: value.assetId
              };
              dataRows.push(obj);
          });
          setAssetServiceData(dataRows);

      })
      .catch(function (response) { 
          console.log(response);
      });
}


  return (
    <GridContainer>
      <GridItem xs={12} sm={12} md={12}>
        <Card>
          <MaterialTable
            title="Service Details"
            columns={columns}
            data={assetservicedata}
            options={{
              selection: true,
              filtering: true
            }} 

            editable={{ 
              onRowUpdate: (newData, oldData) =>
                  new Promise((resolve, reject) => {
                      updateServiceDetail(newData, oldData);
                      resolve();
                  }) 
          }}
            detailPanel={rowData => {
              return (
                  <ServiceHistory 
                      assetid={rowData.assetid}
                      servicedtlid = {rowData.servicedetailid}
                  />
              )
          }}
          onRowClick={(event, rowData, togglePanel) => togglePanel()}
          />
        </Card>
      </GridItem>
    </GridContainer>
  );
}