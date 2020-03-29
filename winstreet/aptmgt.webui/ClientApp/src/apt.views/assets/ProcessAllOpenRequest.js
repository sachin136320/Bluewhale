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
 
import ApproveAsset from "./ApproveAsset";

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
    const { communityid, setCommunityID } = useContext(UserContext);

    const [openrequestdata, setOpenRequestData] = useState([]); 

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
                    const approveDate = moment(value.approveDate, 'YYYY-MM-DDTHH:mm:ss.SSSZ');
                    let approval;
                    if (approveDate.isValid() && approveDate.isAfter('2019-01-01', 'year')) {
                        approval = 'Y';
                    }
                    else {
                        approval = 'N';
                    }

                    let obj = {
                        assetname: value.name,
                        purpose: value.purpose,
                        cost: value.estimatedCost,
                        requeststatus: value.requestStatus,
                        requestdate: value.requestDate,
                        assetstatus: value.approvalStatus,
                        approved: approval,
                        assetid: value.assetRequestId,
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
 
 
    return ( 
            <MaterialTable
                title="All open requests"
                columns={columns}
                data={openrequestdata}
                detailPanel={rowData => {
                    return (
                        <ApproveAsset 
                            tableData={openrequestdata}
                            tableDataEvent={setOpenRequestData}
                            option={rowData} />
                    )
                }}
                onRowClick={(event, rowData, togglePanel) => togglePanel()}

            /> 
    );
}


/*


                        <Card>
                            <CardBody>

                                {proVisible(rowData)}
                            </CardBody>
                        </Card>

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