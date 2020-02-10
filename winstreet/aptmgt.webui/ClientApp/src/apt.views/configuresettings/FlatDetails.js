import React, { useState, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";


import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
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
        width: 200,
    },
};

const useStyles = makeStyles(styles);

const tablecolumns = [
    { title: 'Flat Number', field: 'flatnumber', type: 'string' },
    { title: 'Floor Number', field: 'floornumber', type: 'string' }
];

export default function FlatDetails() {

    const classes = useStyles();

    const [builderlist, setBuilderList] = React.useState([]);
    const [communitylist, setCommunityList] = React.useState([]);
    const [blocklist, setBlockList] = React.useState([]);

    const [selectedblock, setSelectedBlock] = React.useState('');
    const [selectedblockid, setSelectedBlockId] = React.useState('');

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
        await API.get('/Community', {
            params: {
                commID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let objForBlockDropdown = {
                    value: value.commBlockID,
                    label: value.blockName
                };
                let obj = {
                    blockName: value.blockName,
                    numberOfFloors: value.apartmentName,
                    numberOfFlats: value.apartmentName,
                    blockID: value.commBlockID
                };
                dataRows.push(objForBlockDropdown);
            });
            setBlockList(dataRows);
            setTableData([]);
        });

    };

    const handleBlockChange = async (event) => {
        // Check if builder name is available
        setSelectedBlock(event.target.value);
        await setSelectedBlockId(event.target.value)

        // Make a request to get the list Blocks
        const token = await authService.getAccessToken();
        await API.get('/Flats', {
            params: {
                blockID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let obj = {
                    flatID: value.flatID,
                    flatnumber: value.flatNumber,
                    floornumber: value.floorNumber
                };
                dataRows.push(obj);
            });
            setTableData(dataRows);
        });

    };

    const updateFlatDetail = async (newData, oldData) => {
        console.log(newData);
        console.log(oldData);

        const requestBody = JSON.stringify({
            FlatID: newData.flatID,
            FlatNumber: newData.flatnumber,
            FloorNumber: parseInt(newData.floornumber)
        });

        console.log(requestBody);
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.post('/Flats/Update', requestBody, config)
            .then(communityData => {
                let tempData = tabledata;
                const index = tempData.indexOf(oldData);
                tempData[index] = newData;
                const dataRows = [];
                tempData.map(function (value, key) {
                    let obj = {
                        flatID: flatData.data.flatID,
                        flatnumber: flatData.data.flatNumber,
                        floornumber: flatData.data.floorNumber
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

    const addFlatDetail = async (newData) => {
        const requestBody = JSON.stringify({
            BlockID: selectedblockid,
            FlatNumber: newData.flatnumber,
            FloorNumber: parseInt(newData.floornumber)
        });

        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.post('/Flats', requestBody, config)
            .then(flatData => {
                console.log(flatData);
                let newFlat = {
                    flatID: flatData.data.flatID,
                    flatnumber: flatData.data.flatNumber,
                    floornumber: flatData.data.floorNumber
                };
                const dataRows = [];
                let tempData = tabledata;
                tempData.map(function (value, key) {
                    let obj = {
                        flatID: value.flatid,
                        flatnumber: value.flatnumber,
                        floornumber: value.floornumber
                    };
                    dataRows.push(obj);
                });
                dataRows.push(newFlat);
                console.log(dataRows);
                setTableData(dataRows);
                console.log(tabledata);
            })
            .catch(function (response) {
                //handle error
                console.log(response);
            });
    }

    const deleteFlatDetail = async (newData) => {
        const token = await authService.getAccessToken();
        await API.get('/Blocks/delete', {
            params: {
                flatID: newData.flatID
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(communityData => {
            let tempData = tabledata;
            const index = tempData.indexOf(newData);
            tempData.splice(index, 1);
            const dataRows = [];
            tempData.map(function (value, key) {
                let obj = {
                    flatID: value.flatid,
                    flatnumber: value.flatnumber,
                    floornumber: value.floornumber
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
            <GridItem xs={4} sm={4} md={4}>
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

            <GridItem xs={4} sm={4} md={4}>
                <TextField
                    id="apartmentname"
                    label="Apartment Name"
                    required
                    select
                    value={selectedcommunityname}
                    className={classes.textField}
                    margin="normal"
                    fullWidth
                    onChange={handleCommunityNameChange}
                    variant="outlined"
                >
                    {communitylist.map(option => (
                        <MenuItem key={option.value} value={option.value}>
                            {option.label}
                        </MenuItem>
                    ))}
                </TextField>
            </GridItem>
            
            <GridItem xs={4} sm={4} md={4}>
                <TextField
                    required
                    id="block"
                    label="Block"
                    select
                    value={selectedblock}
                    className={classes.textField}
                    margin="normal"
                    fullWidth
                    onChange={handleBlockChange}
                    variant="outlined"
                >
                    {blocklist.map(option => (
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
                                addFlatDetail(newData);
                                resolve();
                            }),
                        onRowUpdate: (newData, oldData) =>
                            new Promise((resolve, reject) => {
                                updateFlatDetail(newData, oldData);
                                resolve();
                            }),
                        onRowDelete: oldData =>
                            new Promise((resolve, reject) => {
                                deleteFlatDetail(oldData);
                                resolve();
                            }),
                    }}
                />
            </GridItem>
        </GridContainer>
    );
}

/*
 *

            <GridContainer>
                <GridItem xs={12} sm={12} md={12}>
                    <Button variant="contained" color="primary" className={classes.button}>
                        Back
                        </Button>
                    <Button variant="contained" color="primary" className={classes.button}>
                        NExt
                        </Button>
                </GridItem>
            </GridContainer>



            onRowAdd: newData =>
                                    new Promise((resolve, reject) => {
                                        addBlockDetail(newData);
                                        resolve()
                                        setTimeout(() => {
                                            {
                                                const data = tabledata;
                                                data.push(newData);
                                                this.setState({ data }, () => resolve());
                                            }
                                            resolve()
                                        }, 1000)
                                    }),
                                onRowUpdate: (newData, oldData) =>
                                    new Promise((resolve, reject) => {
                                        setTimeout(() => {
                                            {
                                                const data = tabledata;
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
                                                let data = tabledata;
                                                const index = data.indexOf(oldData);
                                                data.splice(index, 1);
                                                this.setState({ data }, () => resolve());
                                            }
                                            resolve()
                                        }, 1000)
                                    }),
                            }}
 */
