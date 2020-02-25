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
import Webcam from "react-webcam";
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
const videoConstraints = {
    width: 320,
    height: 240,
    facingMode: "user"
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
    const [VisitorTo, setVisitorTo] = useState('');

    const [hostid, setHostID] = useState('');
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
    const [image, setImage] = useState([]);
    const handleChangeVisitorType = event => {
        setVisitorType(event.target.value);
    };
    const saveUser = () => {

    };

    const handleMemberShipType = event => {
        setMemberShipType(event.target.value);
    };

    /*
    ,
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    */
    useEffect(() => {
        async function loadHostList(commid) {
            const token = await authService.getAccessToken();
            await API.get('/Visitors/GetAll', {
                params: {
                    communityID: commid
                },
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => {
                const dataRows = [];
                data.map(function (value, key) {
                    let obj = {
                        value: value.flatID,
                        label: value.flat
                    };
                    dataRows.push(obj);
                });
                setVisitingTo(dataRows);
            });
        }

        async function loadVisitorType() {
            const token = await authService.getAccessToken();
            await API.get('/Visitors/GetVisitorType', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            })
                .then(({ data }) => {
                    console.log(data);
                    const dataRows = [];
                    data.map(function (value, key) {
                        let obj = {
                            value: value,
                            label: value
                        };
                        dataRows.push(obj);
                    });
                    setVisitorTypeList(dataRows);
                });
        }
        //Execute the created function directly
        if (!communityid) {
            alert("Please select community ID.")
        } else {
            loadHostList(communityid);
            loadVisitorType();
        }

    }, []);

    const handleHostChange = async (event) => {
        console.log(event.target.value);
        setVisitorTo(event.target.value);
        //Make a service call
        //Get Host Details
        const token = await authService.getAccessToken();
        await API.get('/Visitors/GetVisitorHostDetails', {
            params: {
                flatID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            console.log(data);
            setHostName(data.name);
            setHostPhone(data.phone);
            setHostID(data.hostID);
        });
    };


    const handleCheckinEvent = async (event) => {
        setVisitorQRText(hostname + numberofvisitor + checkintimestamp + visitorphone + visitortype);
        setCheckInTimestamp(moment().format('MMMM Do YYYY, h:mm:ss a'));
        //call api to save visitor details 
        const requestBody = JSON.stringify({
            Name: hostname,
            NumberOfVisitor: numberofvisitor,
            CommunityID: communityid,
            Address: visitoraddress,
            CheckInDate: checkintimestamp,
            MobileNumber: visitorphone,
            VisitorType: visitortype,
            Picture: image,
            //QRText: hostname + numberofvisitor + checkintimestamp + visitorphone + visitortype,
            ResidentID: hostid
        });
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.post('/Visitors', requestBody, config)
            .then(communityData => {
                console.log(communityData);
                setVisitorID(communityData.value.visitID);
            })
            .catch(function (response) {
                console.log(response);
            });


    };
    const webcamRef = React.useRef(null);

    const capture = React.useCallback(
        () => {
            const imageSrc = webcamRef.current.getScreenshot();
            setImage(imageSrc);
            console.log(imageSrc);
        },
        //[webcamRef]
    );

    return (
        <Card>
            <CardBody>
                <GridContainer>
                    <GridItem xs={12} sm={6} md={6}>
                        <TextField
                            id="visitorto"
                            select
                            className={classes.textField}
                            value={VisitorTo}
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
                            onChange={e => setHostName(e.target.value)}
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
                            onChange={e => setHostPhone(e.target.value)}
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
                            onChange={e => setVisitorPhone(e.target.value)}
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
                            onChange={e => setVisitorName(e.target.value)}
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
                            onChange={e => setNumberOfVisitor(e.target.value)}
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
                            onChange={e => setVisitorAddress(e.target.value)}
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
                                <Webcam
                                    audio={false}
                                    height={240}
                                    ref={webcamRef}
                                    screenshotFormat="image/jpeg"
                                    width={320}
                                    videoConstraints={videoConstraints}
                                />
                                <Button color="primary" round onClick={capture}>Capture photo</Button>
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
                                    onClick={handleCheckinEvent}>
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