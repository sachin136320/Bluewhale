import React from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";

import CustomTabs from "components/CustomTabs/CustomTabs.js";
import VerifiedUser from "@material-ui/icons/VerifiedUser";
import Code from "@material-ui/icons/Code";
import CustomInput from "components/CustomInput/CustomInput.js";
import Table from "components/Table/Table.js";


import Button from "components/CustomButtons/Button.js";
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';

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
    }, container: {
        display: 'flex',
        flexWrap: 'wrap',
    },
    textField: {
        marginLeft: 1,
        marginRight: 1,
        width: 200,
    },
};

const AssetStatusOptions = [
    {
        value: 'Open',
        label: 'Open',
    },
    {
        value: 'In Progress',
        label: 'In Progress',
    },
    {
        value: 'Closed',
        label: 'Closed',
    }
];
const useStyles = makeStyles(styles);
class ProcureNewAsset extends React.Component {
    handleAssetStatusOptions(value){
        this.setState({
            assetstatusoption: value
        });
    }

    constructor(props) {
        super(props);
 
        this.state = {
            columns: [
                { title: 'Name', field: 'name', editable: 'onUpdate' },
                { title: 'Surname', field: 'surname', editable: 'never' },
                { title: 'Flat', field: 'flatNumber', type: 'text' },
                {
                    title: 'Block',
                    field: 'block',
                    lookup: { 34: 'İstanbul', 63: 'Şanlıurfa' },
                },
            ],
            data: [
                { name: 'Mehmet', surname: 'Baran', flatNumber: 'D', block: 63 },
                { name: 'Zerya Betül', surname: 'Baran', flatNumber: 'D', block: 34 },
            ],
            assetstatusoption: props.assetstatusoption
        }
    }


    render() {
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
                                    <Card>
                                        <CardBody>
                                            <GridContainer>
                                                <GridItem xs={12} sm={12} md={6}>
                                                    <TextField
                                                        id="outlined-read-only-input"
                                                        label="Request No"
                                                        defaultValue="request-no"
                                                        className={useStyles.textField}
                                                        margin="normal"
                                                        InputProps={{
                                                            readOnly: true,
                                                        }}
                                                        fullWidth
                                                        variant="outlined"
                                                    />
                                                </GridItem>
                                                <GridItem xs={12} sm={12} md={6}>

                                                    <TextField
                                                        id="outlined-read-only-input"
                                                        label="Request Status"
                                                        defaultValue="request-status"
                                                        className={useStyles.textField}
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
                                                        id="assetstatus"
                                                        select
                                                        className={useStyles.textField}
                                                        value={this.state.assetstatusoption}
                                                        onChange={e => this.handleAssetStatusOptions(e.target.value)}
                                                        fullWidth
                                                        helperText="Asset Status"
                                                        margin="normal"
                                                    >
                                                        {AssetStatusOptions.map(option => (
                                                            <MenuItem key={option.value} value={option.value}>
                                                                {option.label}
                                                            </MenuItem>
                                                        ))}
                                                    </TextField>
                                                </GridItem>
                                            </GridContainer>

                                            <GridContainer>
                                                <GridItem xs={12} sm={12} md={6}>
                                                    <CustomInput
                                                        labelText="Asset Name"
                                                        id="assetname"
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
                                                        labelText="Purpose"
                                                        id="purpose"
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
                                                <GridItem xs={12} sm={12} md={3}>
                                                    <CustomInput
                                                        labelText="Estimated Cost"
                                                        id="estimatedcost"
                                                        formControlProps={{
                                                            fullWidth: true
                                                        }}
                                                    />
                                                </GridItem>
                                            </GridContainer>

                                            <GridContainer>
                                                <Button color="primary" round>
                                                    Send request
                                                </Button>
                                            </GridContainer>
                                        </CardBody>
                                    </Card>
                                )
                            },
                            {
                                tabName: "Add Assets",
                                tabIcon: VerifiedUser,
                                tabContent: (
                                    <Card> 
                                        <MaterialTable
                                            title="hj"
                                            columns={this.state.columns}
                                            data={this.state.data}     
                                            options={{
                                              selection: true
                                            }}
                                            actions={[
                                              {
                                                tooltip: 'Procured',
                                                icon: 'delete',
                                                onClick: (evt, data) => alert('You want to delete ' + data.length + ' rows')
                                              },
                                              {
                                                tooltip: 'Not Procured',
                                                icon: 'delete',
                                                onClick: (evt, data) => alert('You want to delete ' + data.length + ' rows')
                                              },
                                              {
                                                tooltip: 'Approved',
                                                icon: 'delete',
                                                onClick: (evt, data) => alert('You want to delete ' + data.length + ' rows')
                                              },
                                              {
                                                tooltip: 'Reject',
                                                icon: 'delete',
                                                onClick: (evt, data) => alert('You want to delete ' + data.length + ' rows')
                                              }
                                            ]}
                                            editable={{ 
                                                onRowUpdate: (newData, oldData) =>
                                                    new Promise((resolve, reject) => {
                                                        setTimeout(() => {
                                                            {
                                                                const data = this.state.data;
                                                                const index = data.indexOf(oldData);
                                                                data[index] = newData;
                                                                this.setState({ data }, () => resolve());
                                                            }
                                                            resolve()
                                                        }, 1000)
                                                    }),
                                                onRowDelete: oldData =>
                                                    new Promise((resolve, reject) => {
                                                        setTimeout(() => {
                                                            {
                                                                let data = this.state.data;
                                                                const index = data.indexOf(oldData);
                                                                data.splice(index, 1);
                                                                this.setState({ data }, () => resolve());
                                                            }
                                                            resolve()
                                                        }, 1000)
                                                    }),
                                            }}
                                        />
                                    </Card>
                                )
                            }
                        ]}
                    />
                </GridItem>

            </GridContainer>
        )
    }
}
export default ProcureNewAsset;

