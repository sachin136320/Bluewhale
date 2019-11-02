import React from "react";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js"; 

import AddApartmentCommunity from "apt.views/configuresettings/apartmentdetails.js";
import BlockDetails from "apt.views/configuresettings/blockdetails.js";
import FacilityDetails from "apt.views/configuresettings/facilitydetails.js";
import BasicSettingSummary from "apt.views/configuresettings/basicsettingsummary.js";
import CustomTabs from "components/CustomTabs/CustomTabs.js";
import VerifiedUser from "@material-ui/icons/VerifiedUser";
import Tasks from "components/Tasks/Tasks.js";
import { bugs, website, server } from "variables/general.js";
import Code from "@material-ui/icons/Code";
import Cloud from "@material-ui/icons/Cloud";
 
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

export default function ConfigureBasicSettings() {
    const classes = useStyles();
    return (
        <GridContainer>
            <GridItem xs={12} sm={12} md={12}>
                <CustomTabs
                    headerColor="primary"
                    tabs={[
                        {
                            tabName: "Apartment Details",
                            tabIcon: VerifiedUser,
                            tabContent: (
                                <AddApartmentCommunity/>
                            )
                        },
                        {
                            tabName: "Block Details",
                            tabIcon: Code,
                            tabContent: (
                                <BlockDetails/>
                            )
                        },
                        {
                            tabName: "Facility Details",
                            tabIcon: Cloud,
                            tabContent: (
                                <FacilityDetails />
                            )
                        },
                        {
                            tabName: "Summary",
                            tabIcon: Cloud,
                            tabContent: (
                                <BasicSettingSummary/>
                            )
                        }
                    ]}
                />
            </GridItem>
        </GridContainer>
    );
}
