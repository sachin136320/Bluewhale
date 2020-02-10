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
                            tabName: "Procure New Asset",
                            tabIcon: Code,
                            tabContent: (
                                <ProcureNewAsset />
                            )
                        },
                        {
                            tabName: "Add Assets",
                            tabIcon: VerifiedUser,
                            tabContent: (
                                <AddAsset />
                            )
                        },
                        {
                            tabName: "Service Record",
                            tabIcon: Cloud,
                            tabContent: (
                                <ServiceRecord />
                            )
                        }
                    ]}
                />
            </GridItem>
            {/*<GridItem xs={12} sm={12} md={4}>
                <Card profile>
                    <CardAvatar profile>
                        <a href="#pablo" onClick={e => e.preventDefault()}>
                            <img src={avatar} alt="..." />
                        </a>
                    </CardAvatar>
                    <CardBody profile>
                        <h2 className={classes.cardCategory}>Name</h2>
                        <h5 className={classes.cardTitle}>Flat No</h5>
                        <h5 className={classes.cardTitle}>Owner Type</h5>
                        <h5 className={classes.cardTitle}>Contact Number</h5> 
                    </CardBody>
                </Card>

                <Button color="primary" round>
                Share
                </Button>
                </GridItem>*/}
        </GridContainer>
    );
}
