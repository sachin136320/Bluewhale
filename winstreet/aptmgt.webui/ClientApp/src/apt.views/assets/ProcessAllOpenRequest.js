import React, { useState, useEffect, useContext } from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import { UserContext } from "store/UserContext";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';
import Button from "components/CustomButtons/Button.js";
import TextField from '@material-ui/core/TextField';
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";
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
    { title: 'Asset Name', field: 'assetname', type: 'string' },
    { title: 'Purpose', field: 'purpose', type: 'string' },
    { title: 'Cost', field: 'cost', type: 'string' },
    { title: 'Request Date', field: 'requestdate', type: 'date' },
    { title: 'Request Status', field: 'requeststatus', type: 'string' },
    { title: 'Asset Status', field: 'assetstatus', type: 'string' },
    { title: 'Approved', field: 'approved', type: 'string' }
]

export default function ProcessAllOpenRequest() {
    const classes = useStyles();

    const [openrequestdata, setOpenRequestData] = useState([]);
    const [assetactualcost, setAssetActualCost] = useState('');
    const [assetnotes, setAssetNotes] = useState('');
    const { communityid, setCommunityID } = useContext(UserContext); 

    const assetActualCost = (e) => {
        console.log(e);
        setAssetActualCost(e.target.value)
    };

    const proVisible = (rowData) => {
        let visibleComponent;
        if (rowData.approved == 'Y') {
            visibleComponent =
                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <TextField
                            id="actualcost"
                            label="Actual Cost"
                            className={classes.textField}
                            value={assetactualcost}
                            onChange={e => assetActualCost(e)}
                            margin="normal"
                            fullWidth
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={12}>
                        <Button
                            color="primary"
                            round
                            onClick={() => handleProcuredEvent(rowData)}>
                            Procured
                            </Button>
                    </GridItem>
                </GridContainer>;
        } else {
            visibleComponent =
                <GridContainer>
                    <GridItem xs={12} sm={4} md={4}>
                        <Button
                            color="primary"
                            round
                            onClick={() => handleApproveEvent(rowData, true)}>
                            Approved
                    </Button>
                    </GridItem>
                    <GridItem xs={12} sm={4} md={4}>
                        <Button
                            color="primary"
                            round
                            onClick={() => handleUnApproveEvent(rowData, false)}>
                            Not Approved
                    </Button>
                    </GridItem>
                </GridContainer>;
        }

        return visibleComponent;
    };

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
                    const approveDate = moment(value.assetApproveDate, 'YYYY-MM-DDTHH:mm:ss.SSSZ');
                    let approval;
                    if (approveDate.isValid() && approveDate.isAfter('2019-01-01', 'year')) {
                        approval = 'Y';
                    }
                    else {
                        approval = 'N';
                    }

                    let obj = {
                        assetname: value.assetName,
                        purpose: value.purpose,
                        cost: value.cost,
                        requeststatus: value.requestStatus,
                        requestdate: value.requestDate,
                        assetstatus: value.assestStatus,
                        approved: approval,
                        assetid: value.assetId,
                        notes: value.notes
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

    const handleProcuredEvent = async (rowData) => { 
        console.log(assetactualcost);
        console.log(assetnotes);

        const token = await authService.getAccessToken();
        await API.get('/Asset/ProcureAsset', {
            params: {
                communityID: communityid,
                assetID: rowData.assetid,
                cost: assetactualcost,
                notes: assetnotes
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then( response => {
            const approveDate = moment(response.data.assetApproveDate, 'YYYY-MM-DDTHH:mm:ss');
            let approval;
            if (approveDate.isValid() && approveDate.isAfter('2019-01-01', 'year')) {
                approval = 'Y';
            }
            else {
                approval = 'N';
            }

            let newData = {
                assetname: response.data.assetName,
                purpose: response.data.purpose,
                cost: response.data.cost,
                requeststatus: response.data.requestStatus,
                requestdate: response.data.requestDate,
                assetstatus: response.data.assestStatus,
                approved: approval,
                assetid: response.data.assetId
            };
            let tempData = openrequestdata;
            const index = tempData.indexOf(rowData);
            tempData[index] = newData;
            const dataRows = [];
            tempData.map(function (value, key) { 
                let obj = {
                    assetname: value.assetname,
                    purpose: value.purpose,
                    cost: value.cost,
                    requeststatus: value.requeststatus,
                    requestdate: value.requestdate,
                    assetstatus: value.assetstatus,
                    approved: approval,
                    assetid: value.assetid
                };
                dataRows.push(obj);
            });
            setOpenRequestData(dataRows); 
        });
    };

    const handleApproveEvent = async (rowData, approved) => {
        const token = await authService.getAccessToken();

        await API.get('/Asset/ApproveAsset', {
            params: {
                communityID: communityid,
                assetID: rowData.assetid,
                approve: approved,
                notes: assetnotes
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(response => { 
            const approveDate = moment(response.data.assetApproveDate, 'YYYY-MM-DDTHH:mm:ss');
            console.log(approveDate);
            let approval;
            if (approveDate.isValid() && approveDate.isAfter('2019-01-01', 'year')) {
                approval = 'Y';
            }
            else {
                approval = 'N';
            }

            let newData = {
                assetname: response.data.assetName,
                purpose: response.data.purpose,
                cost: response.data.cost,
                requeststatus: response.data.requestStatus,
                requestdate: response.data.requestDate,
                assetstatus: response.data.assestStatus,
                approved: approval,
                assetid: response.data.assetId
            };
            let tempData = openrequestdata;
            const index = tempData.indexOf(rowData);
            tempData[index] = newData;
            const dataRows = [];
            tempData.map(function (value, key) { 
                let obj = {
                    assetname: value.assetname,
                    purpose: value.purpose,
                    cost: value.cost,
                    requeststatus: value.requeststatus,
                    requestdate: value.requestdate,
                    assetstatus: value.assetstatus,
                    approved: approval,
                    assetid: value.assetid
                };
                dataRows.push(obj);
            });
            setOpenRequestData(dataRows);
        });
    };
 
    return (
        <MaterialTable
            title="All open requests"
            columns={columns}
            data={openrequestdata}
            detailPanel={rowData => {
                return (
                    <Card>
                        <CardBody>
                            <GridContainer>
                                <GridItem xs={12} sm={12} md={12}>
                                    <TextField
                                        id="assetnotes"
                                        label="Notes"
                                        className={classes.textField}
                                        value={assetnotes}
                                        onChange={e => setAssetNotes(e.target.value)}
                                        margin="normal"
                                        multiline
                                        rowsMax="5"
                                        fullWidth
                                    />
                                </GridItem>
                            </GridContainer>
                            {proVisible(rowData)}
                        </CardBody>
                    </Card>
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