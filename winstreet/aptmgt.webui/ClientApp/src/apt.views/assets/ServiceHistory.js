import React, { useState, useEffect, useContext } from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import { UserContext } from "store/UserContext";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js'; 
import Card from "components/Card/Card.js";  
const styles = {
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
    { title: 'Service Date', field: 'servicedate', type: 'date' },
    { title: 'Service Notes', field: 'servicenotes', type: 'string' }
]


export default function ServiceHistory(option) {

    const classes = useStyles();
    const { communityid, setCommunityID } = useContext(UserContext); 

    const [assetservicehistorydata, setAssetServiceHistoryData] = useState([]);

    useEffect(() => {

        async function loadOpenRequest(commid) {
            const token = await authService.getAccessToken();
            await API.get('/Asset/GetServiceHistory', {
                params: {
                    communityID: commid,
                    assetID: option.assetid
                },
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => {
                const dataRows = [];
                data.map(function (value, key) {

                    let obj = {
                        servicedate: value.serviceDate,
                        servicenotes: value.serviceNotes 
                    }; 

                    dataRows.push(obj);
                });
                setAssetServiceHistoryData(dataRows);
            });
        }

        //Execute the created function directly
        if (!communityid) {
            alert("Please select community ID.")
        } else {
            loadOpenRequest(communityid);
        }
        console.log(option);
    }, []);

    const addServiceDetail = async (newData) => {
        console.log(newData);
        console.log(option.assetid);
        console.log(option.servicedtlid);
        
        const requestBody = JSON.stringify({
            AssetId: option.assetid,
            ServiceDate: newData.servicedate,
            ServiceNotes: newData.servicenotes, 
            CommunityId: communityid,
            ServiceDetailID: option.servicedtlid
        });
        
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        console.log(requestBody);
        await API.post('/Asset/AddServiceHistory', requestBody, config)
            .then(servicehistory => { 
                let newBlock = {
                    servicedate: servicehistory.data.serviceDate,
                    servicenotes: servicehistory.data.serviceNotes
                };
                const dataRows = [];
                let tempData = assetservicehistorydata; 
                tempData.map(function (value, key) {
                    let obj = {
                        servicedate: value.servicedate,
                        servicenotes: value.servicenotes
                    };
                    dataRows.push(obj);
                }); 
                dataRows.push(newBlock);
                setAssetServiceHistoryData(dataRows); 
            })
            .catch(function (response) {
                //handle error
                console.log(response);
            });
    }

    return (
        <GridContainer>
            <GridItem xs={12} sm={12} md={12}>
                <Card>
                    <MaterialTable
                        title="Service History"
                        columns={columns}
                        data={assetservicehistorydata}
                        options={{
                            selection: true,
                            filtering: true
                        }}
                        editable={{
                            onRowAdd: newData =>
                                new Promise((resolve, reject) => {
                                    addServiceDetail(newData);
                                    resolve();
                                })
                        }}
                    />
                </Card>
            </GridItem>
        </GridContainer>
    );
}
