import React, { useState, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";

import TextField from '@material-ui/core/TextField';
import MaterialTable from "material-table";


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
    },
    container: {
        display: 'flex',
        flexWrap: 'wrap',
    },
    textField: {
        marginLeft: 1,
        marginRight: 1,
    },
};

const useStyles = makeStyles(styles);

const facilitycolumn = [
    { title: 'Facility Name', field: 'facilityname', type: 'string' },
    { title: 'Bookable', field: 'bookable', lookup: { 'Yes': 'Yes', 'No': 'No' } },
];
const blockcolumns = [
    { title: 'Block Name', field: 'blockName', type: 'string' },
    { title: 'Number of Floors', field: 'numberOfFloors', type: 'numeric' },
    { title: 'Number of Flats', field: 'numberOfFlats', type: 'numeric' },
];

export default function BasicSettingSummary() {
    const classes = useStyles();


    const [selectedbuildername, setSelectedBuilderName] = React.useState('');
    const [selectedbuilderid, setSelectedBuilderId] = React.useState('');
    const [selectedcommunityname, setSelectedCommunityName] = React.useState('');
    const [selectedcommunityid, setSelectedCommunityId] = React.useState('');

    const [builderlist, setBuilderList] = React.useState([]);
    const [communitylist, setCommunityList] = React.useState([]);

    const [addressline1, setAddressLine1] = React.useState('');
    const [state, setState] = React.useState('');
    const [city, setCity] = React.useState('');
    const [pincode, setPincode] = React.useState('');

    const [blockdetails, setBlockDetails] = React.useState([]);
    const [facilitydetails, setFacilityDetails] = React.useState([]);



    useEffect(() => {
        // Create an scoped async function in the hook
        async function loadBuilderList(builderid) {
            const token = await authService.getAccessToken();
            await API.get('/Builder', {
                params: {
                    builderID: builderid
                },
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => {
                const dataRows = [];
                data.map(function (value, key) {
                    let obj = {
                        value: value.builderID,
                        label: value.builderName
                    };
                    dataRows.push(obj);
                });
                setBuilderList(dataRows);
            });
        }

        // Execute the created function directly
        loadBuilderList('all');
    }, []);

    const handleBuilderName = async (event) => {
        setSelectedBuilderName(event.target.value);
        await setSelectedBuilderId(event.target.value);

        // Set Apartment Name Drop down to blank
        const token = await authService.getAccessToken();
        await API.get('/GetCommunityList', {
            params: {
                builderID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let obj = {
                    value: value.communityID,
                    label: value.commName
                };
                dataRows.push(obj);
            });
            setCommunityList(dataRows); 
        });
    };

    const handleCommunityNameChange = async (event) => {
        // Check if builder name is available
        setSelectedCommunityName(event.target.value);
        await setSelectedCommunityId(event.target.value)

        // Make a request to get the list Blocks
        const token = await authService.getAccessToken();
        await API.get('/facility', {
            params: {
                commID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let obj = {
                    facilityname: value.facilityName,
                    bookable: value.bookable,
                    facilityID: value.facilityID
                };
                dataRows.push(obj);
            });
            setFacilityDetails(dataRows);
        });

        //Block Details
        await API.get('/Community', {
            params: {
                commID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let obj = {
                    blockName: value.blockName,
                    numberOfFloors: value.numberOfFloors,
                    numberOfFlats: value.numberOfFlats,
                    blockID: value.commBlockID
                };
                dataRows.push(obj);
            });
            setBlockDetails(dataRows);
        });

        //Community Details
        await API.get('/Community/GetCommunityDetail', {
            params: {
                commID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => { 
            console.log(data[0]);
            setAddressLine1(data[0].address);
            setState(data[0].state);
            setCity(data[0].city);
            setPincode(data[0].pincode);
        });


    };



    return (
        <Card>
            <CardBody>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            required
                            id="buildername"
                            label="Builder Name"
                            select
                            value={selectedbuildername}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            onChange={handleBuilderName}
                            variant="outlined"
                        >
                            {builderlist.map(option => (
                                <MenuItem key={option.value} value={option.value}>
                                    {option.label}
                                </MenuItem>
                            ))}
                        </TextField>
                    </GridItem>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            id="apartmentname"
                            label="Apartment Name"
                            required
                            select
                            value={selectedcommunityname}
                            className={classes.textField}
                            margin="normal"
                            onChange={handleCommunityNameChange}
                            fullWidth
                            variant="outlined"
                        >
                            {communitylist.map(option => (
                                <MenuItem key={option.value} value={option.value}>
                                    {option.label}
                                </MenuItem>
                            ))}
                        </TextField>

                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <TextField
                            id="outlined-read-only-input"
                            label="Apartment ID"
                            value={selectedcommunityid}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            InputProps={{
                                readOnly: true,
                            }}
                            variant="outlined"
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={12}>
                        <TextField
                            id="outlined-read-only-input"
                            label="Address Line1"
                            value={addressline1}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            InputProps={{
                                readOnly: true,
                            }}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            id="outlined-read-only-input"
                            label="State"
                            value={state}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            InputProps={{
                                readOnly: true,
                            }}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            id="outlined-read-only-input"
                            label="City"
                            value={city}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            InputProps={{
                                readOnly: true,
                            }}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={6}>
                        <TextField
                            id="outlined-read-only-input"
                            label="Pincode"
                            value={pincode}
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            InputProps={{
                                readOnly: true,
                            }}
                        />
                    </GridItem>
                </GridContainer>

                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <MaterialTable
                            title="Block Details"
                            columns={blockcolumns}
                            data={blockdetails}
                        />
                    </GridItem>
                </GridContainer>

                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <MaterialTable
                            title="Facility Details"
                            columns={facilitycolumn}
                            data={facilitydetails}
                        />
                    </GridItem>
                </GridContainer>

            </CardBody>
        </Card>
    );
}