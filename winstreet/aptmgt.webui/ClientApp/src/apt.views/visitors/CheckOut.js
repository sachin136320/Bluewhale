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

class CheckOut extends React.Component {
    constructor(props) { 
        super(props);
        this.state = {
            columns: [
                { title: 'Visitor ID', field: 'visitorid', editable: 'onUpdate' },
                { title: 'Visitor Name', field: 'visitorname', editable: 'never' },
                { title: 'Host Name', field: 'hostname', type: 'text' }, 
                { title: 'Host Phone', field: 'hostphone', type: 'text' },
                { title: 'Checkin time', field: 'checkintime', type: 'text' },
                { title: 'CheckOut time', field: 'checkouttime', type: 'text' },
               
            ],
            data: [
                { visitorid: 'Mehmet', visitorname: 'Baran', hostname: 'D', hostphone: 63, checkintime :"8:00AM" , checkouttime :""},
                { visitorid: 'Sachin', visitorname: 'Sachin', hostname: 'D', hostphone: 63 , checkintime :"8:00AM" , checkouttime :""},
                { visitorid: 'Suresh', visitorname: 'Suresh', hostname: 'D', hostphone: 63, checkintime :"8:00AM"  , checkouttime :""},
                { visitorid: 'Ram', visitorname: 'Ram', hostname: 'D', hostphone: 63 , checkintime :"8:00AM" , checkouttime :""},
                { visitorid: 'Rahim', visitorname: 'BarRahiman', hostname: 'D', hostphone: 63 , checkintime :"8:00AM" , checkouttime :""},
            ]
        }
    }
 

    render() {
        return (
            <Card>
                <CardHeader plain color="primary">
                    <h5>List of Active Visitors</h5>
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
                                })
                        }}
                        actions={[
                            {
                              icon: 'save',
                              tooltip: 'Checkout User',
                              onClick: (event, rowData) => alert("Checkout : " + rowData.name)
                            } 
                          ]}
                    /> 
            </Card>
        )
    }
}
export default CheckOut;

