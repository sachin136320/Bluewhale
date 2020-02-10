import React from "react";
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
    },container: {
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
const VisitingTo = [
    {
      value: 'D303',
      label: 'D303',
    },
    {
      value: 'D304',
      label: 'D304',
    }, 
  ];


export default function CheckIn() {
    const classes = useStyles();
    const [ownertype, setOwnerType] = React.useState('Community Member');
    const [memebershiptype, setMemberShipType] = React.useState('Community Member');
    const handleChangeOwnerType = event => {
        setOwnerType(event.target.value);
      };
      const handleMemberShipType = event => {
        setMemberShipType(event.target.value);
      };
    return (
        <Card> 
            <CardBody>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <TextField
                            id="outlined-read-only-input"
                            label="Visitor ID"
                            defaultValue="visitor-id"
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
                
                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            required
                            id="standard-required"
                            label="Visitor's Phone"
                            className={classes.textField}
                            margin="normal"
                            fullWidth 
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={6}>
                        <CustomInput
                            labelText="Visitor's Name"
                            id="visitor-name"
                            formControlProps={{
                                fullWidth: true
                            }}
                        />
                    </GridItem>
                </GridContainer>

                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>
                        <CustomInput
                            labelText="Number of visitors"
                            id="numberofvisitors"
                            formControlProps={{
                                fullWidth: true
                            }}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={6}>
                        <CustomInput
                            labelText="Checkin Date and time"
                            id="checkintimestamp"
                            formControlProps={{
                                fullWidth: true
                            }}
                        />
                    </GridItem>
                </GridContainer>

                <GridContainer> 
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            id="visitortype"
                            select 
                            className={classes.textField}
                            value={ownertype}
                            onChange={handleChangeOwnerType}
                            fullWidth
                            helperText="Visitor Type"
                            margin="normal"
                            >
                            {VisitorTypeOptions.map(option => (
                                <MenuItem key={option.value} value={option.value}>
                                {option.label}
                                </MenuItem>
                            ))}
                        </TextField>
                    </GridItem>
                </GridContainer>

                <GridContainer> 
                    <GridItem xs={12} sm={12} md={12}>
                        <CustomInput
                            labelText="Visitor Address"
                            id="visitoraddress"
                            formControlProps={{
                                fullWidth: true
                            }}
                            inputProps={{
                                multiline: true,
                                rows: 2
                            }}
                        />
                    </GridItem>
                </GridContainer>  

                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <Card> 
                        <CardBody>
                            <TextField
                                id="visitorto"
                                select 
                                className={classes.textField}
                                value={ownertype}
                                onChange={handleChangeOwnerType}
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
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={6}>
                                <CustomInput
                                    labelText="Host Name"
                                    id="hostname"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={6}>
                                <CustomInput
                                    labelText="Host Phone"
                                    id="hostphone"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={12}>
                                <CustomInput
                                    labelText="Host Email"
                                    id="hostemail"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                />
                            </GridItem>
                        </GridContainer>
                        </CardBody> 
                    </Card>
                    </GridItem> 

                </GridContainer>
                {/*
                https://www.npmjs.com/package/react-webcam
                */}     
                <GridContainer> 
                    <GridItem xs={12} sm={12} md={6}> 
                        <WebCamCapture />
                    </GridItem> 
                </GridContainer>

                <GridContainer> 
                    <GridItem xs={12} sm={12} md={6}>
                        {/*
                    more of qr code generation
                    https://medium.com/@zaran.56/how-to-generate-and-download-a-qr-code-image-in-react-a3e924a672f5
                     */}
                        <QRCode value="http://facebook.github.io/react/" />
                    </GridItem> 
                </GridContainer>
 
                <GridContainer>
                    <Button color="primary" round>
                        CheckIn
                    </Button> 
                </GridContainer>
            </CardBody>
        </Card>
    );
}