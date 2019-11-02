import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js"; 
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";

import CustomInput from "components/CustomInput/CustomInput.js"; 
import Info from "components/Typography/Info.js";


import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Divider from '@material-ui/core/Divider';
import InboxIcon from '@material-ui/icons/Inbox';
import DraftsIcon from '@material-ui/icons/Drafts';

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

export default function AddApartmentCommunity() {
    const classes = useStyles();
    return (
        <Card>
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
                <CardFooter> 
                        <div className={classes.typo}>
                            <h3>Help</h3>
                        <List component="nav" aria-label="main mailbox folders">
                            <ListItem button> 
                            <ListItemText primary="Builder Name: Enter builder name if there is no builder name. Enter only 'Builder'"/>
                            </ListItem>
                            <ListItem button> 
                            <ListItemText primary="Apartment Name: Enter apartment name. It cannot be left empty."/>
                            </ListItem>
                            <ListItem button> 
                            <ListItemText primary="Address line1: Enter address of the apartment."/>
                            </ListItem>
                            <ListItem button> 
                            <ListItemText primary="State: Enter state"/>
                            </ListItem>
                            <ListItem button> 
                            <ListItemText primary="City: Enter city"/>
                            </ListItem>
                        </List> 
                        </div> 
                </CardFooter>
            </CardBody>
        </Card>
    );
}