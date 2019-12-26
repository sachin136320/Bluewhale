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

import FormGroup from '@material-ui/core/FormGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Switch from '@material-ui/core/Switch';


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
    { title: 'Name', field: 'name', editable: 'onUpdate' },
    { title: 'Surname', field: 'surname', editable: 'never' },
    { title: 'Flat', field: 'flatNumber', type: 'text' },
    {
        title: 'Block',
        field: 'block',
        lookup: { 34: 'İstanbul', 63: 'Şanlıurfa' },
    },
    { title: 'Parking ID', field: 'parkingId', type: 'text' },
];
const tabledata = [
    { name: 'Mehmet', surname: 'Baran', flatNumber: 'D', block: 63, parkingId: 'P1' },
    { name: 'Zerya Betül', surname: 'Baran', flatNumber: 'D', block: 34 , parkingId: 'P2' },
];

export default function ParkingAllocation() { 
    const classes = useStyles();
    const [state, setState] = React.useState({
        checkedA: true,
        checkedB: true,
      });
    
      const handleChange = name => event => {
        setState({ ...state, [name]: event.target.checked });
      };
    return (
        <Card>
            <CardBody> 
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