import React from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";

import CustomInput from "components/CustomInput/CustomInput.js";
import Table from "components/Table/Table.js";

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

class ModifyOwner1 extends React.Component {
    constructor(props) { 
        super(props);
        this.state = {
            columns: [
                { title: 'Name', field: 'name', editable: 'onUpdate' },
                { title: 'Surname', field: 'surname', editable: 'never' },
                { title: 'Flat', field: 'flatNumber', type: 'text' },
                {
                    title: 'Block',
                    field: 'block',
                    lookup: { 34: 'İstanbul', 63: 'Şanlıurfa' },
                },
            ],
            data: [
                { name: 'Mehmet', surname: 'Baran', flatNumber: 'D', block: 63 },
                { name: 'Zerya Betül', surname: 'Baran', flatNumber: 'D', block: 34 },
            ]
        }
    }
 

    render() {
        return (
            <Card>
                <CardHeader plain color="primary">
                    <h5>Modify existing user</h5>
                </CardHeader> 
                    <MaterialTable
                        title=""
                        columns={this.state.columns}
                        data={this.state.data}
                        editable={{
                            onRowAdd: newData =>
                                new Promise((resolve, reject) => {
                                    setTimeout(() => {
                                        {
                                            const data = this.state.data;
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
            </Card>
        )
    }
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