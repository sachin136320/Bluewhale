import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardBody from "components/Card/CardBody.js";


import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Divider from '@material-ui/core/Divider';
import MaterialTable from "material-table";


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

/*
 *const tablecolumns = [
    { title: 'Block Name', field: 'blockName', editable: 'onUpdate' },
    { title: 'Number of Floors', field: 'numberOfFloors', editable: 'never' },
    { title: 'Number of Flats', field: 'numberOfFlats', editable: 'onUpdate', type: 'text' },
    {
        title: 'Block',
        field: 'block',
        lookup: { 34: 'İstanbul', 63: 'Şanlıurfa' },
    },
];

const tabledata = [
    { blockName: 'Mehmet', numberOfFloors: 'Baran', numberOfFlats: 'D', block: 63 },
    { name: 'Zerya Betül', surname: 'Baran', flatNumber: 'D', block: 34 },
];
 */
const tablecolumns = [
    { title: 'Block Name', field: 'blockName', editable: 'onUpdate' },
    { title: 'Number of Floors', field: 'numberOfFloors', editable: 'never' },
    { title: 'Number of Flats', field: 'numberOfFlats', editable: 'onUpdate', type: 'text' },
];
const tabledata = [
    { blockName: 'Mehmet', numberOfFloors: 'Baran', numberOfFlats: 'D' },
    { blockName: 'Mehmet', numberOfFloors: 'Baran', numberOfFlats: 'D' },
];

export default function BlockDetails() {

    const classes = useStyles();

    return ( 
            <Card>
                <CardBody>
                    <GridContainer>
                        <GridItem xs={12} sm={12} md={6}>
                            <TextField
                                id="apartmentname"
                                label="Apartment Name"
                                required
                                select
                                defaultValue="apartmentname"
                                className={classes.textField}
                                margin="normal"
                                fullWidth
                                onChange={console.log()}
                                InputProps={{
                                    readOnly: true,
                                }}
                                variant="outlined"
                            >
                                 
                            </TextField>

                        </GridItem>
                        <GridItem xs={12} sm={12} md={6}>
                            <TextField
                                required
                                id="buildername"
                                label="Builder Name"
                                select
                                defaultValue="buildername"
                                className={classes.textField}
                                margin="normal"
                                fullWidth
                                onChange={console.log()}
                                InputProps={{
                                    readOnly: true,
                                }}
                                variant="outlined"
                            >
                                 
                            </TextField>
                        </GridItem>
                    </GridContainer>

                    <GridContainer>
                        <GridItem xs={6} sm={6} md={6}>
                            <Button variant="contained" color="primary" className={classes.button}>
                                Add
                        </Button>
                        </GridItem>
                    </GridContainer>

                    <GridContainer>
                        <GridItem xs={12} sm={12} md={12}>
                            <MaterialTable
                                title=""
                                columns={tablecolumns}
                                data={tabledata}
                                editable={{
                                    onRowAdd: newData =>
                                        new Promise((resolve, reject) => {
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
                            />
                        </GridItem>
                    </GridContainer>

                </CardBody>
            </Card> 
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
 */
