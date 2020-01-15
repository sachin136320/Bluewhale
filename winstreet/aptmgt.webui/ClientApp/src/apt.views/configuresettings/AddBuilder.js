import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";

import CustomInput from "components/CustomInput/CustomInput.js";
import Info from "components/Typography/Info.js";
import Button from "components/CustomButtons/Button.js";

import API from "apt.utils/API.js";
import TextField from '@material-ui/core/TextField';
import authService from 'components/Authorization/AuthorizeService.js';


import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Divider from '@material-ui/core/Divider';
import InboxIcon from '@material-ui/icons/Inbox';
import DraftsIcon from '@material-ui/icons/Drafts';

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



async function processData(data) {
    console.log(data);
    const token = await authService.getAccessToken();
    const config = {
        headers: {
            authorization: `Bearer ${token}`,
            'Content-Type': 'application/json',
        }
    };


    await API.post('/Builder', data, config)
        .then(({ data }) => {
            return (data.builderId);
        })
        .catch(function (response) {
            //handle error
            console.log(response);
        });

    console.log("service call done");
}

export default function AddBuilder() {
    const classes = useStyles();

    const [buildername, setBuilderName] = React.useState('');
    const [builderaddress, setBuilderAddress] = React.useState('');
    const [state, setState] = React.useState('');
    const [city, setCity] = React.useState('');
    const [pincode, setPinCode] = React.useState('');
    const [builderId, setBuilderId] = React.useState('Not Generated');


    const saveBuilder = async () => {
        console.log(parseInt(pincode));
        const d = await processData(JSON.stringify({
            Name: buildername,
            Address: builderaddress,
            State: state,
            City: city,
            PinCode: pincode
        }))

        console.log(d);
        setBuilderId(d);
        console.log(d);

    }

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
                            label="Builder Name"
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            helperText="Enter Builder Name"
                            onChange={e => setBuilderName(e.target.value)}
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
                            helperText="Enter Builder Address"
                            onChange={e => setBuilderAddress(e.target.value)}
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
                            helperText="State"
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
                            helperText="City"
                            onChange={e => setCity(e.target.value)}
                        />
                    </GridItem>
                    <GridItem xs={12} sm={12} md={4}>
                        <TextField
                            required
                            id="pincode"
                            label="Pincode"
                            className={classes.textField}
                            margin="normal"
                            fullWidth
                            helperText="Pincode"
                            onChange={e => setPinCode(e.target.value)}
                        />
                    </GridItem>
                </GridContainer>
                <GridContainer>
                    <GridItem xs={12} sm={12} md={4}>
                        <TextField
                            id="outlined-read-only-input"
                            label="Builder Id"
                            className={classes.textField}
                            margin="normal"
                            InputProps={{
                                readOnly: true,
                            }}
                            variant="outlined"
                            value={builderId}
                        />
                    </GridItem>
                </GridContainer>
                <CardFooter>
                    <GridContainer>
                        <GridItem xs={12} sm={12} md={12}>
                            <Button variant="contained"
                                color="primary"
                                className={classes.button}
                                onClick={() => saveBuilder()}>
                                Add
                        </Button>
                        </GridItem>
                    </GridContainer>
                </CardFooter>
            </CardBody>
        </Card>
    );
}

{/*
 * function Foo() {
  const memoizedHandleClick = useCallback(
    () => {
      console.log('Click happened');
    },
    [], // Tells React to memoize regardless of arguments.
  );
  return <Button onClick={memoizedHandleClick}>Click Me</Button>;
}
 */}