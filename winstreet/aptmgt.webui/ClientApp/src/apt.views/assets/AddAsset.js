import React, { useState, useEffect, useContext } from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";

import CustomTabs from "components/CustomTabs/CustomTabs.js";
import VerifiedUser from "@material-ui/icons/VerifiedUser";
import Code from "@material-ui/icons/Code";
import { UserContext } from "store/UserContext";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';
import moment from 'moment';

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

const columns = [
    { title: 'Asset Name', field: 'assetname', type: 'text' },
    { title: 'Purpose', field: 'purpose', type: 'text' },
    { title: 'Cost', field: 'cost', type: 'text' },
    { title: 'Request Date', field: 'requestdate', type: 'text' },
    { title: 'Request Status', field: 'requeststatus', type: 'text' },
    { title: 'Asset Status', field: 'assetstatus', type: 'text' },
    { title: 'Approved', field: 'approved', type: 'text' }
]

export default function AddAsset() {

    const [openrequestdata, setOpenRequestData] = useState([]);
    const [assetactualcost, setAssetActualCost] = useState('');
    const [assetnotes, setAssetNotes] = useState('');

    const { communityid, setCommunityID } = useContext(UserContext);

    useEffect(() => {
        async function loadOpenRequest(commid) {
            const token = await authService.getAccessToken();
            await API.get('/Asset/GetAllOpenRequest', {
                params: {
                    communityID: commid
                },
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => {
                const dataRows = [];
                data.map(function (value, key) {
                    let obj = {
                        assetname: value.AssetName,
                        purpose: value.purpose,
                        cost: value.cost,
                        requestdate: value.requestDate,
                        assetstatus: value.AssetStatus,
                        approved: value.approved,
                        assetid: value.assetid
                    };
                    dataRows.push(obj);
                });
                setOpenRequestData(dataRows);
            });
        }

        //Execute the created function directly
        if (!communityid) {
            alert("Please select community ID.")
        } else {
            loadOpenRequest(communityid);
        }

    }, []);

    const handleProcuredEvent = async (assetid) => {
        const token = await authService.getAccessToken();
        await API.get('/Asset/ProcureAsset', {
            params: {
                communityID: commid,
                assetID: assetid
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let obj = {
                    assetname: value.AssetName,
                    purpose: value.purpose,
                    cost: value.cost,
                    requestdate: value.requestDate,
                    assetstatus: value.AssetStatus,
                    approved: value.approved,
                    assetid: value.assetid
                };
                dataRows.push(obj);
            });
            setOpenRequestData(dataRows);
        });
    };

    const handleApproveEvent = async () => {

        const token = await authService.getAccessToken();
        await API.get('/Asset/ApproveAsset', {
            params: {
                communityID: commid,
                assetID: assetid
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let obj = {
                    assetname: value.AssetName,
                    purpose: value.purpose,
                    cost: value.cost,
                    requestdate: value.requestDate,
                    assetstatus: value.AssetStatus,
                    approved: value.approved,
                    assetid: value.assetid
                };
                dataRows.push(obj);
            });
            setOpenRequestData(dataRows);
        });
    };

    const handleUnApproveEvent = async () => {

    };

    return (
        <MaterialTable
            title="All open requests"
            columns={columns}
            data={openrequestdata}
            detailPanel={rowData => {
                return (
                    <GridContainer>
                        <GridItem xs={12} sm={6} md={6}>
                            <TextField
                                labelText="Actual Cost"
                                id="actualcost"
                                label="Actual Cost"
                                value={assetactualcost}
                                onChange={e => setAssetActualCost(e.target.value)}
                                className={classes.textField}
                                margin="normal"
                                fullWidth
                            />
                        </GridItem>
                        <GridItem xs={12} sm={12} md={12}>
                            <TextField
                                id="assetnotes"
                                label="Notes"
                                className={classes.textField}
                                onChange={e => setAssetNotes(e.target.value)}
                                margin="normal"
                                multiline
                                rowsMax="5"
                                value={assetnotes}
                                fullWidth
                            />
                        </GridItem>

                        <GridItem xs={12} sm={6} md={6}>
                            <Button
                                color="primary"
                                round
                                onClick={handleProcuredEvent}>
                                Procured
                            </Button>
                        </GridItem>
                        <GridItem xs={12} sm={6} md={6}>
                            <Button
                                color="primary"
                                round
                                onClick={handleApproveEvent}>
                                Approved
                            </Button>
                        </GridItem>
                        <GridItem xs={12} sm={6} md={6}>
                            <Button
                                color="primary"
                                round
                                onClick={handleUnApproveEvent}>
                                Not Approved
                            </Button>
                        </GridItem>
                    </GridContainer>
                )
            }}
            onRowClick={(event, rowData, togglePanel) => togglePanel()}

        />
    )

}


/*
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
*/