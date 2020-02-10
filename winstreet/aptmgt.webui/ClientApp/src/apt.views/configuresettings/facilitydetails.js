import React, { useState, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js"; 

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

const tablecolumns = [
    { title: 'Facility Name', field: 'facilityname', type: 'string' },
    { title: 'Bookable', field: 'bookable', lookup: { 'Yes': 'Yes', 'No': 'No' } },
];

export default function FacilityDetails() {
    const classes = useStyles();


    const [builderlist, setBuilderList] = React.useState([]);
    const [communitylist, setCommunityList] = React.useState([]);
    const [selectedbuildername, setSelectedBuilderName] = React.useState('');
    const [selectedbuilderid, setSelectedBuilderId] = React.useState('');
    const [selectedcommunityname, setSelectedCommunityName] = React.useState('');
    const [selectedcommunityid, setSelectedCommunityId] = React.useState('');

    const [tabledata, setTableData] = React.useState([]);

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

            setTableData([]);
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
            setTableData(dataRows);
        });

    };


    const addFacilityDetail = async (newData) => {
        const requestBody = JSON.stringify({
            FacilityName: newData.facilityname,
            Bookable: newData.bookable, 
            CommunityID: selectedcommunityid
        });

        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.post('/Facility', requestBody, config)
            .then(facilityData => { 
                let newFacility = {
                    facilityname: facilityData.data.facilityName,
                    bookable: facilityData.data.bookable,  
                    facilityID: facilityData.data.id
                };
                const dataRows = [];
                let tempData = tabledata; 
                tempData.map(function (value, key) {
                    let obj = {
                        facilityname: value.facilityname,
                        bookable: value.bookable,  
                        facilityID: value.ID
                    };
                    dataRows.push(obj);
                }); 
                dataRows.push(newFacility);

                console.log(dataRows);
                setTableData(dataRows);
                console.log(tabledata);
            })
            .catch(function (response) {
                //handle error
                console.log(response);
            });
    }


    const updateFacilityDetail = async (newData, oldData) => {
        console.log(newData);
        console.log(oldData);

        const requestBody = JSON.stringify({
            FacilityName: newData.facilityname,
            Bookable: newData.bookable, 
            CommunityID: selectedcommunityid,
            ID: newData.facilityID
        });

        console.log(requestBody);
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.post('/Facility/Update', requestBody, config)
            .then(communityData => { 
                let tempData = tabledata;
                const index = tempData.indexOf(oldData);
                tempData[index] = newData;
                const dataRows = [];
                tempData.map(function (value, key) {
                    let obj = {
                        facilityname: value.facilityname,
                        bookable: value.bookable,  
                        facilityID: value.ID
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

    const deleteFacilityDetail = async (newData) => {
        const token = await authService.getAccessToken();
        await API.get('/Facility/delete', {
            params: {
                facilityID: newData.facilityID
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(communityData => {
            let tempData = tabledata;
            const index = tempData.indexOf(newData);
            tempData.splice(index, 1);
            const dataRows = [];
            tempData.map(function (value, key) {
                let obj = {
                    FacilityName: value.facilityname,
                    Bookable: value.bookable,  
                    facilityID: value.ID
                };
                dataRows.push(obj);
            });
            setTableData(dataRows);
        }).catch(function (response) {
            //handle error
            console.log(response);
        });
    }


    return (
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
            <GridItem xs={12} sm={12} md={12}>
                <MaterialTable
                    title=""
                    columns={tablecolumns}
                    data={tabledata}
                    editable={{
                        onRowAdd: newData =>
                            new Promise((resolve, reject) => {
                                addFacilityDetail(newData);
                                resolve();
                            }),
                        onRowUpdate: (newData, oldData) =>
                            new Promise((resolve, reject) => {
                                updateFacilityDetail(newData, oldData);
                                resolve();
                            }),
                        onRowDelete: oldData =>
                            new Promise((resolve, reject) => {
                                deleteFacilityDetail(oldData);
                                resolve();
                            }),
                    }}
                />
            </GridItem>
        </GridContainer>


    );
}

/*

                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                    <FormGroup row>
                        <FormControlLabel
                            label="Bookable"
                            control={
                            <Switch checked={state.checkedA} onChange={handleChange('checkedA')} value="checkedA" />
                            }
                        />
                        </FormGroup>
                    </GridItem>
                </GridContainer>
*/