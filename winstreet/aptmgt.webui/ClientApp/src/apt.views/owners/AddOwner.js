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
const OwnerTypeOptions = [
    {
      value: 'Owner',
      label: 'Owner',
    },
    {
      value: 'Co-Owner',
      label: 'Co-Owner',
    },
    {
      value: 'Owner Family Member',
      label: 'Owner Family Member',
    },
    {
      value: 'Rented',
      label: 'Rented',
    },
    {
      value: 'Rented Family Member',
      label: 'Rented Family Member',
    },
  ];
const MemberShipTypes = [
    {
      value: 'President',
      label: 'President',
    },
    {
      value: 'Vice Persident/Secretary',
      label: 'Vice Persident/Secretary',
    },
    {
      value: 'Working committee member',
      label: 'Working committee member',
    },
    {
      value: 'Tresasure',
      label: 'Tresasure',
    },
    {
        value: 'Community Member',
        label: 'Community Member',
      },
    {
      value: 'Not Applicable',
      label: 'Not Applicable',
    },
  ];
export default function AddOwner() {
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
            <CardHeader plain color="primary">
                <h4 className={classes.cardTitleWhite}>
                    Add new owner
                </h4>
            </CardHeader>
            <CardBody>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>
                        <CustomInput
                            labelText="First Name"
                            id="firstname"
                            formControlProps={{
                                fullWidth: true
                            }}
                            inputProps={{
                                disabled: false
                            }}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={6}>
                        <CustomInput
                            labelText="Last Name"
                            id="lastname"
                            formControlProps={{
                                fullWidth: true
                            }}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={3}>
                        <CustomInput
                            labelText="Block Number"
                            id="blocknumber"
                            formControlProps={{
                                fullWidth: true
                            }}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={3}>
                        <CustomInput
                            labelText="Flat Number"
                            id="flatnumber"
                            formControlProps={{
                                fullWidth: true
                            }}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={4}>
                        <CustomInput
                            labelText="Contact Number"
                            id="contactnumber"
                            formControlProps={{
                                fullWidth: true
                            }}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={4}>
                        <CustomInput
                            labelText="Email Address"
                            id="emailaddress"
                            formControlProps={{
                                fullWidth: true
                            }}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}> 
                         <TextField
                        id="occupancytype"
                        select 
                        className={classes.textField}
                        value={ownertype}
                        onChange={handleChangeOwnerType}
                        fullWidth
                        helperText="Occupancy Type"
                        margin="normal"
                        >
                        {OwnerTypeOptions.map(option => (
                            <MenuItem key={option.value} value={option.value}>
                            {option.label}
                            </MenuItem>
                        ))}
                        </TextField>
                    </GridItem>
                    <GridItem xs={12} sm={12} md={6}> 
                        <TextField
                        id="membershiptypeid"
                        select 
                        className={classes.textField}
                        value={memebershiptype}
                        onChange={handleMemberShipType}
                        fullWidth
                        helperText="Membership Type ID"
                        margin="normal"
                        >
                        {MemberShipTypes.map(option => (
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
                            labelText="Any Description"
                            id="anydescription"
                            formControlProps={{
                                fullWidth: true
                            }}
                            inputProps={{
                                multiline: true,
                                rows: 5
                            }}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>

                    </GridItem>
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
                        Save
                </Button>
                    <Button color="primary" round>
                        Reset
                </Button>
                    <Button color="primary" round>
                        Cancel
                </Button>
                </GridContainer>
            </CardBody>
        </Card>
    );
}