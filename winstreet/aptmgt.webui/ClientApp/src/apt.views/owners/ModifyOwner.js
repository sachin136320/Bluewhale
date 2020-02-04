import React, { useState } from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";

import CustomInput from "components/CustomInput/CustomInput.js";
import Table from "components/Table/Table.js";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';
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
    }
};

//Just chcking if it works

const useStyles = makeStyles(styles);

const columns = [
    { title: 'First Name', field: 'firstname', type: 'text' },
    { title: 'Last Name', field: 'lastname', type: 'text' },
    { title: 'BlockID', field: 'blockid', type: 'text' },
    { title: 'Flat', field: 'flatNumber', type: 'text' },
    { title: 'Cell', field: 'cellnumber', type: 'text' },
    { title: 'Email', field: 'email', type: 'text' },
    { title: 'Notes', field: 'notes', type: 'text' },
    { title: 'Occupied', field: 'occupied', type: 'text' },
    { title: 'Active', field: 'active', type: 'text' }
]


export default function ModifyOwner1() {

    const classes = useStyles();

    useEffect(() => {
        // Create an scoped async function in the hook
        async function loadOwners(builderid) {
            const token = await authService.getAccessToken();
            await API.get('/owner/GetAll', {
                params: {
                    builderID: builderid
                },
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => {
                const dataRows = [];
                data.map(function (value, key) {
                    let obj = {
                        firstname: value.firstName,
                        lastname: value.lastName,
                        blockid: value.blockID,
                        flatNumber: value.lastNumber,
                        cellnumber: value.mobileNumber,
                        email: value.email,
                        notes: value.notes,
                        occupied: value.occupied,
                        active: value.active 
                    };
                    dataRows.push(obj);
                });
                setBuilderList(dataRows);
            });
        }

        // Execute the created function directly
        loadOwners('all');
    }, []);


    const updateOwnerDetail = async (newData, oldData) => {
        console.log(newData);
        console.log(oldData);

        const requestBody = JSON.stringify({
            FirstName: newData.firstname,
            LastName: newData.lastname,
            BlockID: newData.blockid,
            FlatNumber: newData.flatNumber,
            Occupied: true,
            MobileNumber: newData.cellnumber,
            Email: newData.email,
            QRText: newData.firstname + newData.lastname + newData.blockid + newData.flatNumber + newData.cellnumber,
            Active: newData.active,
            notes: newData.notes
        });

        console.log(requestBody);
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.put('/owner/Update', requestBody, config)
            .then(communityData => {

                let tempData = tabledata;
                const index = tempData.indexOf(oldData);
                tempData[index] = newData;
                const dataRows = [];
                tempData.map(function (value, key) {
                    let obj = {
                        firstname: value.firstName,
                        lastname: value.lastName,
                        blockid: value.blockID,
                        flatNumber: value.lastNumber,
                        cellnumber: value.mobileNumber,
                        email: value.email,
                        notes: value.notes,
                        occupied: value.occupied,
                        active: value.active 
                    };
                    dataRows.push(obj);
                });
                setTableData(dataRows);

            })
            .catch(function (response) {
                //handle error
                console.log(response);
            });
    }

    return (
        <Card>
            <MaterialTable
                title=""
                columns={columns}
                data={this.state.data}
                editable={{
                    onRowUpdate: (newData, oldData) =>
                        new Promise((resolve, reject) => {
                            updateOwnerDetail(newData, oldData);
                            resolve();
                        })
                }}
            />
        </Card>
    )

}
export default ModifyOwner1;


{/*
export default function ModifyOwner() {
    const classes = useStyles();
    return (
        <Card>
        <CardHeader plain color="primary">
            <h4 className={classes.cardTitleWhite}>
                Select a user to modify
            </h4>
        </CardHeader>
        <CardBody>
            <Table
                tableHeaderColor="primary"
                tableHead={["ID", "Name", "Country", "City", "Salary"]}
                tableData={[
                    ["1", "Dakota Rice", "$36,738", "Niger", "Oud-Turnhout"],
                    ["2", "Minerva Hooper", "$23,789", "Curaçao", "Sinaai-Waas"],
                    ["3", "Sage Rodriguez", "$56,142", "Netherlands", "Baileux"],
                    [
                        "4",
                        "Philip Chaney",
                        "$38,735",
                        "Korea, South",
                        "Overland Park"
                    ],
                    [
                        "5",
                        "Doris Greene",
                        "$63,542",
                        "Malawi",
                        "Feldkirchen in Kärnten"
                    ],
                    ["6", "Mason Porter", "$78,615", "Chile", "Gloucester"]
                ]}
            />
        </CardBody>
    </Card>
    );
}
*/}