import React from "react";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js"; 
import Card from "components/Card/Card.js"; 
import CardBody from "components/Card/CardBody.js";

import CustomTabs from "components/CustomTabs/CustomTabs.js";
import VerifiedUser from "@material-ui/icons/VerifiedUser";
import Code from "@material-ui/icons/Code";
import Cloud from "@material-ui/icons/Cloud";
 
import ProcureNewAsset from "apt.views/assets/ProcureNewAsset";
import AddAsset from "apt.views/assets/AddAsset";
import ServiceRecord from "apt.views/assets/ServiceRecord";
import RequestNewAsset from "./RequestNewAsset";


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

export default function AssetManagement() {
    const classes = useStyles();
    return (
        <GridContainer>
            <GridItem xs={12} sm={12} md={12}>
                <CustomTabs
                    headerColor="primary"
                    tabs={[
                        {
                            tabName: "New Request",
                            tabIcon: Code,
                            tabContent: (
                                <RequestNewAsset />
                            )
                        },
                        {
                            tabName: "Procure",
                            tabIcon: Code,
                            tabContent: (
                                <ProcureNewAsset />
                            )
                        }, 
                        {
                            tabName: "Service & Maintainence",
                            tabIcon: Cloud,
                            tabContent: (
                                <ServiceRecord />
                            )
                        }
                    ]}
                />
            </GridItem> 
        </GridContainer>
    );
}
