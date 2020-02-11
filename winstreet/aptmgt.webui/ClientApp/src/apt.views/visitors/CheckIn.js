import React, { useEffect, useContext, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";

import CustomInput from "components/CustomInput/CustomInput.js";
import Button from "components/CustomButtons/Button.js";
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
import Table from "components/Table/Table.js";

import Icon from "@material-ui/core/Icon";
import CardIcon from "components/Card/CardIcon.js";
import WebCamCapture from "components/WebCam/WebcamCapture.js";
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
const VisitorTypeOptions = [
    {
        value: 'Owner',
        label: 'Owner',
    },
    {
        value: 'Co-Owner',
        label: 'Co-Owner',
    }
]; 

export default function CheckIn() {
    const classes = useStyles();

    const { communityid, setCommunityID } = useContext(UserContext);

    const [VisitingTo, setVisitingTo] = useState([]);
    const [ownertype, setOwnerType] = useState('Community Member');
    const handleChangeOwnerType = event => {
        setOwnerType(event.target.value);
    };

    const [hostname, setHostName] = useState('');
    const [hostphone, setHostPhone] = useState('');

    const [visitorphone, setVisitorPhone] = useState('');
    const [visitorname, setVisitorName] = useState('');
    const [numberofvisitor, setNumberOfVisitor] = useState('');
    const [checkintimestamp, setCheckInTimestamp] = useState('');
    const [visitortype, setVisitorType] = useState('');
    const [VisitorTypeList, setVisitorTypeList] = useState([]);

    const [visitoraddress, setVisitorAddress] = useState('');
    const [visitorqrtext, setVisitorQRText] = useState('');
    const [visitorid, setVisitorID] = useState('');

    const [memebershiptype, setMemberShipType] = useState('');

    const handleChangeVisitorType = event => {

    };

    const handleMemberShipType = event => {
        setMemberShipType(event.target.value);
    };



    useEffect(() => {
        async function loadHostList(commid) {
            const token = await authService.getAccessToken();
            await API.get('/Resident/GetVisitorHostDetails', {
                params: {
                    commID: commid
                },
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => {
                const dataRows = [];
                data.map(function (value, key) {
                    let obj = {
                        value: value.commID,
                        label: value.name
                    };
                    dataRows.push(obj);
                });
                setVisitingTo(dataRows);
            });
        }

        //Execute the created function directly
        if (!communityid) {
            alert("Please select community ID.")
        } else {
            loadHostList(communityid);
        }

    }, []);

    const handleHostChange = event => {
        //Make a service call
        //Get Host Details

    };


    return (
        <Card>
            <CardBody>
                <GridContainer>
                    <GridItem xs={12} sm={6} md={6}>
                        <TextField
                            id="visitorto"
                            select
                            className={classes.textField}
                            value={ownertype}
                            onChange={handleHostChange}
                            fullWidth
                            helperText="Visitor To"
                            margin="normal"
                        >
                            {VisitingTo.map(option => (
                                <MenuItem key={option.value} value={option.value}>
                                    {option.label}
                                </MenuItem>
                            ))}
                        </TextField>
                    </GridItem>

                    <GridItem xs={12} sm={6} md={6}>
                        <TextField
                            labelText="Host Name"
                            id="hostname"
                            label="Host Name"
                            value={hostname}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                        />
                    </GridItem>

                    <GridItem xs={12} sm={6} md={6}>
                        <TextField
                            id="hostphone"
                            label="Host Phone"
                            className={classes.textField}
                            margin="normal"
                            value={hostphone}
                            fullWidth
                        />
                    </GridItem>

                </GridContainer>

                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            required
                            id="standard-required"
                            label="Visitor's Phone"
                            value={visitorphone}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            id="visitortype"
                            select
                            className={classes.textField}
                            value={visitortype}
                            onChange={handleChangeVisitorType}
                            fullWidth
                            helperText="Visitor Type"
                            margin="normal"
                        >
                            {VisitorTypeList.map(option => (
                                <MenuItem key={option.value} value={option.value}>
                                    {option.label}
                                </MenuItem>
                            ))}
                        </TextField>
                    </GridItem>
                </GridContainer>

                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            label="Visitor's Name"
                            id="visitor-name"
                            value={visitorname}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            label="Number of visitors"
                            id="numberofvisitors"
                            value={numberofvisitor}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                        />
                    </GridItem>
                </GridContainer>
 
                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <TextField
                            label="Visitor Address"
                            id="visitoraddress"
                            value={visitoraddress}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                        />
                    </GridItem>
                </GridContainer>

                <Card>
                    <CardBody>
                        {/*
                            https://www.npmjs.com/package/react-webcam
                        */}
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={6}>
                                <WebCamCapture />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={6}>
                                {/*
                                    more of qr code generation
                                    https://medium.com/@zaran.56/how-to-generate-and-download-a-qr-code-image-in-react-a3e924a672f5
                                */}
                                <QRCode
                                    id="123456"
                                    includeMargin={true}
                                    value={visitorqrtext}
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
                                    onClick={() => saveUser()}>
                                    CheckIn
                                </Button>
                            </GridItem>
                            <GridItem xs={6} sm={6} md={4}>
                                <TextField
                                    label="Checkin Date and time"
                                    id="checkintimestamp"
                                    value={checkintimestamp}
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                />
                            </GridItem>
                            <GridItem xs={6} sm={6} md={4}>
                                <TextField
                                    id="outlined-read-only-input"
                                    label="Visitor ID"
                                    defaultValue=""
                                    value={visitorid}
                                    className={classes.textField}
                                    margin="normal"
                                    InputProps={{
                                        readOnly: true,
                                    }}
                                    fullWidth
                                    variant="outlined"
                                />
                            </GridItem>
                        </GridContainer>
                    </CardBody>
                </Card>
            </CardBody>
        </Card>
    );
}