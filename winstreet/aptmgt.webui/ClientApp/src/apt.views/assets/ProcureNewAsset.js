import React from "react"; 
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js"; 
import CustomTabs from "components/CustomTabs/CustomTabs.js";
import VerifiedUser from "@material-ui/icons/VerifiedUser";
import Code from "@material-ui/icons/Code"; 
import ProcessAllOpenRequest from "./ProcessAllOpenRequest";
import AddAsset from "./AddAsset";

export default function ProcureNewAsset() {
 
    return (
        <GridContainer>
            <GridItem xs={12} sm={12} md={12}>
                <CustomTabs
                    headerColor="primary"
                    tabs={[
                        {
                            tabName: "Open Requests",
                            tabIcon: Code,
                            tabContent: (
                                <ProcessAllOpenRequest />
                            )
                        },
                        {
                            tabName: "Add Assets",
                            tabIcon: VerifiedUser,
                            tabContent: (
                                <AddAsset />
                            )
                        }
                    ]}
                />
            </GridItem>

        </GridContainer>
    )

}
 