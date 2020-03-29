import React, { useEffect, useContext, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";
import Button from "components/CustomButtons/Button.js";
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
import {
    successColor,
    whiteColor,
    grayColor,
    hexToRgb,
    blackColor
} from "assets/jss/material-dashboard-react.js";

import { UserContext } from "store/UserContext";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';
import moment from 'moment';

var QRCode = require('qrcode.react');

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
    },
    container: {
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


export default function RequestNewAsset() {

    const classes = useStyles();

    const { communityid, setCommunityID } = useContext(UserContext);

    const [assetname, setAssetName] = useState('');
    const [assetpurpose, setAssetPurpose] = useState('');
    const [estimatedcost, setEstimatedCost] = useState('');

    const [assetstatus, setAssetStatus] = useState('New');
    const [requeststatus, setRequestStatus] = useState('');
    const [requestnumber, setRequestNumber] = useState('Not Generated');

    useEffect(() => { 
        if (!communityid) {
            alert("Please select community ID.")
        }
    }, []);

    const handleCreateRequest = async() => {
        //if community id is not correct then skip everything below this  

        //call api to save visitor details 
        const requestBody = JSON.stringify({
            Name: assetname,
            Purpose: assetpurpose,
            EstimatedCost: estimatedcost,
            RequestDate: moment().format('MMMM Do YYYY, h:mm:ss a'),
            RequestStatus: 'open',
            CommunityID: communityid
        });
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.post('/Asset/New', requestBody, config)
            .then(communityData => {  
                setRequestNumber(communityData.data.assetRequestId);
                setRequestStatus(communityData.data.requestStatus);
            })
            .catch(function (response) {
                console.log(response);
            });

    }

    return (
        <GridContainer>
            <Card>
                <CardBody>
                    <GridContainer>
                        <GridItem xs={12} sm={6} md={6}>
                            <TextField
                                labelText="Asset Name"
                                id="assetname"
                                label="Asset Name"
                                value={assetname}
                                onChange={e => setAssetName(e.target.value)}
                                className={classes.textField}
                                margin="normal"
                                fullWidth
                            />
                        </GridItem>
                        <GridItem xs={12} sm={12} md={6}>
                            <TextField
                                required
                                id="estimatedcost"
                                label="Estimated Cost (Rs.)"
                                value={estimatedcost}
                                onChange={e => setEstimatedCost(e.target.value)}
                                className={classes.textField}
                                margin="normal"
                                fullWidth
                            />
                        </GridItem>
                    </GridContainer>

                    <GridContainer>
                        <GridItem xs={12} sm={12} md={12}>
                            <TextField
                                id="assetpurpose"
                                label="Purpose"
                                className={classes.textField}
                                onChange={e => setAssetPurpose(e.target.value)}
                                margin="normal"
                                multiline
                                rowsMax="5"
                                value={assetpurpose}
                                fullWidth
                            />
                        </GridItem>
                    </GridContainer>

                </CardBody>
            </Card>

            <Card>
                <CardBody>

                    <GridContainer
                        direction="row" justify="center" alignItems="center">
                        <GridItem xs={6} sm={6} md={4}>
                            <Button
                                color="primary"
                                round
                                onClick={handleCreateRequest}>
                                Create Request
                            </Button>
                        </GridItem>
                    </GridContainer>

                    <GridContainer>
                        <GridItem xs={12} sm={6} md={6}>
                            <TextField
                                labelText="Request No."
                                id="requestnumber"
                                label="Request No."
                                value={requestnumber}
                                onChange={e => setRequestNumber(e.target.value)}
                                className={classes.textField}
                                margin="normal"
                                fullWidth
                                disabled="true"
                            />
                        </GridItem>
                    </GridContainer>

                    <GridContainer>
                        <GridItem xs={12} sm={12} md={6}>
                            <TextField
                                id="requeststatus"
                                className={classes.textField}
                                value={requeststatus}
                                label="Request Status"
                                fullWidth
                                onChange={e => setRequestStatus(e.target.value)}
                                margin="normal"
                                disabled="true"
                            >
                            </TextField>
                        </GridItem>
                    </GridContainer>
                </CardBody>
            </Card>
        </GridContainer>
    );
}