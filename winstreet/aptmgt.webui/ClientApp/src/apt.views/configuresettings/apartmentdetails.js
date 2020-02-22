import React, { useState, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";

import API from "apt.utils/API.js";
import TextField from '@material-ui/core/TextField';
import authService from 'components/Authorization/AuthorizeService.js';
import Button from "components/CustomButtons/Button.js";
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

const useStyles = makeStyles(styles);
 

export default function AddApartmentCommunity() {
    const classes = useStyles();


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
                setBuilderName(prepareBuilderNameArray(data));
            });
        }

        // Execute the created function directly
        loadBuilderList('all');
    }, []);


    const prepareBuilderNameArray = (data) => { 
        const dataRows = [];
        data.map(function (value, key) { 
            let obj = {
                value: value.builderID,
                label: value.builderName
            };
            dataRows.push(obj);
        }); 
        return dataRows;
    };

    const [buildername, setBuilderName] = React.useState([]);
    const [selectedbuildername, setSelectedBuilderName] = React.useState('');
    const [selectedbuilderid, setSelectedBuilderId] = React.useState('');
    const [apartmentname, setApartmentName] = React.useState('');
    const [address, setAddress] = React.useState('');
    const [state, setState] = React.useState('');
    const [city, setCity] = React.useState('');
    const [pincode, setPinCode] = React.useState('');
    const [apartmentid, setApartmentID] = React.useState('Not Generated');


    const saveCommunity = async () => {
        const requestBody = JSON.stringify({
            Name: apartmentname,
            Address: address,
            State: state,
            City: city,
            Pincode: parseInt(pincode),
            BuilderID: selectedbuilderid
        });
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.post('/Community', requestBody, config)
            .then(communityData => { 
                setApartmentID(communityData.data.communityId); 
            })
            .catch(function (response) {
                //handle error
                console.log(response);
            });
    }

    const handleBuilderNameChange = event => { 
        setSelectedBuilderName(event.target.value);
        setSelectedBuilderId(event.target.value)
    };

    return (
        <Card>
            <CardBody>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        {/* 
                    You can use TextField tag as well for more details look into
                    https://material-ui.com/components/text-fields/
                    */ }  
                        <TextField
                            required
                            id="buildername"
                            select
                            label="Builder Name"
                            value={selectedbuildername} 
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            helperText="Enter Builder Name"
                            onChange={handleBuilderNameChange}
                        >
                            {buildername.map(option => ( 
                                <MenuItem key={option.value} value={option.value}>
                                    {option.label}
                                </MenuItem>
                            ))}
                        </TextField>
                    </GridItem>
                    <GridItem xs={12} sm={12} md={12}>
                        <TextField
                            required
                            id="apartmentname"
                            label="Apartment Name"
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            helperText="Enter Apartment Name"
                            onChange={e => setApartmentName(e.target.value)}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <TextField
                            required
                            id="addressline1"
                            label="Address Line1"
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            helperText="Enter Address Line1"
                            onChange={e => setAddress(e.target.value)}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={3}>
                        <TextField
                            required
                            id="state"
                            label="State"
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            helperText="Enter state"
                            onChange={e => setState(e.target.value)}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={3}>
                        <TextField
                            required
                            id="city"
                            label="City"
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            helperText="Enter City"
                            onChange={e => setCity(e.target.value)}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={4}>
                        <TextField
                            required
                            id="cipincodety"
                            label="Pincode"
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            helperText="Enter Pincode"
                            onChange={e => setPinCode(e.target.value)}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={4}>
                        <TextField
                            id="outlined-read-only-input" 
                            id="apartmentid"
                            label="Apartment Id"
                            className={classes.textField}
                            margin="normal"
                            InputProps={{
                                readOnly: true,
                            }}
                            value={apartmentid}
                            variant="outlined"
                            fullWidth 
                        /> 
                    </GridItem>
                </GridContainer>

                <GridContainer>
                    <GridItem xs={12} sm={12} md={12}>
                        <Button variant="contained"
                            color="primary"
                            className={classes.button}
                            onClick={() => saveCommunity()}>
                            Add
                        </Button>
                    </GridItem>
                </GridContainer>
                <CardFooter>

                </CardFooter>
            </CardBody>
        </Card>
    );
}