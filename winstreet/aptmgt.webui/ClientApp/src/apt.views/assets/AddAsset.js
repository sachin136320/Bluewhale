import React, { useState, useEffect, useContext } from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import { UserContext } from "store/UserContext";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';
import TextField from '@material-ui/core/TextField';
import Button from "components/CustomButtons/Button.js";
import AddAssetDetails from "./AddAssetDetails";

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
    { title: 'Asset Name', field: 'name', type: 'string' },
    { title: 'Actual Cost', field: 'actualcost', type: 'string' },
    { title: 'Notes', field: 'notes', type: 'string' }
]

export default function AddAsset() {

    const [procuredrequestdata, setProcuredRequestData] = useState([]);

    const { communityid, setCommunityID } = useContext(UserContext);

    useEffect(() => {
        async function loadProcuredRequest(commid) {
            const token = await authService.getAccessToken();
            await API.get('/Asset/GetRecentlyProcuredAsset', {
                params: {
                    communityID: commid
                },
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => { 
                const dataRows = [];
                data.map(function (value, key) {
                    let obj = {
                        name: value.name,
                        actualcost: value.actualCost,
                        notes: value.notes,
                        assetRequestID: value.assetRequestId
                    };
                    dataRows.push(obj);
                });
                setProcuredRequestData(dataRows);
            });
        }

        //Execute the created function directly
        if (!communityid) {
            alert("Please select community ID.")
        } else {
            loadProcuredRequest(communityid);
        }

    }, []);


    return (
        <MaterialTable
            title="All open requests"
            columns={columns}
            data={procuredrequestdata}
            detailPanel={rowData => {
                return (
                    <AddAssetDetails
                        tableData={procuredrequestdata}
                        tableDataEvent={setProcuredRequestData}
                        option={rowData}
                    />
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