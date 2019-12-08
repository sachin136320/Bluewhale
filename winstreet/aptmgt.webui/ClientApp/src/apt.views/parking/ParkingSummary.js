import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";
import CardHeader from "components/Card/CardHeader.js";
import CardFooter from "components/Card/CardFooter.js";

import CustomInput from "components/CustomInput/CustomInput.js";
import Info from "components/Typography/Info.js";


import TextField from '@material-ui/core/TextField';


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
    }
};

const useStyles = makeStyles(styles);

export default function ParkingSummary() {
    const classes = useStyles();
    return (
        <GridContainer>
            <GridItem>
                <Card>
                    <CardHeader color="success">
                        <p className={classes.cardTitleBlack}>Your Parking Summary</p>
                    </CardHeader>
                    <CardBody>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={6}>
                                {/* 
                                You can use TextField tag as well for more details look into
                                https://material-ui.com/components/text-fields/
                                */ }
                                <TextField
                                    id="outlined-read-only-input"
                                    label="List of Assigned Parking"
                                    defaultValue="assignedparking"
                                    className={classes.textField}
                                    margin="normal"
                                    InputProps={{
                                        readOnly: true,
                                    }}
                                    variant="outlined"
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    id="outlined-read-only-input"
                                    label="List of Parking Sticker"
                                    defaultValue="parkingsticker"
                                    className={classes.textField}
                                    margin="normal"
                                    InputProps={{
                                        readOnly: true,
                                    }}
                                    variant="outlined"
                                />
                            </GridItem>
                        </GridContainer>
                        
                    </CardBody>
                </Card>
            </GridItem>

            <GridItem>
                <Card>
                    <CardHeader color="success">
                        <p className={classes.cardTitleBlack}>Community Parking Summary</p>
                    </CardHeader>
                    <CardBody>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={12}>
                                {/* 
                                You can use TextField tag as well for more details look into
                                https://material-ui.com/components/text-fields/
                                */ }
                                <CustomInput
                                    labelText="Builder Name"
                                    id="buildername"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                    inputProps={{
                                        disabled: false
                                    }}
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={12}>
                                <CustomInput
                                    labelText="Apartment Name"
                                    id="apartmentname"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                />
                            </GridItem>
                        </GridContainer>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={12}>
                                <CustomInput
                                    labelText="Address Line1"
                                    id="addressline1"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={3}>
                                <CustomInput
                                    labelText="State"
                                    id="state"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={3}>
                                <CustomInput
                                    labelText="City"
                                    id="city"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={4}>
                                <CustomInput
                                    labelText="Pincode"
                                    id="pincode"
                                    formControlProps={{
                                        fullWidth: true
                                    }}
                                />
                            </GridItem>
                        </GridContainer>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={4}>
                                <CustomInput
                                    labelText="Apartment Id"
                                    id="emailaddress"
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
    );
}