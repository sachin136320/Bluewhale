import React, { useState, useEffect, useContext } from "react";
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
import CardHeader from "components/Card/CardHeader";
import CardFooter from "components/Card/CardFooter";
import MenuItem from '@material-ui/core/MenuItem';
import 'date-fns';
import DateFnsUtils from '@date-io/date-fns';
import {
    MuiPickersUtilsProvider,
    KeyboardTimePicker,
    KeyboardDatePicker,
} from '@material-ui/pickers';

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

const useStyles = makeStyles(styles);

const YesNoOptions = [
    {
        value: 'yes',
        label: 'yes',
    },
    {
        value: 'no',
        label: 'no',
    }
];

export default function AddAssetDetails(options) {
    const classes = useStyles();

    const { communityid, setCommunityID } = useContext(UserContext);

    const [assettype, setAssetType] = useState('');
    const [assetdescription, setAssetDescription] = useState('');
    const [assetcategory, setAssetCategory] = useState('');
    const [requireservice, setRequireService] = useState('');
    const [nextservicedate, setNextServiceDate] = useState('');
    const [servicefrequency, setServiceFrequency] = useState('');
 
    const handleDateChange = date => {
        console.log(date);
        setNextServiceDate(date);
    };

    const handleAddAssetEvent = async (rowData) => {
        console.log(rowData);
        //call api to save visitor details 
        const requestBody = JSON.stringify({
            CommunityID: communityid,
            AssetRequestID: rowData.assetRequestID,
            AssetType: assettype,
            AssetDescription: assetdescription,
            AssetCategory: assetcategory,
            Name: rowData.name,
            ActualCost: rowData.ActualCost,
            Notes: rowData.notes,
            RequireService: requireservice,
            NextServiceDate: nextservicedate,
            ServiceFrequency: servicefrequency
        });
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API
            .post('/Asset/AddAsset', requestBody, config)
            .then(({ data }) => {
                console.log(data);
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
                options.tableDataEvent(dataRows);
            })
            .catch(function (response) {
                console.log(response);
            });;
    };

    return (
        <div>
            <Card>
                <CardHeader color="success">
                    <p className={classes.cardTitleBlack}>General Details</p>
                </CardHeader>
                <CardBody>
                    <GridContainer>
                        <GridItem xs={12} sm={6} md={6}>
                            <TextField
                                id="type"
                                label="Asset Type"
                                className={classes.textField}
                                value={assettype}
                                onChange={e => setAssetType(e.target.value)}
                                margin="normal"
                                rowsMax='5'
                                fullWidth
                            />
                        </GridItem>
                        <GridItem xs={12} sm={6} md={6}>
                            <TextField
                                id="actualcost"
                                label="Actual Category"
                                className={classes.textField}
                                value={assetcategory}
                                onChange={e => setAssetCategory(e.target.value)}
                                margin="normal"
                                fullWidth
                            />
                        </GridItem>
                        <GridItem xs={12} sm={12} md={12}>
                            <TextField
                                id="assetdescription"
                                label="Asset Description"
                                className={classes.textField}
                                value={assetdescription}
                                onChange={e => setAssetDescription(e.target.value)}
                                margin="normal"
                                fullWidth
                            />
                        </GridItem>

                    </GridContainer>
                </CardBody>
            </Card>
            <Card>
                <CardHeader color="success">
                    <p className={classes.cardTitleBlack}>Service Details</p>
                </CardHeader>
                <CardBody>
                    <GridContainer>
                        <GridItem xs={12} sm={6} md={6}>
                            <TextField
                                required
                                select
                                label="Require Service"
                                className={classes.textField}
                                value={requireservice}
                                onChange={e => setRequireService(e.target.value)}
                                margin="normal"
                            >
                                {YesNoOptions.map(option => (
                                    <MenuItem key={option.value} value={option.value}>
                                        {option.label}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </GridItem>
                        <GridItem xs={12} sm={6} md={6}>
                            <TextField
                                label="Service Frequency in Days"
                                className={classes.textField}
                                value={servicefrequency}
                                onChange={e => setServiceFrequency(e.target.value)}
                                margin="normal"
                                fullWidth
                            />
                        </GridItem>
                        <GridItem>
                            <MuiPickersUtilsProvider utils={DateFnsUtils}>
                                <KeyboardDatePicker
                                    disableToolbar
                                    variant="inline"
                                    format="MM/dd/yyyy"
                                    margin="normal"
                                    id="date-picker-inline" 
                                    value={nextservicedate}
                                    onChange={handleDateChange}
                                    KeyboardButtonProps={{
                                        'aria-label': 'change date',
                                    }}
                                />
                            </MuiPickersUtilsProvider>
                        </GridItem>
                    </GridContainer>
                </CardBody>
                <CardFooter chart>
                    <GridContainer>
                        <GridItem xs={12} sm={12} md={12}>
                            <Button
                                color="primary"
                                round
                                onClick={() => handleAddAssetEvent(options.option)}>
                                Add Asset
                        </Button>
                        </GridItem>
                    </GridContainer>
                </CardFooter>
            </Card>
        </div>
    );
}
