import React from "react";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js"; 
import Card from "components/Card/Card.js"; 
import CardBody from "components/Card/CardBody.js";

import AddOwner from "apt.views/owners/AddOwner.js";
import CustomTabs from "components/CustomTabs/CustomTabs.js";
import VerifiedUser from "@material-ui/icons/VerifiedUser";
import Tasks from "components/Tasks/Tasks.js";
import { bugs, website, server } from "variables/general.js";
import Code from "@material-ui/icons/Code";
import Cloud from "@material-ui/icons/Cloud";
 
import ModifyOwner1 from "apt.views/owners/ModifyOwner";
import avatar from "assets/img/faces/marc.jpg";
import Button from "components/CustomButtons/Button.js"; 
import CardAvatar from "components/Card/CardAvatar.js";
import Tenants from "apt.views/owners/Tenants.js";


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

export default function OwnersCorner() {
    const classes = useStyles();
    return (
        <GridContainer>
            <GridItem xs={12} sm={12} md={8}>
                <CustomTabs
                    headerColor="primary"
                    tabs={[
                        {
                            tabName: "Add Users",
                            tabIcon: VerifiedUser,
                            tabContent: (
                                <AddOwner />
                            )
                        },
                        {
                            tabName: "Modify User",
                            tabIcon: Code,
                            tabContent: (
                                <ModifyOwner1 />
                            )
                        },
                        {
                            tabName: "Tenants",
                            tabIcon: Cloud,
                            tabContent: (
                                <Tenants />
                            )
                        },
                        {
                            tabName: "Socialize",
                            tabIcon: Cloud,
                            tabContent: (
                                <Tasks
                                    checkedIndexes={[1]}
                                    tasksIndexes={[0, 1, 2]}
                                    tasks={server}
                                />
                            )
                        }
                    ]}
                />
            </GridItem>
            <GridItem xs={12} sm={12} md={4}>
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
            </GridItem>
        </GridContainer>
    );
}
